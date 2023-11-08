namespace TTMS.Repository
{
    public interface IVersionInfoRepository : IBaseRepository<VersionInfo, long>
    {
        /// <summary>
        /// 分页获取版本列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<VersionInfoResponse>> GetVersionInfoListAsync(VersionInfoRequest request);

        /// <summary>
        /// 新增版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, VersionInfoResponse?)> InsertVersionInfoAsync(CreateVersionInfoRequest request);

        /// <summary>
        /// 编辑版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, VersionInfoResponse?)> UpdateVersionInfoAsync(UpdateVersionInfoRequest request);

        /// <summary>
        /// 删除版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string)> DeleteVersionInfoAsync(DeleteVersionInfoRequest request);
    }
}
