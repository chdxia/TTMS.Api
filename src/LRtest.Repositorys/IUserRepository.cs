using LRtest.DTO.Request;
using LRtest.DTO.Response;

namespace LRtest.Repository
{
    public interface IUserRepository : IBaseRepository<User, long>
    {
        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserResponse> GetByIdAsync(int id);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<UserResponse>> GetListAsync(UserRequest request);

        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<UserResponse>> GetPageListAsync(UserRequest request);
    }
}
