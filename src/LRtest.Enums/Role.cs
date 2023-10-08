using System.ComponentModel;

namespace LRtest.Enums
{
    /// <summary>
    /// 角色枚举
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        admin = 0,

        /// <summary>
        /// 开发者
        /// </summary>
        [Description("开发者")]
        development = 1,

        /// <summary>
        /// 测试
        /// </summary>
        [Description("测试")]
        tester = 2,

        /// <summary>
        /// 访客
        /// </summary>
        [Description("访客")]
        visitor = 3,
    }
}
