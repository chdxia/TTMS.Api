namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回参数;分组
    /// </summary>
    public class GroupResponse
    {
        /// <summary>
        /// 分组id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 分组名
        /// </summary>
        public string? GroupName { get; set; }

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

    /// <summary>
    /// 返回分页数据;分组
    /// </summary>
    public class PageListGroupResponse : BasePageListResponse
    {
        /// <summary>
        /// Items
        /// </summary>
        public new List<GroupResponse> Items { get; set; } = new List<GroupResponse>();
    }
}
