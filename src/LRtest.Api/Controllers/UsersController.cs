namespace LRtest.Api.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [ApiExplorerSettings(GroupName = "用户")]
    public class UsersController : BaseApiController
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
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<UserResponse>>))]
        public async Task<IActionResult> GetPageList([FromBody] UserRequest request)
        {
            var result = await _repository.GetPageListAsync(request);
            return ToSuccessResult(result);
        }

    }
}
