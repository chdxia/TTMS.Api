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
        致命 = 0,

        /// <summary>
        /// 严重
        /// </summary>
        [Description("严重")]
        严重 = 1,

        /// <summary>
        /// 一般
        /// </summary>
        [Description("一般")]
        一般 = 2,

        /// <summary>
        /// 轻微
        /// </summary>
        [Description("轻微")]
        轻微 = 3
    }
}
