using FreeSql.DataAnnotations;
using LRtest.Enums;

namespace LRtest.Domain
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    [Table(Name = "user_role")]
    public class UserRole
    {
        /// <summary>
        /// 主键;id
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
        /// 角色id
        /// </summary>
        [Column(Name = "role_id", DbType = "int8")]
        public Role? RoleId { get; set; }
    }
}
