﻿namespace LRtest.DTO.Request
{
    /// <summary>
    /// 用户表请求参数
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string? PassWord { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public Role? RoleId { get; set; }

        /// <summary>
        /// 账号状态
        /// </summary>
        public bool? State { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeStart { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeEnd { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public long? UpdateBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTimeStart { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTimeEnd { get; set; }
    }
}
