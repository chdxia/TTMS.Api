namespace TTMS.Domain
{
    /// <summary>
    /// 需求负责人表
    /// </summary>
    [Table(Name = "user_demand")]
    public class UserDemand
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
        /// 外键;需求id
        /// </summary>
        [Column(Name = "demand_id", DbType = "int8")]
        [Navigate(nameof(Demand.Id))]
        public int DemandId { get; set; }
    }
}
