namespace LRtest.Repository
{
    public interface IUserRepository : IBaseRepository<User, long>
    {
        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResponse> GetUserByIdAsync(int id);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<UserResponse>> GetUserListAsync(UserRequest request);

        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<UserResponse>> GetUserPageListAsync(UserRequest request);

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, UserResponse?)> InsertUserAsync(CreateUserRequest request);

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, UserResponse?)> UpdateUserAsync(UpdateUserRequest request);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string)> DeleteUserAsync(DeleteUserRequest request);
    }
}
