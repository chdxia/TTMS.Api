using System.ComponentModel;

namespace TTMS.Enums
{
    /// <summary>
    /// 需求类型枚举
    /// </summary>
    public enum DemandType
    {
        /// <summary>
        /// 需求
        /// </summary>
        [Description("需求")]
        demand = 0,

        /// <summary>
        /// 缺陷
        /// </summary>
        [Description("缺陷")]
        bug = 1
    }
}
