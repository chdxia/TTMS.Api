namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 分组
    /// </summary>
    [ApiExplorerSettings(GroupName = "分组")]
    public class GroupController : BaseApiController
    {
        private readonly IGroupRepository _groupRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="groupRepository"></param>
        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        /// <summary>
        /// 分页获取分组列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetPageList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<GroupResponse>>))]
        public async Task<IActionResult> GetPageListAsync([FromBody] GroupRequest request)
        {
            var result = await _groupRepository.GetGroupPageListAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 新增分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateGroup")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<GroupResponse>))]
        public async Task<IActionResult> CreateGroupAsync([FromBody] CreateGroupRequest request)
        {
            var result = await _groupRepository.InsertGroupAsync(request); 
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 编辑分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UpdateGroup")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<GroupResponse>))]
        public async Task<IActionResult> UpdateGroupAsync([FromBody] UpdateGroupRequest request)
        {
            var result = await _groupRepository.UpdateGroupAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 批量删除分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("DeleteGroup")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> DeleteGroupAsync([FromBody] DeleteGroupRequest request)
        {
            await _groupRepository.DeleteGroupAsync(request);
            return ToSuccessResult();
        }
    }
}
