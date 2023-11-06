namespace TTMS.Domain
{
    /// <summary>
    /// 自动化测试记录表
    /// </summary>
    [Table(Name = "auto_test")]
    public class AutoTest
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }
    }
}
