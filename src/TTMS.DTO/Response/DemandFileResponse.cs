namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回参数;需求文件
    /// </summary>
    public class DemandFileResponse
    {
        /// <summary>
        /// 需求文件id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 需求id
        /// </summary>
        public int DemandId { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
