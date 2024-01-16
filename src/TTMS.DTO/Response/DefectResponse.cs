namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回参数;缺陷
    /// </summary>
    public class DefectResponse
    {
        /// <summary>
        /// 缺陷id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 需求id
        /// </summary>
        public int DemandId { get; set; }

        /// <summary>
        /// 缺陷标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 缺陷描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 严重程度
        /// </summary>
        public DefectType DefectType { get; set; }

        /// <summary>
        /// 缺陷状态
        /// </summary>
        public DefectState DefectState { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public int UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }

    /// <summary>
    /// 返回分页数据;缺陷
    /// </summary>
    public class PageListDefectResponse : BasePageListResponse
    {
        /// <summary>
        /// Items
        /// </summary>
        public new List<DefectResponse> Items { get; set; } = new List<DefectResponse>();
    }
}
