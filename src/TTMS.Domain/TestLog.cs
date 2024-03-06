namespace TTMS.Domain
{
    /// <summary>
    /// 自动化测试日志记录表
    /// </summary>
    [Table(Name = "test_log")]
    public class TestLog
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }
    }
}
