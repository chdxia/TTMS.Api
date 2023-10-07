using System.ComponentModel;

namespace LRtest.Enum
{
    /// <summary>
    /// 角色枚举
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// admin
        /// </summary>
        [Description("admin")]
        admin = 0,

        /// <summary>
        /// development
        /// </summary>
        [Description("development")]
        development = 1,

        /// <summary>
        /// tester
        /// </summary>
        [Description("tester")]
        tester = 2,

        /// <summary>
        /// visitor
        /// </summary>
        [Description("visitor")]
        visitor = 3,
    }
}
