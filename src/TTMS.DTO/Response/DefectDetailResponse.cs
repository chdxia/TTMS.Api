namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回参数;缺陷明细
    /// </summary>
    public class DefectDetailResponse
    {
        /// <summary>
        /// 缺陷明细id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 缺陷id
        /// </summary>
        public int DefectId { get; set; }

        /// <summary>
        /// 缺陷明细描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 修改前状态
        /// </summary>
        public DefectState OldState { get; set; }

        /// <summary>
        /// 修改后状态
        /// </summary>
        public DefectState NewState { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string? CreateByName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
