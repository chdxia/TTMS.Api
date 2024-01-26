namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回参数;缺陷文件
    /// </summary>
    public class DefectFileResponse
    {
        /// <summary>
        /// 缺陷文件id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 缺陷id
        /// </summary>
        public int DefectId { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string? CreateByName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
