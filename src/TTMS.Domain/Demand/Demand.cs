namespace TTMS.Domain
{
    /// <summary>
    /// 需求表
    /// </summary>
    [Table(Name = "demand")]
    public class Demand
    {
        /// <summary>
        /// 主键id;需求id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 外键;分组id
        /// </summary>
        [Column(Name = "group_id", DbType = "int8")]
        [Navigate(nameof(Group.Id))]
        public int GroupId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        [Column(Name = "module_name", DbType = "varchar", IsNullable = true)]
        public string? ModuleName { get; set; }

        /// <summary>
        /// 需求类型
        /// </summary>
        [Column(Name = "demand_type", DbType = "int8")]
        public DemandType DemandType { get; set; }

        /// <summary>
        /// 需求名称
        /// </summary>
        [Column(Name = "demand_name", DbType = "varchar", IsNullable = true)]
        public string? DemandName { get; set; }

        /// <summary>
        /// 需求描述
        /// </summary>
        [Column(Name = "description", DbType = "varchar", IsNullable = true)]
        public string? Description { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column(Name = "remark", DbType = "varchar", IsNullable = true)]
        public string? Remark { get; set; }

        /// <summary>
        /// 需求提出人
        /// </summary>
        [Column(Name = "proposer_name", DbType = "varchar", IsNullable = true)]
        public string? ProposerName { get; set; }

        /// <summary>
        /// 需求提出时间
        /// </summary>
        [Column(Name = "propose_time", DbType = "timestamp")]
        public DateTime? ProposeTime { get; set; }

        /// <summary>
        /// 需求优先级
        /// </summary>
        [Column(Name = "demand_priority", DbType = "int8")]
        public DemandPriority DemandPriority { get; set; }

        /// <summary>
        /// 需求状态
        /// </summary>
        [Column(Name = "demand_state", DbType = "int8")]
        public DemandState DemandState { get; set; }

        /// <summary>
        /// 预计工时
        /// </summary>
        [Column(Name = "work_hours", DbType = "int8")]
        public int? WorkHours { get; set; }

        /// <summary>
        /// 预计上线时间
        /// </summary>
        [Column(Name = "plan_online_time", DbType = "timestamp")]
        public DateTime? PlanOnlineTime { get; set; }

        /// <summary>
        /// 实际上线时间
        /// </summary>
        [Column(Name = "actual_online_time", DbType = "timestamp")]
        public DateTime? ActualOnlineTime { get; set; }

        /// <summary>
        /// 外键;版本id
        /// </summary>
        [Column(Name = "version_id", DbType = "int8")]
        [Navigate(nameof(VersionInfo.Id))]
        public int? VersionId { get; set; }

        /// <summary>
        /// 是否删除;t已删除,f未删除;默认f
        /// </summary>
        [Column(Name = "is_delete", DbType = "bool")]
        public bool IsDelete { get; set; } = false;

        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Name = "create_by", DbType = "int8")]
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Name = "create_time", DbType = "timestamp")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        [Column(Name = "update_by", DbType = "int8")]
        public int UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Column(Name = "update_time", DbType = "timestamp")]
        public DateTime? UpdateTime { get; set; }
    }
}
