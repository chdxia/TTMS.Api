namespace TTMS.Repository
{
    public interface IDefectFileRepository : IBaseRepository<DefectFile, long>
    {
        /// <summary>
        /// 根据缺陷id获取缺陷文件列表
        /// </summary>
        /// <param name="defectId"></param>
        /// <returns></returns>
        Task<List<DefectFileResponse>> GetDefectFileListByDefectIdAsync(int defectId);

        /// <summary>
        /// 批量新增缺陷文件
        /// </summary>
        /// <param name="defectId"></param>
        /// <param name="listUrl"></param>
        /// <returns></returns>
        Task<(bool, string, List<DefectFileResponse>?)> InsertDefectFileAsync(int defectId, List<string> listUrl);

        /// <summary>
        /// 删除缺陷文件
        /// </summary>
        /// <param name="defectFileId"></param>
        /// <returns></returns>
        Task<(bool, string)> DeleteDefectFileAsync(int defectFileId);
    }
}
