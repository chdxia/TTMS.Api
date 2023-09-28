namespace LRtest.Domain
{
    /// <summary>
    /// 任务表
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// 主键id;任务id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 是否删除;t已删除,f未删除
        /// </summary>
        [Column(Name = "is_delete", DbType = "bool")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Column(Name = "create_by", DbType = "int8")]
        public long CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Name = "create_time", DbType = "timestamp")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        [Column(Name = "update_by", DbType = "int8")]
        public long UpdateBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column(Name = "update_time", DbType = "timestamp")]
        public DateTime? UpdateTime { get; set; }
    }
}
