namespace TTMS.DTO.Request
{
    /// <summary>
    /// 请求参数;查询用户
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 账户名
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
        public RoleType? RoleId { get; set; }

        /// <summary>
        /// 账户状态
        /// </summary>
        public bool? State { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeStart { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeEnd { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public int? UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTimeStart { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTimeEnd { get; set; }
    }

    /// <summary>
    /// 请求参数;新建用户
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// 账户
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
        public RoleType RoleId { get; set; }

        /// <summary>
        /// 账户状态
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
        public int? Id { get; set; }
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
        public List<int> UserIds { get; set; } = new List<int>();
    }
}
