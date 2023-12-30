namespace TTMS.Repository
{
    public interface IUserRepository : IBaseRepository<User, long>
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UserLoginResponse> UserLogin(UserLoginRequest request);

        /// <summary>
        /// 用户退出登录
        /// </summary>
        /// <returns></returns>
        Task UserLogout();

        /// <summary>
        /// 根据accessToken获取用户信息;用于获取并存储当前用户的身份信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<UserLoginResponse> GetUserByTokenAsync(string accessToken);

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
        Task<UserResponse> InsertUserAsync(CreateUserRequest request);

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UserResponse> UpdateUserAsync(UpdateUserRequest request);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task DeleteUserAsync(DeleteUserRequest request);
    }
}
