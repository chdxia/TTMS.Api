namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回参数;版本
    /// </summary>
    public class VersionInfoResponse
    {
        /// <summary>
        /// 版本id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 版本开始时间;版本开始开发的时间
        /// </summary>
        public DateTime VersionTimeStart { get; set; }

        /// <summary>
        /// 版本结束时间;版本发布时间
        /// </summary>
        public DateTime VersionTimeEnd { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string? VersionNo { get; set; }

        /// <summary>
        /// 版本状态;任务未完成;任务已完成
        /// </summary>
        public string VersionState { get; set; } = "任务已完成";

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public int UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// 返回分页数据;版本
    /// </summary>
    public class PageListVersionInfoResponse : BasePageListResponse
    {
        /// <summary>
        /// Items
        /// </summary>
        public new List<VersionInfoResponse> Items { get; set; } = new List<VersionInfoResponse>();
    }
}
