namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 七牛
    /// </summary>
    [ApiExplorerSettings(GroupName = "七牛")]
    public class QiniuController : BaseApiController
    {
        private readonly QiniuService _qiniuServiece;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="qiniuServiece"></param>
        public QiniuController(QiniuService qiniuServiece)
        {
            _qiniuServiece = qiniuServiece;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("UploadFile")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> UploadFileAsync(UploadFileRequest request)
        {
            var result = await _qiniuServiece.UploadFileAsync(request);
            return ToSuccessResult(result);
        }
    }
}
