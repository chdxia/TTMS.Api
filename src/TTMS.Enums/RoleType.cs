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
        管理员 = 0,

        /// <summary>
        /// 总项目经理;总产品经理
        /// </summary>
        [Description("项目经理")]
        项目经理 = 1,

        /// <summary>
        /// 组长
        /// </summary>
        [Description("组长")]
        组长 = 2,

        /// <summary>
        /// 产品
        /// </summary>
        [Description("产品")]
        产品 = 3,

        /// <summary>
        /// 开发
        /// </summary>
        [Description("开发")]
        开发 = 4,

        /// <summary>
        /// 测试
        /// </summary>
        [Description("测试")]
        测试 = 5,

        /// <summary>
        /// 访客
        /// </summary>
        [Description("访客")]
        访客 = 6
    }
}
