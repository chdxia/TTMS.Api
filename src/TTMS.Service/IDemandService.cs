namespace TTMS.Service
{
    public interface IDemandService
    {
        /// <summary>
        /// 新增需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DemandResponse> CreateDemandAsync(CreateDemandRequest request);

        /// <summary>
        /// 编辑需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DemandResponse> UpdateDemandAsync(UpdateDemandRequest request);
    }
}
