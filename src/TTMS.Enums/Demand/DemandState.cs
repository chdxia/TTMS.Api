using System.ComponentModel;

namespace TTMS.Enums
{
    /// <summary>
    /// 需求状态枚举
    /// </summary>
    public enum DemandState
    {
        /// <summary>
        /// 待规划
        /// </summary>
        [Description("待规划")]
        待规划 = 0,

        /// <summary>
        /// 开发中
        /// </summary>
        [Description("开发中")]
        开发中 = 1,

        /// <summary>
        /// 测试中
        /// </summary>
        [Description("测试中")]
        测试中 = 2,

        /// <summary>
        /// 验收通过
        /// </summary>
        [Description("验收通过")]
        验收通过 = 3,

        /// <summary>
        /// 已上线
        /// </summary>
        [Description("已上线")]
        已上线 = 4,

        /// <summary>
        /// 已拒绝
        /// </summary>
        [Description("已拒绝")]
        已拒绝 = 100,

        /// <summary>
        /// 暂不处理
        /// </summary>
        [Description("暂不处理")]
        暂不处理 = 200,
    }
}
