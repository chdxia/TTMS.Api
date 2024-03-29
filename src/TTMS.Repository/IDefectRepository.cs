﻿namespace TTMS.Repository
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
        /// 获取缺陷列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<DefectResponse>> GetDefectListAsync(DefectRequest request);

        /// <summary>
        /// 分页获取缺陷列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PageListDefectResponse> GetDefectPageListAsync(DefectRequest request);

        /// <summary>
        /// 新增缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DefectResponse> InsertDefectAsync(CreateDefectRequest request);

        /// <summary>
        /// 编辑缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DefectResponse> UpdateDefectAsync(UpdateDefectRequest request);
    }
}
