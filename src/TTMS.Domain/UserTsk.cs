namespace TTMS.Domain
{
    /// <summary>
    /// 用户任务表
    /// </summary>
    [Table(Name = "user_task")]
    public class UserTsk
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 外键;用户id
        /// </summary>
        [Column(Name = "user_id", DbType = "int8")]
        [Navigate(nameof(User.Id))]
        public int UserId { get; set; }

        /// <summary>
        /// 外键;任务id
        /// </summary>
        [Column(Name = "task_id", DbType = "int8")]
        [Navigate(nameof(Tsk.Id))]
        public int TaskId { get; set; }
    }
}
