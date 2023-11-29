namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 需求池
    /// </summary>
    [ApiExplorerSettings(GroupName = "需求池")]
    public class DemandController : BaseApiController
    {
        private readonly IDemandRepository _demandRepository;
        private readonly IDemandService _demandService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="demandRepository"></param>
        /// <param name="demandService"></param>
        public DemandController(IDemandRepository demandRepository, IDemandService demandService)
        {
            _demandRepository = demandRepository;
            _demandService = demandService;
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
        [ProducesResponseType(200, Type = typeof(ApiResultModel<List<DemandResponse>>))]
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
            var (ok, message, result) = await _demandService.CreateDemandAsync(request); 
            return ok ? ToSuccessResult(result) : ToFailResult(message);
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
            var (ok, message, result) = await _demandService.UpdateDemandAsync(request);
            return ok ? ToSuccessResult(result) : ToFailResult(message);
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
            var (ok, message) = await _demandRepository.UpdateDemandVersionInfoAsync(request);
            return ok ? ToSuccessResult() : ToFailResult(message);
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
            var (ok, message) = await _demandService.DeleteDemandAsync(request);
            return ok ? ToSuccessResult(message) : ToFailResult(message);
        }
    }
}
