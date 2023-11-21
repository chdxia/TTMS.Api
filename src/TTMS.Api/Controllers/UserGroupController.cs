namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 用户分组
    /// </summary>
    [ApiExplorerSettings(GroupName = "用户分组")]
    public class UserGroupController : BaseApiController
    {
        private readonly IUserGroupRepository _userGroupRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userGroupRepository"></param>
        public UserGroupController(IUserGroupRepository userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        /// <summary>
        /// 分页获取分组列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetPageList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<UserGroupResponse>>))]
        public async Task<IActionResult> GetPageListAsync([FromBody] UserGroupRequest request)
        {
            var result = await _userGroupRepository.GetUserGroupPageListAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 新增分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateUserGroup")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<UserGroupResponse>))]
        public async Task<IActionResult> CreateUserGroupAsync([FromBody] CreateUserGroupRequest request)
        {
            var (ok, message, result) = await _userGroupRepository.InsertUserGroupAsync(request); 
            return ok ? ToSuccessResult(result) : ToFailResult(message);
        }

        /// <summary>
        /// 编辑分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UpdateUserGroup")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<UserGroupResponse>))]
        public async Task<IActionResult> UpdateUserGroupAsync([FromBody] UpdateUserGroupRequest request)
        {
            var (ok, message, result) = await _userGroupRepository.UpdateUserGroupAsync(request);
            return ok ? ToSuccessResult(result) : ToFailResult(message);
        }

        /// <summary>
        /// 批量删除分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUserGroup")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> DeleteUserGroupAsync([FromBody] DeleteUserGroupRequest request)
        {
            var (ok, message) = await _userGroupRepository.DeleteUserGroupAsync(request);
            return ok ? ToSuccessResult(message) : ToFailResult(message);
        }
    }
}
