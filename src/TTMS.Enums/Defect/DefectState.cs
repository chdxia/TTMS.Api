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
        /// 待验收
        /// </summary>
        [Description("待验收")]
        testing = 3,

        /// <summary>
        /// 通过
        /// </summary>
        [Description("通过")]
        pass = 4,

        /// <summary>
        /// 已拒绝
        /// </summary>
        [Description("已拒绝")]
        rejected = 100,

        /// <summary>
        /// 挂起
        /// </summary>
        [Description("挂起")]
        hold = 200 
    }
}
