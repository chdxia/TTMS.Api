namespace TTMS.Domain
{
    /// <summary>
    /// 需求版本关联表
    /// </summary>
    [Table(Name = "demand_version_info")]
    public class DemandVersionInfo
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
        /// 外键;版本id
        /// </summary>
        [Column(Name = "version_info_id", DbType = "int8")]
        [Navigate(nameof(VersionInfo.Id))]
        public int VersionInfoId { get; set; }

        /// <summary>
        /// 是否删除;t已删除,f未删除;默认f
        /// </summary>
        [Column(Name = "is_delete", DbType = "bool")]
        public bool IsDelete { get; set; } = false;
    }
}
