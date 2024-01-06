namespace TTMS.DTO.Request
{
    /// <summary>
    /// 请求参数;新建缺陷明细文件
    /// </summary>
    public class CreateDefectDetailFileRequest
    {
        /// <summary>
        /// 缺陷明细id
        /// </summary>
        [Required(ErrorMessage = "DefectDetailId is required.")]
        public int DefectDetailId { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string? Url { get; set; }
    }
}
