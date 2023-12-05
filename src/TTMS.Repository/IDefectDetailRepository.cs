namespace TTMS.Repository
{
    public interface IDefectDetailRepository : IBaseRepository<DefectDetail, long>
    {
        /// <summary>
        /// 根据缺陷id获取缺陷明细列表
        /// </summary>
        /// <param name="defectId"></param>
        /// <returns></returns>
        Task<List<DefectDetailResponse>> GetDefectDetailListByDefectIdAsync(int defectId);

        /// <summary>
        /// 新建缺陷明细
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, DefectDetailResponse?)> InsertDefectDetailAsync(CreateDefectDetailRequest request);
    }
}
