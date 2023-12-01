namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 缺陷
    /// </summary>
    [ApiExplorerSettings(GroupName = "缺陷")]
    public class DefectController : BaseApiController
    {
        private readonly IDefectRepository _defectRepository;
        private readonly IDefectService _defectService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="defectRepository"></param>
        /// <param name="defectService"></param>
        public DefectController(IDefectRepository defectRepository, IDefectService defectService)
        {
            _defectRepository = defectRepository;
            _defectService = defectService;
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
            var (ok, message, result) = await _defectRepository.InsertDefectAsync(request); 
            return ok ? ToSuccessResult(result) : ToFailResult(message);
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
            var (ok, message, result) = await _defectService.UpdateDefectAsync(request);
            return ok ? ToSuccessResult(result) : ToFailResult(message);
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
            var result = await _defectRepository.GetDefectDetailListAsync(defectId);
            return ToSuccessResult(result);
        }
    }
}
