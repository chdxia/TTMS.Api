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
        /// 修改UserDemand关联表
        /// </summary>
        /// <param name="demandId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        Task<(bool, string)> UpdateDemandUserAsync(int demandId, List<int> userIds);

        /// <summary>
        /// 根据需求批量关联版本;修改DemandVersionInfo关联表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string)> UpdateDemandVersionInfoAsync(UpdateDemandVersionInfoRequest request);

        /// <summary>
        /// 删除需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string)> DeleteDemandAsync(DeleteDemandRequest request);
    }
}
