namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 迭代版本
    /// </summary>
    [Authorize]
    [ApiExplorerSettings(GroupName = "迭代版本")]
    public class VersionInfoController : BaseApiController
    {
        private readonly IVersionInfoRepository _versionInfoRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="versionInfoRepository"></param>
        public VersionInfoController(IVersionInfoRepository versionInfoRepository)
        {
            _versionInfoRepository = versionInfoRepository;
        }

        /// <summary>
        /// 分页获取版本列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetPageList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<PageListVersionInfoResponse>))]
        public async Task<IActionResult> GetPageListAsync([FromBody] VersionInfoRequest request)
        {
            var result = await _versionInfoRepository.GetVersionInfoPageListAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 新增版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateVersionInfo")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<VersionInfoResponse>))]
        public async Task<IActionResult> CreateVersionInfoAsync([FromBody] CreateVersionInfoRequest request)
        {
            var result = await _versionInfoRepository.InsertVersionInfoAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 编辑版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UpdateVersionInfo")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<VersionInfoResponse>))]
        public async Task<IActionResult> UpdateVersionInfoAsync([FromBody] UpdateVersionInfoRequest request)
        {
            var result = await _versionInfoRepository.UpdateVersionInfoAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 批量删除版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("DeleteVersionInfo")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> DeleteVersionInfoAsync([FromBody] DeleteVersionInfoRequest request)
        {
            await _versionInfoRepository.DeleteVersionInfoAsync(request);
            return ToSuccessResult();
        }
    }
}
