namespace TTMS.Api.Controllers
{
    /// <summary>
    /// 七牛
    /// </summary>
    [ApiExplorerSettings(GroupName = "七牛")]
    public class QiniuController : BaseApiController
    {
        private readonly UploadQiniuProvider _uploadQiniuProvider;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uploadQiniuProvider"></param>
        public QiniuController(UploadQiniuProvider uploadQiniuProvider)
        {
            _uploadQiniuProvider = uploadQiniuProvider;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost("UploadFile")]
        [ProducesResponseType(200, Type = typeof(ApiResultModel))]
        public async Task<IActionResult> UploadFileAsync(List<IFormFile> files)
        {
            var result = await _uploadQiniuProvider.UploadFileAsync(files);
            return ToSuccessResult(result);
        }
    }
}
