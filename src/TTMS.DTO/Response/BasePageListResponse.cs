namespace TTMS.DTO.Response
{
    /// <summary>
    /// 返回分页数据基类
    /// </summary>
    public class BasePageListResponse
    {
        /// <summary>
        /// Items
        /// </summary>
        public List<int> Items { get; set; } = new List<int>();

        /// <summary>
        /// 当前索引页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页码大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalCount/PageSize);
            }
        }

        /// <summary>
        /// 总数据条数
        /// </summary>
        public long TotalCount { get; set; }
    }
}
