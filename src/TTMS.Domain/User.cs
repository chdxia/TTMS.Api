﻿namespace TTMS.Domain
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table(Name = "user")]
    public class User
    {
        /// <summary>
        /// 主键id;用户id
        /// </summary>
        [Column(Name = "id", DbType = "int8", IsPrimary = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 账户名;唯一
        /// </summary>
        [Column(Name = "account", DbType = "varchar")]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        [Column(Name = "user_name", DbType = "varchar", IsNullable = true)]
        public string? UserName { get; set; }

        /// <summary>
        /// 用户邮箱;唯一
        /// </summary>
        [Column(Name = "email", DbType = "varchar")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 用户密码
        /// </summary>
        [Column(Name = "password", DbType = "varchar")]
        public string PassWord { get; set; } = string.Empty;

        /// <summary>
        /// 盐值
        /// </summary>
        [Column(Name = "salt", DbType = "varchar")]
        public string Salt { get; set; } = string.Empty;

        /// <summary>
        /// 外键;分组id
        /// </summary>
        [Column(Name = "group_id", DbType = "int8")]
        [Navigate(nameof(Group.Id))]
        public int? GroupId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        [Column(Name = "role_type", DbType = "int8")]
        public RoleType RoleId { get; set; }

        /// <summary>
        /// 账户状态;t禁用,f启用
        /// </summary>
        [Column(Name = "is_disable", DbType = "bool")]
        public bool IsDisable { get; set; }

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
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
    }
}
