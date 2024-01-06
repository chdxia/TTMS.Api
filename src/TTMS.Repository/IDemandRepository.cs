namespace TTMS.Repository
{
    public interface IDemandRepository : IBaseRepository<Demand, long>
    {
        /// <summary>
        /// 根据id获取需求信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DemandResponse> GetDemandByIdAsync(int id);

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
        Task<DemandResponse> InsertDemandAsync(CreateDemandRequest request);

        /// <summary>
        /// 编辑需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DemandResponse> UpdateDemandAsync(UpdateDemandRequest request);

        /// <summary>
        /// 修改UserDemand关联表
        /// </summary>
        /// <param name="demandId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        Task UpdateDemandUserAsync(int demandId, List<int> userIds);

        /// <summary>
        /// 根据需求批量关联版本;修改DemandVersionInfo关联表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UpdateDemandVersionInfoAsync(UpdateDemandVersionInfoRequest request);

        /// <summary>
        /// 删除需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task DeleteDemandAsync(DeleteDemandRequest request);
    }
}
