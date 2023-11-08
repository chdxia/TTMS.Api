namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 迭代版本
    /// </summary>
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
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<VersionInfoResponse>>))]
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
            var (ok, message, result) = await _versionInfoRepository.InsertVersionInfoAsync(request);
            return ok ? ToSuccessResult(result) : ToFailResult(message);
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
            var (ok, message, result) = await _versionInfoRepository.UpdateVersionInfoAsync(request);
            return ok ? ToSuccessResult(result) : ToFailResult(message);
        }

        /// <summary>
        /// 批量删除分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("DeleteVersionInfo")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> DeleteVersionInfoAsync([FromBody] DeleteVersionInfoRequest request)
        {
            var (ok, message) = await _versionInfoRepository.DeleteVersionInfoAsync(request);
            return ok ? ToSuccessResult(message) : ToFailResult(message);
        }
    }
}
