namespace LRtest.Api.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [ApiExplorerSettings(GroupName = "用户")]
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="userRepository"></param>
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<UserResponse>))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userRepository.GetUserByIdAsync(id);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<UserResponse>>))]
        public async Task<IActionResult> GetListAsync([FromBody] UserRequest request)
        {
            var result = await _userRepository.GetUserListAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 分页获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetPageList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<UserResponse>>))]
        public async Task<IActionResult> GetPageListAsync([FromBody] UserRequest request)
        {
            var result = await _userRepository.GetUserPageListAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 新增/编辑用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<UserResponse>))]
        public async Task<IActionResult> CreateUserAsync([FromBody] UpdateUserRequest request)
        {
            var result = await _userRepository.UpdateUserAsync(request);
            return ToSuccessResult(result);
        }
        /*
        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUser")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> DeleteUserAsync([FromBody] DeleteUserRequest request)
        {
            _ = await;
            return ToSuccessResult();
        }*/
    }
}
