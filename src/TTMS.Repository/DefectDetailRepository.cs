namespace TTMS.Repository
{
    public class DefectDetailRepository : DefaultRepository<DefectDetail, long>, IDefectDetailRepository
    {
        private readonly IFreeSql _fsql;
        private readonly IMapper _mapper;

        public DefectDetailRepository(IFreeSql fsql, IMapper mapper) : base(fsql)
        {
            _fsql = fsql;
            _mapper = mapper;
        }

        /// <summary>
        /// 根据缺陷id获取缺陷明细列表
        /// </summary>
        /// <param name="defectId"></param>
        /// <returns></returns>
        public async Task<List<DefectDetailResponse>> GetDefectDetailListByDefectIdAsync(int defectId)
        {
            return await _fsql.Select<DefectDetail>().Where(a => a.DefectId == defectId).ToListAsync<DefectDetailResponse>();
        }

        /// <summary>
        /// 新建缺陷明细
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, DefectDetailResponse?)> InsertDefectDetailAsync(CreateDefectDetailRequest request)
        {
            var model = _mapper.Map<CreateDefectDetailRequest, DefectDetail>(request);
            model.CreateTime = DateTime.Now;
            try
            {
                await _fsql.Insert<DefectDetail>().AppendData(model).ExecuteAffrowsAsync();
                var result = _mapper.Map<DefectDetail, DefectDetailResponse>(model);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
    }
}
