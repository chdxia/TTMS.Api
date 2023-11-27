namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回参数;需求
    /// </summary>
    public class DemandResponse
    {
        /// <summary>
        /// 需求id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string? ModuleName { get; set; }

        /// <summary>
        /// 需求类型
        /// </summary>
        public DemandType DemandType { get; set; }

        /// <summary>
        /// 需求名称
        /// </summary>
        public string? DemandName { get; set; }

        /// <summary>
        /// 需求描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }

        /// <summary>
        /// 需求提出人
        /// </summary>
        public string? ProposerName { get; set; }

        /// <summary>
        /// 需求提出时间
        /// </summary>
        public DateTime ProposeTime { get; set; }

        /// <summary>
        /// 需求优先级
        /// </summary>
        public DemandPriority DemandPriority { get; set; }

        /// <summary>
        /// 开发
        /// </summary>
        public List<UserResponse> Developer { get; set; } = new List<UserResponse>();

        /// <summary>
        /// 测试
        /// </summary>
        public List<UserResponse> Tester { get; set; } = new List<UserResponse>();

        /// <summary>
        /// 需求状态
        /// </summary>
        public DemandState DemandState { get; set; }

        /// <summary>
        /// 预计工时
        /// </summary>
        public int? WorkHours { get; set; }

        /// <summary>
        /// 预计上线时间
        /// </summary>
        public DateTime? PlanOnlineTime { get; set; }

        /// <summary>
        /// 实际上线时间
        /// </summary>
        public DateTime? ActualOnlineTime { get; set; }

        /// <summary>
        /// 版本id
        /// </summary>
        public List<VersionInfoResponse> VersionIds { get; set; } = new List<VersionInfoResponse>();

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public int UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
