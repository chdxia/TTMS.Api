namespace TTMS.DTO.Request
{
    /// <summary>
    /// 请求参数;查询需求
    /// </summary>
    public class DemandRequest
    {
        /// <summary>
        /// 需求id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string? ModuleName { get; set; }

        /// <summary>
        /// 需求类型
        /// </summary>
        public DemandType? DemandType { get; set; }

        /// <summary>
        /// 需求名称
        /// </summary>
        public string? DemandName { get; set; }

        /// <summary>
        /// 需求提出人
        /// </summary>
        public string? ProposerName { get; set; }

        /// <summary>
        /// 需求提出时间
        /// </summary>
        public DateTime? ProposeTimeStart { get; set; }

        /// <summary>
        /// 需求提出时间
        /// </summary>
        public DateTime? ProposeTimeEnd { get; set; }

        /// <summary>
        /// 需求优先级
        /// </summary>
        public DemandPriority? DemandPriority { get; set; }

        /// <summary>
        /// 开发
        /// </summary>
        public int? DeveloperId { get; set; }

        /// <summary>
        /// 测试
        /// </summary>
        public int? TesterId { get; set; }

        /// <summary>
        /// 需求状态;多选
        /// </summary>
        public List<DemandState>? DemandState { get; set; }

        /// <summary>
        /// 预计上线时间
        /// </summary>
        public DateTime? PlanOnlineTimeStart { get; set; }

        /// <summary>
        /// 预计上线时间
        /// </summary>
        public DateTime? PlanOnlineTimeEnd { get; set; }

        /// <summary>
        /// 实际上线时间
        /// </summary>
        public DateTime? ActualOnlineTimeStart { get; set; }

        /// <summary>
        /// 实际上线时间
        /// </summary>
        public DateTime? ActualOnlineTimeEnd { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string? VersionNo { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeStart { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTimeEnd { get; set; }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public int? UpdateBy { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTimeStart { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? UpdateTimeEnd { get; set; }
    }

    /// <summary>
    /// 查询参数;新建需求
    /// </summary>
    public class CreateDemandRequest
    {
        /// <summary>
        /// 分组id
        /// </summary>
        [Required(ErrorMessage = "GroupId is required.")]
        public int GroupId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string? ModuleName { get; set; }

        /// <summary>
        /// 需求类型
        /// </summary>
        [Required(ErrorMessage = "DemandType is required.")]
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
        [Required(ErrorMessage = "ProposeTime is required.")]
        public DateTime ProposeTime { get; set; }

        /// <summary>
        /// 需求优先级;默认P3
        /// </summary>
        public DemandPriority DemandPriority { get; set; } = DemandPriority.P3;

        /// <summary>
        /// 开发
        /// </summary>
        public List<int> Developer { get; set; } = new List<int>();

        /// <summary>
        /// 测试
        /// </summary>
        public List<int> Tester { get; set; } = new List<int>();

        /// <summary>
        /// 预计工时
        /// </summary>
        public int? WorkHours { get; set; }

        /// <summary>
        /// 预计上线
        /// </summary>
        public DateTime? PlanOnlineTime { get; set; }

        /// <summary>
        /// 实际上线
        /// </summary>
        public DateTime? ActualOnlineTime { get; set; }

        /// <summary>
        /// 版本id
        /// </summary>
        public List<int> VersionInfoIds { get; set; } = new List<int>();
    }

    /// <summary>
    /// 请求参数;编辑需求
    /// </summary>
    public class UpdateDemandRequest : CreateDemandRequest
    {
        /// <summary>
        /// 需求Id
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// 需求状态
        /// </summary>
        public DemandState DemandState { get; set; }
    }

    /// <summary>
    /// 请求参数;根据需求批量关联版本
    /// </summary>
    public class UpdateDemandVersionInfoRequest
    {
        /// <summary>
        /// 需求id
        /// </summary>
        public List<int> DemandIds { get; set; } = new List<int>();

        /// <summary>
        /// 版本id
        /// </summary>
        public List<int> VersionInfoIds { get; set; } = new List<int>();
    }

    /// <summary>
    /// 请求参数;批量删除需求
    /// </summary>
    public class DeleteDemandRequest
    {
        /// <summary>
        /// 需求id
        /// </summary>
        [Required(ErrorMessage = "DemandIds is required.")]
        public List<int> DemandIds { get; set; } = new List<int>();
    }
}
