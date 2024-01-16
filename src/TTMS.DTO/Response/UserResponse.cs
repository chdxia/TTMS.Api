namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回参数;用户
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }

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
        /// 分组id
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public RoleType RoleId { get; set; }

        /// <summary>
        /// 账户状态
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public int UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// 返回参数;用户登录
    /// </summary>
    public class UserLoginResponse : UserResponse
    {
        /// <summary>
        /// 账户token
        /// </summary>
        public string? AccessToken { get; set; }
    }

    /// <summary>
    /// 返回分页数据;用户
    /// </summary>
    public class PageListUserResponse : BasePageListResponse
    {
        /// <summary>
        /// Items
        /// </summary>
        public new List<UserResponse> Items { get; set; } = new List<UserResponse>();
    }
}
