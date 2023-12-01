namespace TTMS.DTO.Request
{
    /// <summary>
    /// 请求参数;查询缺陷
    /// </summary>
    public class DefectRequest
    {
        /// <summary>
        /// 缺陷id
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
        /// 需求名称
        /// </summary>
        public string? DemandName { get; set; }

        /// <summary>
        /// 开发
        /// </summary>
        public int? DeveloperId { get; set; }

        /// <summary>
        /// 测试
        /// </summary>
        public int? TesterId { get; set; }

        /// <summary>
        /// 缺陷标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 严重程度
        /// </summary>
        public DefectType? DefectType { get; set; }

        /// <summary>
        /// 缺陷状态
        /// </summary>
        public DefectState? DefectState { get; set; }

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
    /// 请求参数;新建缺陷
    /// </summary>
    public class CreateDefectRequest
    {
        /// <summary>
        /// 需求id
        /// </summary>
        [Required(ErrorMessage = "DemandId is required.")]
        public int DemandId { get; set; }

        /// <summary>
        /// 缺陷标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 缺陷描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 严重程度
        /// </summary>
        [Required(ErrorMessage = "DefectType is required.")]
        public DefectType DefectType { get; set; }
    }

    /// <summary>
    /// 请求参数;编辑缺陷
    /// </summary>
    public class UpdateDefectRequest : CreateDefectRequest
    {
        /// <summary>
        /// 缺陷id
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// 缺陷状态
        /// </summary>
        [Required(ErrorMessage = "DefectState is required.")]
        public DefectState DefectState { get; set; }

        /// <summary>
        /// 缺陷状态修改描述
        /// </summary>
        public string? DefectDetailDescription { get; set; }
    }

    /// <summary>
    /// 请求参数;新建缺陷明细
    /// </summary>
    public class CreateDefectDetailRequest
    {
        /// <summary>
        /// 缺陷id
        /// </summary>
        [Required(ErrorMessage = "DefectId is required.")]
        public int DefectId { get; set; }

        /// <summary>
        /// 缺陷明细描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 修改前状态
        /// </summary>
        [Required(ErrorMessage = "OldState is required.")]
        public DefectState OldState { get; set; }

        /// <summary>
        /// 修改后状态
        /// </summary>
        [Required(ErrorMessage = "NewState is required.")]
        public DefectState NewState { get; set; }
    }
}
