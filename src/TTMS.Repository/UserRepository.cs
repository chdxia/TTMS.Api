using Microsoft.AspNetCore.Http;

namespace TTMS.Repository
{
    public class UserRepository : DefaultRepository<User, long>, IUserRepository
    {
        private readonly IFreeSql _fsql;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IFreeSql fsql, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(fsql)
        {
            _fsql = fsql;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserLoginResponse> UserLogin(UserLoginRequest request)
        {
            var model = await _fsql.Select<User>().Where(a => a.Account == request.Account).FirstAsync();
            if (model == null || model.PassWord != SecurityUtility.HashWithSalt(request.PassWord, model.Salt))
            {
                throw new Exception("Incorrect Account or PassWord."); // 账户或密码错误
            }
            model.AccessToken = SecurityUtility.GenerateRandomString(20); // AccessToken认证，暂时使用20随机字符串，暂时存入PostgreSQL，后续优化
            try
            {
                await UpdateAsync(model);
                return _mapper.Map<User, UserLoginResponse>(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 用户退出登录
        /// </summary>
        /// <returns></returns>
        public async Task UserLogout()
        {
            var userId = ((User)_httpContextAccessor.HttpContext.Items["User"]).Id;
            var model = await _fsql.Select<User>().Where(a => a.Id == userId).FirstAsync();
            if (model != null)
            {
                model.AccessToken = null;
                try
                {
                    await UpdateAsync(model);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// 根据accessToken获取用户信息;用于获取并存储当前用户的身份信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<UserLoginResponse> GetUserByTokenAsync(string accessToken)
        {
            return await _fsql.Select<User>().Where(a => a.AccessToken == accessToken).FirstAsync<UserLoginResponse>();
        }

        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResponse> GetUserByIdAsync(int id)
        {
            return await _fsql.Select<User>().Where(a => a.Id == id).ToOneAsync<UserResponse>();
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<UserResponse>> GetUserListAsync(UserRequest request)
        {
            var query = _fsql.Select<User>()
                .Where(a => !a.IsDelete)
                //.Where(a => request.State != null && request.State == a.State)
                .WhereIf(!string.IsNullOrEmpty(request.Account), a => a.Account.Contains(request.Account))
                .WhereIf(!string.IsNullOrEmpty(request.UserName), a => a.UserName.Contains(request.UserName))
                .WhereIf(!string.IsNullOrEmpty(request.Email), a => a.Email.Contains(request.Email))
                .WhereIf(request.GroupId.HasValue, a => a.GroupId == request.GroupId)
                .WhereIf(request.CreateTimeStart.HasValue, a => a.CreateTime >= request.CreateTimeStart)
                .WhereIf(request.CreateTimeEnd.HasValue, a => a.CreateTime <= request.CreateTimeEnd)
                .WhereIf(request.CreateBy.HasValue, a => a.CreateBy == request.CreateBy)
                .WhereIf(request.UpdateTimeStart.HasValue, a => a.UpdateTime >= request.UpdateTimeStart)
                .WhereIf(request.UpdateTimeEnd.HasValue, a => a.UpdateTime <= request.UpdateTimeEnd)
                .WhereIf(request.UpdateBy.HasValue, a => a.UpdateBy == request.UpdateBy)
                .OrderByDescending(a => a.CreateTime);
            var List = await query.ToListAsync<UserResponse>();
            return List;
        }

        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<UserResponse>> GetUserPageListAsync(UserRequest request)
        {
            var query = _fsql.Select<User>()
                .Where(a => !a.IsDelete)
                //.Where(a => request.State != null && request.State == a.State)
                .WhereIf(!string.IsNullOrEmpty(request.Account), a => a.Account.Contains(request.Account))
                .WhereIf(!string.IsNullOrEmpty(request.UserName), a => a.UserName.Contains(request.UserName))
                .WhereIf(!string.IsNullOrEmpty(request.Email), a => a.Email.Contains(request.Email))
                .WhereIf(request.GroupId.HasValue, a => a.GroupId == request.GroupId)
                .WhereIf(request.CreateTimeStart.HasValue, a => a.CreateTime >= request.CreateTimeStart)
                .WhereIf(request.CreateTimeEnd.HasValue, a=> a.CreateTime <= request.CreateTimeEnd)
                .WhereIf(request.CreateBy.HasValue, a=> a.CreateBy == request.CreateBy)
                .WhereIf(request.UpdateTimeStart.HasValue, a=> a.UpdateTime >= request.UpdateTimeStart)
                .WhereIf(request.UpdateTimeEnd.HasValue, a=> a.UpdateTime <= request.UpdateTimeEnd)
                .WhereIf(request.UpdateBy.HasValue, a=> a.UpdateBy == request.UpdateBy)
                .OrderByDescending(a => a.CreateTime);
            var List = await query.ToListAsync<UserResponse>();
            return List;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserResponse> InsertUserAsync(CreateUserRequest request)
        {
            if (_fsql.Select<User>().Where(a => a.Account == request.Account || a.Email == request.Email).Where(a => a.IsDelete == false).ToList().Any())
            {
                throw new Exception("Account or email already exists."); // 新增失败，账户或邮箱已存在
            }
            if (!_fsql.Select<Group>().Where(a => a.Id == request.GroupId).Where(a => a.IsDelete == false).ToList().Any())
            {
                throw new Exception("Group does not exist."); // 新增失败，分组不存在
            }
            var model = _mapper.Map<CreateUserRequest, User>(request);
            var hashWithNewSalt = SecurityUtility.HashWithNewSalt(request.PassWord);
            model.PassWord = hashWithNewSalt.hashedValue;
            model.Salt = hashWithNewSalt.salt;
            try
            {
                await InsertAsync(model);
                return _mapper.Map<User, UserResponse>(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserResponse> UpdateUserAsync(UpdateUserRequest request)
        {
            var model = await _fsql.Select<User>().Where(a => a.Id == request.Id).FirstAsync();
            if(model == null) // 如果用户表没有这个用户Id
            {
                throw new Exception("User does not exist."); // 修改失败，用户不存在
            }
            else if (_fsql.Select<User>() // 如果Account或Email和其它未删除用户一样
                .Where(a => a.Id != request.Id)
                .Where(a => a.Account == request.Account || a.Email == request.Email)
                .Where(a => a.IsDelete == false)
                .ToList().Any())
            {
                throw new Exception("Account or email already exists."); // 修改失败，账户或邮箱已存在
            }
            if (!_fsql.Select<Group>().Where(a => a.Id == request.GroupId).Where(a => a.IsDelete == false).ToList().Any())
            {
                throw new Exception("Group does not exist."); // 修改失败，分组不存在
            }
            _mapper.Map(request, model);
            if (!string.IsNullOrEmpty(request.PassWord))
            {
                var hashWithNewSalt = SecurityUtility.HashWithNewSalt(request.PassWord);
                model.PassWord = hashWithNewSalt.hashedValue;
                model.Salt = hashWithNewSalt.salt;
            }
            model.UpdateTime = DateTime.Now;
            try
            {
                await UpdateAsync(model);
                return _mapper.Map<User, UserResponse>(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task DeleteUserAsync(DeleteUserRequest request)
        {
            if (!request.UserIds.Any())
            {
                throw new Exception("用户Id为空，请填写有效用户Id.");
            }
            var existingUserIds = await _fsql.Select<User>()
                .Where(a => request.UserIds.Contains(a.Id))
                .ToListAsync();
            var nonExistingUserIds = request.UserIds.Except(existingUserIds.Select(a => a.Id));
            if (nonExistingUserIds.Any())
            {
                throw new Exception($"删除失败，以下用户ID不存在: {string.Join(", ", nonExistingUserIds)}.");
            }
            var affectedRows = await _fsql.Update<User>()
                .Set(a => a.IsDelete, true)
                .Set(a => a.UpdateTime, DateTime.Now)
                .Where(a => request.UserIds.Contains(a.Id))
                .ExecuteAffrowsAsync();
            if (affectedRows <= 0)
            {
                throw new Exception("删除失败.");
            }
        }
    }
}
