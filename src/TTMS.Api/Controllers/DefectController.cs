namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 缺陷
    /// </summary>
    [ApiExplorerSettings(GroupName = "缺陷")]
    public class DefectController : BaseApiController
    {
        private readonly IDefectRepository _defectRepository;
        private readonly IDefectFileRepository _defectFileRepository;
        private readonly IDefectDetailRepository _defectDetailRepository;
        private readonly IDefectDetailFileRepository _defectDetailFileRepository;
        private readonly IDefectService _defectService;
        private readonly IQiniuService _qiniuService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="defectRepository"></param>
        /// <param name="defectFileRepository"></param>
        /// <param name="defectDetailRepository"></param>
        /// <param name="defectDetailFileRepository"></param>
        /// <param name="defectService"></param>
        /// <param name="qiniuService"></param>
        public DefectController(
            IDefectRepository defectRepository,
            IDefectFileRepository defectFileRepository,
            IDefectDetailRepository defectDetailRepository,
            IDefectDetailFileRepository defectDetailFileRepository,
            IDefectService defectService,
            IQiniuService qiniuService)
        {
            _defectRepository = defectRepository;
            _defectFileRepository = defectFileRepository;
            _defectDetailRepository = defectDetailRepository;
            _defectDetailFileRepository = defectDetailFileRepository;
            _defectService = defectService;
            _qiniuService = qiniuService;
        }

        /// <summary>
        /// 根据id获取缺陷信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<DefectResponse>))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _defectRepository.GetDefectByIdAsync(id);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 分页获取缺陷列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetPageList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<DefectResponse>>))]
        public async Task<IActionResult> GetPageListAsync([FromBody] DefectRequest request)
        {
            var result = await _defectRepository.GetDefectPageListAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 新增缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateDefect")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<DefectResponse>))]
        public async Task<IActionResult> CreateDefectAsync([FromBody] CreateDefectRequest request)
        {
            var result = await _defectRepository.InsertDefectAsync(request); 
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 编辑缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UpdateDefect")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<DefectResponse>))]
        public async Task<IActionResult> UpdateDefectAsync([FromBody] UpdateDefectRequest request)
        {
            var result = await _defectService.UpdateDefectAsync(request);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 根据缺陷id获取缺陷文件列表
        /// </summary>
        /// <param name="defectId"></param>
        /// <returns></returns>
        [HttpGet("{defectId}/GetFileList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<DefectFileResponse>>))]
        public async Task<IActionResult> GetDefectFileListByDefectIdAsync(int defectId)
        {
            var result = await _defectFileRepository.GetDefectFileListByDefectIdAsync(defectId);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 批量上传缺陷文件
        /// </summary>
        /// <param name="defectId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{defectId}/UploadFile")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<DefectFileResponse>>))]
        public async Task<IActionResult> UploadDefectFileAsync(int defectId, UploadFileRequest request)
        {
            var uploadResult = await _qiniuService.UploadFileAsync(request);
            var result = await _defectFileRepository.InsertDefectFileAsync(defectId, uploadResult);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 删除缺陷文件
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteFile/{fileId}")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> DeleteDefectFileAsync(int fileId)
        {
            await _defectFileRepository.DeleteDefectFileAsync(fileId);
            return ToSuccessResult();
        }

        /// <summary>
        /// 根据缺陷id获取缺陷明细列表
        /// </summary>
        /// <param name="defectId"></param>
        /// <returns></returns>
        [HttpGet("{defectId}/DefectDetail/GetList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<DefectDetailResponse>>))]
        public async Task<IActionResult> GetDefectDetailListAsync(int defectId)
        {
            var result = await _defectDetailRepository.GetDefectDetailListByDefectIdAsync(defectId);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 根据缺陷明细id获取缺陷明细文件列表
        /// </summary>
        /// <param name="defectDetailId"></param>
        /// <returns></returns>
        [HttpGet("DefectDetail/{defectDetailId}/GetFileList")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<DefectDetailFileResponse>>))]
        public async Task<IActionResult> GetDefectDetailFileListByDefectDetailIdAsync(int defectDetailId)
        {
            var result = await _defectDetailFileRepository.GetDefectDetailFileListByDefectDetailIdAsync(defectDetailId);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 批量上传缺陷明细文件
        /// </summary>
        /// <param name="defectDetailId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("DefectDetail/{defectDetailId}/UploadFile")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<DefectDetailFileResponse>>))]
        public async Task<IActionResult> UploadDefectDetailFileAsync(int defectDetailId, UploadFileRequest request)
        {
            var uploadResult = await _qiniuService.UploadFileAsync(request);
            var result = await _defectDetailFileRepository.InsertDefectDetailFileAsync(defectDetailId, uploadResult);
            return ToSuccessResult(result);
        }

        /// <summary>
        /// 删除缺陷明细文件
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpDelete("DefectDetail/DeleteFile/{fileId}")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> DeleteDefectDetailFileAsync(int fileId)
        {
            await _defectDetailFileRepository.DeleteDefectDetailFileAsync(fileId);
            return ToSuccessResult();
        }
    }
}
