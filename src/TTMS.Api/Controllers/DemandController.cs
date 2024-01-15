namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 需求池
    /// </summary>
    [Authorize]
    [ApiExplorerSettings(GroupName = "需求池")]
    public class DemandController : BaseApiController
    {
        private readonly IDemandRepository _demandRepository;
        private readonly IDemandFileRepository _demandFileRepository;
        private readonly IDemandService _demandService;
        private readonly IQiniuService _qiniuService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="demandRepository"></param>
        /// <param name="demandFileRepository"></param>
        /// <param name="demandService"></param>
        /// <param name="qiniuService"></param>
        public DemandController(
            IDemandRepository demandRepository,
            IDemandFileRepository demandFileRepository,
            IDemandService demandService,
            IQiniuService qiniuService)
        {
            _demandRepository = demandRepository;
            _demandFileRepository = demandFileRepository;
            _demandService = demandService;
            _qiniuService = qiniuService;
        }

        /// <summary>
        /// 根据id获取需求信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<DemandResponse>))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _demandRepository.GetDemandByIdAsync(id);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 分页获取需求池列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetPageList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<PageListDemandResponse>))]
        public async Task<IActionResult> GetPageListAsync([FromBody] DemandRequest request)
        {
            var result = await _demandRepository.GetDemandPageListAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 新增需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateDemand")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<DemandResponse>))]
        public async Task<IActionResult> CreateDemandAsync([FromBody] CreateDemandRequest request)
        {
            var result = await _demandService.CreateDemandAsync(request); 
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 编辑需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UpdateDemand")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<DemandResponse>))]
        public async Task<IActionResult> UpdateDemandAsync([FromBody] UpdateDemandRequest request)
        {
            var result = await _demandService.UpdateDemandAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 批量关联版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UpdateDemandVersionInfo")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> UpdateDemandVersionInfoAsync([FromBody] UpdateDemandVersionInfoRequest request)
        {
            await _demandRepository.UpdateDemandVersionInfoAsync(request);
            return ToSuccessResult();
        }

        /// <summary>
        /// 批量删除需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDemand")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> DeleteDemandAsync([FromBody] DeleteDemandRequest request)
        {
            await _demandRepository.DeleteDemandAsync(request);
            return ToSuccessResult();
        }

        /// <summary>
        /// 根据需求id获取需求文件列表
        /// </summary>
        /// <param name="demandId"></param>
        /// <returns></returns>
        [HttpGet("{demandId}/GetFileList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<DemandFileResponse>>))]
        public async Task<IActionResult> GetDemandFileListByDemandIdAsync(int demandId)
        {
            var result = await _demandFileRepository.GetDemandFileListByDemandIdAsync(demandId);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 批量上传需求文件
        /// </summary>
        /// <param name="demandId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{demandId}/UploadFile")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<DemandFileResponse>>))]
        public async Task<IActionResult> UploadDemandFileAsync(int demandId, UploadFileRequest request)
        {
            var uploadResult = await _qiniuService.UploadFileAsync(request);
            var result = await _demandFileRepository.InsertDemandFileAsync(demandId, uploadResult);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 删除需求文件
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteFile/{fileId}")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> DeleteDemandFileAsync(int fileId)
        {
            await _demandFileRepository.DeleteDemandFileAsync(fileId);
            return ToSuccessResult();
        }
    }
}
