namespace TTMS.Domain
{
    /// <summary>
    /// 需求文件表
    /// </summary>
    [Table(Name = "demand_file")]
    public class DemandFile
    {
        /// <summary>
        /// 主键id
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
        /// url
        /// </summary>
        [Column(Name = "url", DbType = "varchar", IsNullable = true)]
        public string? Url { get; set; }

        /// <summary>
        /// 是否删除;t已删除,f未删除
        /// </summary>
        [Column(Name = "is_delete", DbType = "bool")]
        public bool IsDelete { get; set; }

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
