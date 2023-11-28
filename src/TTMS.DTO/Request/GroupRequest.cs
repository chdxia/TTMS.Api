namespace TTMS.DTO.Request
{
    /// <summary>
    /// 请求参数;查询分组
    /// </summary>
    public class GroupRequest
    {
        /// <summary>
        /// 分组id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 分组名
        /// </summary>
        public string? GroupName { get; set; }

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
    /// 请求参数;新建分组
    /// </summary>
    public class CreateGroupRequest
    {
        /// <summary>
        /// 分组名
        /// </summary>
        public string GroupName { get; set; } = string.Empty;
    }

    /// <summary>
    /// 请求参数;编辑分组
    /// </summary>
    public class UpdateGroupRequest : CreateGroupRequest
    {
        /// <summary>
        /// 分组Id
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int? Id { get; set; }
    }

    /// <summary>
    /// 请求参数;批量删除分组
    /// </summary>
    public class DeleteGroupRequest
    {
        /// <summary>
        /// 分组id
        /// </summary>
        [Required(ErrorMessage = "GroupIds is required.")]
        public List<int> GroupIds { get; set; } = new List<int>();
    }
}
