namespace TTMS.Domain
{
    /// <summary>
    /// 缺陷明细表
    /// </summary>
    [Table(Name = "defect_detail")]
    public class DefectDetail
    {
        /// <summary>
        /// 主键id;缺陷明细id
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
        /// 缺陷明细描述
        /// </summary>
        [Column(Name = "description", DbType = "varchar", IsNullable = true)]
        public string? Description { get; set; }

        /// <summary>
        /// 修改前状态
        /// </summary>
        [Column(Name = "old_state", DbType = "int8")]
        public DefectState OldState { get; set; }

        /// <summary>
        /// 修改后状态
        /// </summary>
        [Column(Name = "new_state", DbType = "int8")]
        public DefectState NewState { get; set; }

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
    }
}
