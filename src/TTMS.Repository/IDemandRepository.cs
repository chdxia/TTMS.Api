namespace TTMS.Repository
{
    public interface IDemandRepository : IBaseRepository<Demand, long>
    {
        /// <summary>
        /// 分页获取需求列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<DemandResponse>> GetDemandPageListAsync(DemandRequest request);

        /// <summary>
        /// 新增需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, DemandResponse?)> InsertDemandAsync(CreateDemandRequest request);

        /// <summary>
        /// 编辑需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, DemandResponse?)> UpdateDemandAsync(UpdateDemandRequest request);

        /// <summary>
        /// 批量关联版本
        /// </summary>
        /// <param name="versionId"></param>
        /// <param name="demandIds"></param>
        /// <returns></returns>
        Task<(bool, string)> UpdateDemandVersionAsync(UpdateDemandVersionRequest request);

        /// <summary>
        /// 修改UserDemand关联表
        /// </summary>
        /// <param name="demandId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        Task<(bool, string)> UpdateUserDemandAsync(int demandId, List<int> userIds);

        /// <summary>
        /// 删除需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string)> DeleteDemandAsync(DeleteDemandRequest request);
    }
}
