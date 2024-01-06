namespace TTMS.DTO.Request
{
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
