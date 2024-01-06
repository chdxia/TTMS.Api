namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回参数;缺陷明细文件
    /// </summary>
    public class DefectDetailFileResponse
    {
        /// <summary>
        /// 缺陷明细文件id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 缺陷明细id
        /// </summary>
        public int DefectDetailId { get; set; }

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
