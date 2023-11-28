namespace TTMS.DTO.Request
{
    /// <summary>
    /// 请求参数;查询版本
    /// </summary>
    public class VersionInfoRequest
    {
        /// <summary>
        /// 版本id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 版本时间;版本开始时间&lt;版本时间&lt;版本结束时间
        /// </summary>
        public DateTime? VertionTime { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string? VersionNo { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// 版本状态
        /// </summary>
        public DemandState? VersionState { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeStart { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeEnd { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public int? UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTimeStart { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTimeEnd { get; set; }
    }

    /// <summary>
    /// 请求参数;新建版本
    /// </summary>
    public class CreateVersionInfoRequest
    {
        /// <summary>
        /// 版本开始时间;版本开始开发的时间
        /// </summary>
        [Required(ErrorMessage = "VersionTimeStart is required.")]
        public DateTime VersionTimeStart { get; set; }

        /// <summary>
        /// 版本结束时间;版本发布时间
        /// </summary>
        [Required(ErrorMessage = "VersionTimeEnd is required.")]
        public DateTime VersionTimeEnd { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string? VersionNo { get; set; }
    }

    /// <summary>
    /// 请求参数;编辑版本
    /// </summary>
    public class UpdateVersionInfoRequest : CreateVersionInfoRequest
    {
        /// <summary>
        /// 版本Id
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int? Id { get; set; }
    }

    /// <summary>
    /// 请求参数;批量删除版本
    /// </summary>
    public class DeleteVersionInfoRequest
    {
        /// <summary>
        /// 版本id;自动去重;允许id重复
        /// </summary>
        [Required(ErrorMessage = "VersionIds is required.")]
        public HashSet<int> VersionIds { get; set; } = new HashSet<int>();
    }
}
