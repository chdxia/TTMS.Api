namespace TTMS.Domain
{
    /// <summary>
    /// 需求表
    /// </summary>
    [Table(Name = "demand")]
    public class Demand
    {
        /// <summary>
        /// 主键id;需求id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }
    }
}
