namespace TTMS.Repository
{
    public interface IDefectDetailFileRepository : IBaseRepository<DefectDetailFile, long>
    {
        /// <summary>
        /// 根据缺陷明细id获取缺陷明细文件列表
        /// </summary>
        /// <param name="defectDetailId"></param>
        /// <returns></returns>
        Task<List<DefectDetailFileResponse>> GetDefectDetailFileListByDefectDetailIdAsync(int defectDetailId);

        /// <summary>
        /// 批量新增缺陷明细文件
        /// </summary>
        /// <param name="defectDetailId"></param>
        /// <param name="listUrl"></param>
        /// <returns></returns>
        Task<List<DefectDetailFileResponse>> InsertDefectDetailFileAsync(int defectDetailId, List<string> listUrl);

        /// <summary>
        /// 删除缺陷明细文件
        /// </summary>
        /// <param name="defectDetailFileId"></param>
        /// <returns></returns>
        Task DeleteDefectDetailFileAsync(int defectDetailFileId);
    }
}
