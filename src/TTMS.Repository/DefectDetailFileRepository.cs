namespace TTMS.Repository
{
    public class DefectDetailFileRepository : DefaultRepository<DefectDetailFile, long>, IDefectDetailFileRepository
    {
        private readonly IFreeSql _fsql;
        private readonly IMapper _mapper;

        public DefectDetailFileRepository(IFreeSql fsql, IMapper mapper) : base(fsql)
        {
            _fsql = fsql;
            _mapper = mapper;
        }

        /// <summary>
        /// 根据缺陷明细id获取缺陷明细文件列表
        /// </summary>
        /// <param name="defectDetailId"></param>
        /// <returns></returns>
        public async Task<List<DefectDetailFileResponse>> GetDefectDetailFileListByDefectDetailIdAsync(int defectDetailId)
        {
            return await _fsql.Select<DefectDetailFile>().Where(a => !a.IsDelete).Where(a => a.DefectDetailId == defectDetailId).ToListAsync<DefectDetailFileResponse>();
        }

        /// <summary>
        /// 批量新增缺陷明细文件
        /// </summary>
        /// <param name="defectDetailId"></param>
        /// <param name="listUrl"></param>
        /// <returns></returns>
        public async Task<(bool, string, List<DefectDetailFileResponse>?)> InsertDefectDetailFileAsync(int defectDetailId, List<string> listUrl)
        {
            var models = new List<DefectDetailFile>();
            foreach (var url in listUrl)
            {
                var model = new DefectDetailFile();
                model.DefectDetailId = defectDetailId;
                model.Url = url;
                model.CreateTime = model.UpdateTime = DateTime.Now;
                models.Add(model);
            }
            try
            {
                await InsertAsync(models);
                var result = _mapper.Map<List<DefectDetailFile>, List<DefectDetailFileResponse>>(models);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        /// <summary>
        /// 删除缺陷明细文件
        /// </summary>
        /// <param name="defectDetailFileId"></param>
        /// <returns></returns>
        public async Task<(bool, string)> DeleteDefectDetailFileAsync(int defectDetailFileId)
        {
            var affectedRows = await _fsql.Update<DefectDetailFile>()
                .Set(a => a.IsDelete, true)
                .Set(a => a.UpdateTime, DateTime.Now)
                .Where(a => a.Id == defectDetailFileId)
                .ExecuteAffrowsAsync();
            return affectedRows > 0 ? (true, "") : (false, "文件不存在或已被删除.");
        }
    }
}
