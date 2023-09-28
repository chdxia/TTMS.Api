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
        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var query = _fsql.Select<User>().Where(a => a.Id == id);
            var result = await query.ToOneAsync<UserResponse>();
            return result;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<UserResponse>> GetListAsync(UserRequest request)
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
        public async Task<List<UserResponse>> GetPageListAsync(UserRequest request)
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
        public async Task<long> InsertAsync(UserRequest request)
        {
            var model = _mapper.Map<UserRequest, User>(request);

            _ = await InsertAsync(model);
            return model.Id;
        }
    }
}
