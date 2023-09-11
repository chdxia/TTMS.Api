using LRtest.DTO.Request;
using LRtest.DTO.Response;
using LRtest.Repositorys;

namespace LRtest.Api.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [ApiController]
    [Route("/api/v1/users")]
    public class UsersController : Controller
    {
        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPageList")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetPageList([] UserRequest request)
        {
            var result = await
            return View();
        }

    }
}
