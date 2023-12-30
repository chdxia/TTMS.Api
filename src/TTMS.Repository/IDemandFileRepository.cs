namespace TTMS.Repository
{
    public interface IDemandFileRepository : IBaseRepository<DemandFile, long>
    {
        /// <summary>
        /// 根据需求id获取需求文件列表
        /// </summary>
        /// <param name="demandId"></param>
        /// <returns></returns>
        Task<List<DemandFileResponse>> GetDemandFileListByDemandIdAsync(int demandId);

        /// <summary>
        /// 批量新增需求文件
        /// </summary>
        /// <param name="demandId"></param>
        /// <param name="listUrl"></param>
        /// <returns></returns>
        Task<List<DemandFileResponse>> InsertDemandFileAsync(int demandId, List<string> listUrl);

        /// <summary>
        /// 删除需求文件
        /// </summary>
        /// <param name="demandFileId"></param>
        /// <returns></returns>
        Task DeleteDemandFileAsync(int demandFileId);
    }
}
