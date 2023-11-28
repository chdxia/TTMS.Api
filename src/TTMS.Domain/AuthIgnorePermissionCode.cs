namespace TTMS.Domain
{
    /// <summary>
    /// 系统权限白名单
    /// </summary>
    public static class AuthIgnorePermissionCode
    {
        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        public const string Login = "LoginCode";

        /// <summary>
        /// 退出登录
        /// </summary>
        public const string Logout = "LogoutCode";
        #endregion
    }
}
