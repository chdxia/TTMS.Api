namespace TTMS.DTO.Request
{
    /// <summary>
    /// 请求参数;新建需求文件
    /// </summary>
    public class CreateDemandFileRequest
    {
        /// <summary>
        /// 需求id
        /// </summary>
        [Required(ErrorMessage = "DemandId is required.")]
        public int DemandId { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string? Url { get; set; }
    }
}
