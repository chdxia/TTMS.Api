namespace TTMS.Repository
{
    public interface IDefectRepository : IBaseRepository<Defect, long>
    {
        /// <summary>
        /// 根据id获取缺陷信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DefectResponse> GetDefectByIdAsync(int id);

        /// <summary>
        /// 分页获取缺陷列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<DefectResponse>> GetDefectPageListAsync(DefectRequest request);

        /// <summary>
        /// 新增缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, DefectResponse?)> InsertDefectAsync(CreateDefectRequest request);

        /// <summary>
        /// 编辑缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, DefectResponse?)> UpdateDefectAsync(UpdateDefectRequest request);

        /// <summary>
        /// 新建缺陷明细
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, DefectDetailResponse?)> InsertDefectDetailAsync(CreateDefectDetailRequest request);

        /// <summary>
        /// 根据缺陷id获取缺陷明细列表
        /// </summary>
        /// <param name="defectId"></param>
        /// <returns></returns>
        Task<List<DefectDetailResponse>> GetDefectDetailListAsync(int defectId);
    }
}
