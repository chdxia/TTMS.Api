namespace TTMS.DTO.Request
{
    /// <summary>
    /// 请求参数;新建缺陷文件
    /// </summary>
    public class CreateDefectFileRequest
    {
        /// <summary>
        /// 缺陷id
        /// </summary>
        [Required(ErrorMessage = "DefectId is required.")]
        public int DefectId { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string? Url { get; set; }
    }
}
