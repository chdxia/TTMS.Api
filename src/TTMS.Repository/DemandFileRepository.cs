namespace TTMS.Repository
{
    public class DemandFileRepository : DefaultRepository<DemandFile, long>, IDemandFileRepository
    {
        private readonly IFreeSql _fsql;
        private readonly IMapper _mapper;

        public DemandFileRepository(IFreeSql fsql, IMapper mapper) : base(fsql)
        {
            _fsql = fsql;
            _mapper = mapper;
        }

        /// <summary>
        /// 根据需求id获取需求文件列表
        /// </summary>
        /// <param name="demandId"></param>
        /// <returns></returns>
        public async Task<List<DemandFileResponse>> GetDemandFileListByDemandIdAsync(int demandId)
        {
            return await _fsql.Select<DemandFile>().Where(a => !a.IsDelete).Where(a => a.DemandId == demandId).ToListAsync<DemandFileResponse>();
        }

        /// <summary>
        /// 批量新增需求文件
        /// </summary>
        /// <param name="demandId"></param>
        /// <param name="listUrl"></param>
        /// <returns></returns>
        public async Task<(bool, string, List<DemandFileResponse>?)> InsertDemandFileAsync(int demandId, List<string> listUrl)
        {
            var models = new List<DemandFile>();
            foreach (var url in listUrl)
            {
                var model = new DemandFile();
                model.DemandId = demandId;
                model.Url = url;
                model.CreateTime = model.UpdateTime = DateTime.Now;
                models.Add(model);
            }
            try
            {
                await InsertAsync(models);
                var result = _mapper.Map<List<DemandFile>, List<DemandFileResponse>>(models);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        /// <summary>
        /// 删除需求文件
        /// </summary>
        /// <param name="demandFileId"></param>
        /// <returns></returns>
        public async Task<(bool, string)> DeleteDemandFileAsync(int demandFileId)
        {
            var affectedRows = await _fsql.Update<DemandFile>()
                .Set(a => a.IsDelete, true)
                .Set(a => a.UpdateTime, DateTime.Now)
                .Where(a => a.Id == demandFileId)
                .ExecuteAffrowsAsync();
            return affectedRows > 0 ? (true, "") : (false, "文件不存在或已被删除.");
        }
    }
}
