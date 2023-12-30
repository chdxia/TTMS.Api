namespace TTMS.Domain
{
    /// <summary>
    /// 缺陷文件表
    /// </summary>
    [Table(Name = "defect_file")]
    public class DefectFile
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 外键;缺陷id
        /// </summary>
        [Column(Name = "defect_id", DbType = "int8")]
        [Navigate(nameof(Defect.Id))]
        public int DefectId { get; set; }

        /// <summary>
        /// url
        /// </summary>
        [Column(Name = "url", DbType = "varchar", IsNullable = true)]
        public string? Url { get; set; }

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
