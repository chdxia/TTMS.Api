using System.ComponentModel;

namespace TTMS.Enums
{
    /// <summary>
    /// 角色枚举
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        admin = 0,

        /// <summary>
        /// ProjectManager;项目经理;ProductManager;产品经理
        /// </summary>
        [Description("项目经理")]
        pm = 1,

        /// <summary>
        /// GroupManager;组长
        /// </summary>
        [Description("组长")]
        gm = 2,

        /// <summary>
        /// 产品
        /// </summary>
        [Description("产品")]
        product = 3,

        /// <summary>
        /// 开发
        /// </summary>
        [Description("开发")]
        development = 4,

        /// <summary>
        /// 测试
        /// </summary>
        [Description("测试")]
        tester = 5,

        /// <summary>
        /// 访客
        /// </summary>
        [Description("访客")]
        visitor = 6
    }
}
