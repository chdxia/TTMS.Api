using System.ComponentModel;

namespace TTMS.Enums
{
    /// <summary>
    /// 缺陷状态枚举
    /// </summary>
    public enum DefectState
    {
        /// <summary>
        /// 待处理
        /// </summary>
        [Description("待处理")]
        open = 0,

        /// <summary>
        /// 已拒绝
        /// </summary>
        [Description("已拒绝")]
        mior = 1,

        /// <summary>
        /// 已处理
        /// </summary>
        [Description("已处理")]
        resolved = 2,

        /// <summary>
        /// 待验收
        /// </summary>
        [Description("待验收")]
        major = 3,

        /// <summary>
        /// 通过
        /// </summary>
        [Description("通过")]
        minor = 4
    }
}
