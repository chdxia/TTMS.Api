namespace TTMS.Domain
{
    /// <summary>
    /// 需求缺陷表
    /// </summary>
    [Table(Name = "defect")]
    public class Defect
    {
        /// <summary>
        /// 主键id;缺陷id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 外键;需求id
        /// </summary>
        [Column(Name = "demand_id", DbType = "int8")]
        [Navigate(nameof(Demand.Id))]
        public int DemandId { get; set; }

        /// <summary>
        /// 缺陷标题
        /// </summary>
        [Column(Name = "title", DbType = "varchar", IsNullable = true)]
        public string? Title { get; set; }

        /// <summary>
        /// 缺陷描述
        /// </summary>
        [Column(Name = "description", DbType = "varchar", IsNullable = true)]
        public string? Description { get; set; }

        /// <summary>
        /// 严重程度
        /// </summary>
        [Column(Name = "defect_type", DbType = "int8")]
        public DefectType DefectType { get; set; }

        /// <summary>
        /// 缺陷状态
        /// </summary>
        [Column(Name = "defect_state", DbType = "int8")]
        public DefectState DefectState { get; set; } = DefectState.待处理;

        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Name = "create_by", DbType = "int8")]
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Name = "create_time", DbType = "timestamp")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 最后更新人
        /// </summary>
        [Column(Name = "update_by", DbType = "int8")]
        public int UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Column(Name = "update_time", DbType = "timestamp")]
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
