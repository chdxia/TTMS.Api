namespace TTMS.Repository
{
    public interface IVersionInfoRepository : IBaseRepository<VersionInfo, long>
    {
        /// <summary>
        /// 分页获取版本列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PageListVersionInfoResponse> GetVersionInfoPageListAsync(VersionInfoRequest request);

        /// <summary>
        /// 新增版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<VersionInfoResponse> InsertVersionInfoAsync(CreateVersionInfoRequest request);

        /// <summary>
        /// 编辑版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<VersionInfoResponse> UpdateVersionInfoAsync(UpdateVersionInfoRequest request);

        /// <summary>
        /// 删除版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task DeleteVersionInfoAsync(DeleteVersionInfoRequest request);
    }
}
