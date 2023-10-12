namespace LRtest.Repository
{
    public class UserRepository : DefaultRepository<User, long>, IUserRepository
    {
        private readonly IFreeSql _fsql;
        private readonly IMapper _mapper;

        public UserRepository(IFreeSql fsql, IMapper mapper) : base(fsql)
        {
            _fsql = fsql;
            _mapper = mapper;
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
        public async Task<(bool, string, UserResponse?)> InsertUserAsync(CreateUserRequest request)
        {
            if (_fsql.Select<User>()
                .Where(a => a.Account == request.Account)
                .Where(a => a.IsDelete == false)
                .ToList().Any())
            {
                return (false, "Account already exists", null); // 新增失败，账号已存在
            }
            else if (_fsql.Select<User>()
                .Where(a => a.Email == request.Email)
                .Where(a => a.IsDelete == false)
                .ToList().Any())
            {
                return (false, "Email already exists", null); // 新增失败，邮箱已存在
            }
            var model = _mapper.Map<CreateUserRequest, User>(request);
            model.IsDelete = false;
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            await InsertAsync(model);
            var result = _mapper.Map<User, UserResponse>(model);
            return (true, "", result);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, UserResponse?)> UpdateUserAsync(UpdateUserRequest request)
        {
            if(!_fsql.Select<User>().Where(a => a.Id == request.Id).ToList().Any()) // 如果数据库没有这个用户Id
            {
                return (false, "User does not exist", null); // 修改失败，用户不存在
            }
            else if (_fsql.Select<User>() // 如果Account和其它未删除用户一样
                .Where(a => a.Id != request.Id)
                .Where(a => a.Account == request.Account)
                .Where(a => a.IsDelete == false)
                .ToList().Any())
            {
                return (false, "Account already exists", null); // 修改失败，账号已存在
            }
            else if (_fsql.Select<User>() // 如果Email和其它未删除用户一样
                .Where(a => a.Id != request.Id)
                .Where(a => a.Email == request.Email)
                .Where(a => a.IsDelete == false)
                .ToList().Any())
            {
                return (false, "Email already exists", null); // 修改失败，邮箱已存在
            }
            var model = _mapper.Map<UpdateUserRequest, User>(request);
            model.UpdateTime = DateTime.Now;
            await UpdateAsync(model);
            var result = _mapper.Map<User, UserResponse>(model);
            return (true, "", result);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string)> DeleteUserAsync(DeleteUserRequest request)
        {
            if (!request.UserIds.Any())
            {
                return (false, "用户Id为空，请填写有效用户Id");
            }
            var existingUserIds = await _fsql.Select<User>()
                .Where(a => request.UserIds.Contains(a.Id))
                .ToListAsync();
            var nonExistingUserIds = request.UserIds.Except(existingUserIds.Select(u => u.Id));
            if (nonExistingUserIds.Any())
            {
                return (false, $"删除失败，以下用户ID不存在: {string.Join(", ", nonExistingUserIds)}");
            }
            var affectedRows = await _fsql.Update<User>()
                .Set(a => a.IsDelete, true)
                .Where(a => request.UserIds.Contains(a.Id))
                .ExecuteAffrowsAsync();
            return affectedRows > 0? (true, "") : (false, "删除失败");
        }
    }
}
