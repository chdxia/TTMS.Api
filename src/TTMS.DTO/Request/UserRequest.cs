namespace TTMS.DTO.Request
{
    /// <summary>
    /// 请求参数;用户登录
    /// </summary>
    public class UserLoginRequest
    {
        /// <summary>
        /// 账户名
        /// </summary>
        [Required(ErrorMessage = "Account is required.")]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "PassWord is required.")]
        public string PassWord { get; set; } = string.Empty;
    }

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
        /// 账户或用户名
        /// </summary>
        public string? AccountOrUserName { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public RoleType? RoleId { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool? IsDisable { get; set; }

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

        /// <summary>
        /// 当前索引页
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 页码大小
        /// </summary>
        public int PageSize { get; set; } = 20;
    }

    /// <summary>
    /// 请求参数;新建用户
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// 账户名
        /// </summary>
        [Required(ErrorMessage = "Account is required.")]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 分组id
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "PassWord is required.")]
        public string PassWord { get; set; } = string.Empty;

        /// <summary>
        /// 用户角色
        /// </summary>
        [Required(ErrorMessage = "RoleId is required.")]
        public RoleType RoleId { get; set; }

        /// <summary>
        /// 是否禁用;t禁用,f启用;默认f
        /// </summary>
        public bool IsDisable { get; set; } = false;
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
        public int Id { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [Required(ErrorMessage = "IsDisable is required.")]
        public new bool IsDisable { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public new string? PassWord { get; set; }
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
