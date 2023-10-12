namespace LRtest.DTO.Request
{
    /// <summary>
    /// 请求参数;查询用户
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public long? Id { get; set; }

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

    /// <summary>
    /// 请求参数;新建用户
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "Account is required.")]
        public string? Account { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 用户邮箱
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string? PassWord { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        [Required(ErrorMessage = "RoleId is required.")]
        public Role RoleId { get; set; }

        /// <summary>
        /// 账号状态
        /// </summary>
        [Required(ErrorMessage = "State is required.")]
        public bool State { get; set; }
    }

    /// <summary>
    /// 请求参数;编辑用户
    /// </summary>
    public class UpdateUserRequest : CreateUserRequest
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public long? Id { get; set; }
    }

    /// <summary>
    /// 请求参数;批量删除用户
    /// </summary>
    public class DeleteUserRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        [Required(ErrorMessage = "UserIds is required.")]
        public List<long> UserIds { get; set; } = new List<long>();
    }
}
