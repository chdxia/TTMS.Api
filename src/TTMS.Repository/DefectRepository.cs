namespace TTMS.Repository
{
    public class DefectRepository : DefaultRepository<Defect, long>, IDefectRepository
    {
        private readonly IFreeSql _fsql;
        private readonly IMapper _mapper;

        public DefectRepository(IFreeSql fsql, IMapper mapper) : base(fsql)
        {
            _fsql = fsql;
            _mapper = mapper;
        }

        /// <summary>
        /// 根据id获取缺陷信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DefectResponse> GetDefectByIdAsync(int id)
        {
            return await _fsql.Select<Defect>().Where(a => a.Id == id).ToOneAsync<DefectResponse>();
        }

        /// <summary>
        /// 分页获取缺陷列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<DefectResponse>> GetDefectPageListAsync(DefectRequest request)
        {
            var defects = await _fsql.Select<Defect, Demand, DemandUser>()
                .LeftJoin(a => a.t1.DemandId == a.t2.Id)
                .LeftJoin(a => a.t2.Id == a.t3.DemandId)
                .Where(a => !a.t2.IsDelete)
                .WhereIf(request.Id.HasValue, a => a.t1.Id == request.Id)
                .WhereIf(request.GroupId.HasValue, a => a.t2.GroupId == request.GroupId)
                .WhereIf(!string.IsNullOrEmpty(request.ModuleName), a => a.t2.ModuleName == request.ModuleName)
                .WhereIf(!string.IsNullOrEmpty(request.DemandName), a => a.t2.DemandName == request.DemandName)
                .WhereIf(request.DeveloperId.HasValue, a => a.t3.UserId == request.DeveloperId && !a.t3.IsDelete)
                .WhereIf(request.TesterId.HasValue, a => a.t3.UserId == request.TesterId && !a.t3.IsDelete)
                .WhereIf(!string.IsNullOrEmpty(request.Title), a => a.t1.Title == request.Title)
                .WhereIf(request.DefectType.HasValue, a => a.t1.DefectType == request.DefectType)
                .WhereIf(request.DefectState.HasValue, a => a.t1.DefectState == request.DefectState)
                .WhereIf(request.CreateTimeStart.HasValue, a => a.t1.CreateTime >= request.CreateTimeStart)
                .WhereIf(request.CreateTimeEnd.HasValue, a => a.t1.CreateTime <= request.CreateTimeEnd)
                .WhereIf(request.CreateBy.HasValue, a => a.t1.CreateBy == request.CreateBy)
                .WhereIf(request.UpdateTimeStart.HasValue, a => a.t1.UpdateTime >= request.UpdateTimeStart)
                .WhereIf(request.UpdateTimeEnd.HasValue, a => a.t1.UpdateTime <= request.UpdateTimeEnd)
                .WhereIf(request.UpdateBy.HasValue, a => a.t1.UpdateBy == request.UpdateBy)
                .ToListAsync<DefectResponse>();
            return defects;
        }

        /// <summary>
        /// 新增缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, DefectResponse?)> InsertDefectAsync(CreateDefectRequest request)
        {
            var model = _mapper.Map<CreateDefectRequest, Defect>(request);
            model.DefectState = Enums.DefectState.待处理; // 新建均为待处理状态
            model.CreateTime = model.UpdateTime = DateTime.Now;
            try
            {
                await InsertAsync(model);
                var result = _mapper.Map<Defect, DefectResponse>(model);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        /// <summary>
        /// 编辑缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, DefectResponse?)> UpdateDefectAsync(UpdateDefectRequest request)
        {
            var model = await _fsql.Select<Defect>().Where(a => a.Id == request.Id).FirstAsync();
            if (model == null)
            {
                return (false, "Defect does not exist.", null);
            }
            _mapper.Map(request, model);
            model.UpdateTime = DateTime.Now;
            try
            {
                await UpdateAsync(model);
                var result = _mapper.Map<Defect, DefectResponse>(model);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
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

        /// <summary>
        /// 根据缺陷id获取缺陷明细列表
        /// </summary>
        /// <param name="defectId"></param>
        /// <returns></returns>
        public async Task<List<DefectDetailResponse>> GetDefectDetailListAsync(int defectId)
        {
            return await _fsql.Select<DefectDetail>().Where(a => a.DefectId == defectId).ToListAsync<DefectDetailResponse>();
        }
    }
}
