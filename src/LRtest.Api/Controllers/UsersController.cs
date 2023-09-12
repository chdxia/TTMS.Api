namespace LRtest.Api.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [ApiController]
    [Route("/api/v1/Users")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetPageList")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetPageList([FromBody] UserRequest request)
        {
            var result = await _repository.GetPageListAsync(request);
            return Ok(result);
        }

    }
}
