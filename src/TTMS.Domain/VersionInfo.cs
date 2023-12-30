namespace TTMS.Domain
{
    /// <summary>
    /// 版本表
    /// </summary>
    [Table(Name = "version_info")]
    public class VersionInfo
    {
        /// <summary>
        /// 主键id;版本id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 版本开始时间;版本开始开发的时间
        /// </summary>
        [Column(Name = "version_time_start", DbType = "timestamp")]
        public DateTime? VersionTimeStart { get; set; }

        /// <summary>
        /// 版本结束时间;版本发布时间
        /// </summary>
        [Column(Name = "version_time_end", DbType = "timestamp")]
        public DateTime? VersionTimeEnd { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [Column(Name = "version_no", DbType = "varchar", IsNullable = true)]
        public string? VersionNo { get; set; }

        /// <summary>
        /// 报告状态;t已生成,f未生成;默认f
        /// </summary>
        [Column(Name = "report_state", DbType = "bool")]
        public bool ReportState { get; set; } = false;

        /// <summary>
        /// 报告生成时间
        /// </summary>
        [Column(Name = "report_time", DbType = "timestamp", IsNullable = true)]
        public DateTime? ReportTime { get; set; }

        /// <summary>
        /// 报告附件
        /// </summary>
        [Column(Name = "report_file", DbType = "varchar", IsNullable = true)]
        public string? ReportFile { get; set; }

        /// <summary>
        /// 是否删除;t已删除,f未删除;默认f
        /// </summary>
        [Column(Name = "is_delete", DbType = "bool")]
        public bool IsDelete { get; set; } = false;

        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Name = "create_by", DbType = "int8")]
        public long CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Name = "create_time", DbType = "timestamp")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后更新人
        /// </summary>
        [Column(Name = "update_by", DbType = "int8")]
        public long UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Column(Name = "update_time", DbType = "timestamp")]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
