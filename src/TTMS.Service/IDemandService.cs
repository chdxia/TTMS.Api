namespace TTMS.Service
{
    public interface IDemandService
    {
        /// <summary>
        /// 新增需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, DemandResponse?)> CreateDemandAsync(CreateDemandRequest request);

        /// <summary>
        /// 编辑需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, DemandResponse?)> UpdateDemandAsync(UpdateDemandRequest request);
    }
}
