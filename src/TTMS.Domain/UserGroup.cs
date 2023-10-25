namespace TTMS.Domain
{
    /// <summary>
    /// 分组表
    /// </summary>
    [Table(Name = "group")]
    public class UserGroup
    {
        /// <summary>
        /// 主键id;分组id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 分组名
        /// </summary>
        [Column(Name = "group_name", DbType = "varchar", IsNullable = true)]
        public string? GroupName { get; set; }

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
        /// 更新人
        /// </summary>
        [Column(Name = "update_by", DbType = "int8")]
        public int UpdateBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column(Name = "update_time", DbType = "timestamp")]
        public DateTime? UpdateTime { get; set; }
    }
}
