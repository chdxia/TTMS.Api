using System.ComponentModel;

namespace TTMS.Enums
{
    /// <summary>
    /// 需求类型枚举
    /// </summary>
    public enum DemandType
    {
        /// <summary>
        /// 项目需求
        /// </summary>
        [Description("项目需求")]
        demand = 0,

        /// <summary>
        /// 项目缺陷
        /// </summary>
        [Description("项目缺陷")]
        bug = 1,

        /// <summary>
        /// 非项目需求
        /// </summary>
        [Description("非项目需求")]
        otherDemand = 2
    }
}
