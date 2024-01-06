using Microsoft.AspNetCore.Http;

namespace TTMS.DTO.Request
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public class UploadFileRequest
    {
        /// <summary>
        /// 文件集合
        /// </summary>
        [Required(ErrorMessage = "File is required.")]
        public IFormFileCollection FileCollection { get; set; }
    }
}
