using LRtest.DTO.Request;
using LRtest.DTO.Response;

namespace LRtest.Repositorys
{
    public interface IUserRepository : IBaseRepository<User, long>
    {
        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<UserReponse>> GetPageListAsync(UserRequest request);
    }
}