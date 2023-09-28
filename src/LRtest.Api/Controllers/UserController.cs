namespace LRtest.Api.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [ApiExplorerSettings(GroupName = "用户")]
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="repository"></param>
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<UserResponse>))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<UserResponse>>))]
        public async Task<IActionResult> GetList([FromBody] UserRequest request)
        {
            var result = await _repository.GetListAsync(request);
            return ToSuccessResult(result);
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

        [HttpPost("")]
    }
}
