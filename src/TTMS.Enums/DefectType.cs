using System.ComponentModel;

namespace TTMS.Enums
{
    /// <summary>
    /// 缺陷严重等级枚举
    /// </summary>
    public enum DefectType
    {
        /// <summary>
        /// 致命
        /// </summary>
        [Description("致命")]
        blocker = 0,

        /// <summary>
        /// 严重
        /// </summary>
        [Description("严重")]
        critical = 1,

        /// <summary>
        /// 一般
        /// </summary>
        [Description("一般")]
        major = 2,

        /// <summary>
        /// 轻微
        /// </summary>
        [Description("轻微")]
        minor = 3
    }
}
