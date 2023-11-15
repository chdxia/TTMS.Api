namespace TTMS.Repository
{
    public class DemandRepository : DefaultRepository<Demand, long>, IDemandRepository
    {
        private readonly IFreeSql _fsql;
        private readonly IMapper _mapper;

        public DemandRepository(IFreeSql fsql, IMapper mapper) : base(fsql)
        {
            _fsql = fsql;
            _mapper = mapper;
        }

        /// <summary>
        /// 分页获取需求列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<DemandResponse>> GetDemandPageListAsync(DemandRequest request)
        {
            var demands = await _fsql.Select<Demand, UserDemand, VersionInfo>()
                .LeftJoin(a => a.t1.Id == a.t2.DemandId)
                .LeftJoin(a => a.t1.VersionId == a.t3.Id)
                .Where(a => !a.t1.IsDelete)
                .WhereIf(request.Id.HasValue, a => a.t1.Id == request.Id)
                .WhereIf(request.GroupId.HasValue, a => a.t1.GroupId == request.GroupId)
                .WhereIf(!string.IsNullOrEmpty(request.ModuleName), a => a.t1.ModuleName.Contains(request.ModuleName))
                .WhereIf(request.DemandType.HasValue, a => a.t1.DemandType == request.DemandType)
                .WhereIf(!string.IsNullOrEmpty(request.DemandName), a => a.t1.DemandName.Contains(request.DemandName))
                .WhereIf(!string.IsNullOrEmpty(request.ProposerName), a => a.t1.ProposerName.Contains(request.ProposerName))
                .WhereIf(request.ProposeTimeStart.HasValue, a => a.t1.ProposeTime >= request.ProposeTimeStart)
                .WhereIf(request.ProposeTimeEnd.HasValue, a => a.t1.ProposeTime <= request.ProposeTimeEnd)
                .WhereIf(request.DemandPriority.HasValue, a => a.t1.DemandPriority == request.DemandPriority)
                .WhereIf(request.DeveloperId.HasValue, a => a.t2.UserId == request.DeveloperId && !a.t2.IsDelete)
                .WhereIf(request.TesterId.HasValue, a => a.t2.UserId == request.TesterId && !a.t2.IsDelete)
                .WhereIf(request.DemandState.HasValue, a => a.t1.DemandState == request.DemandState)
                .WhereIf(request.PlanOnlineTimeStart.HasValue, a => a.t1.PlanOnlineTime >= request.PlanOnlineTimeStart)
                .WhereIf(request.PlanOnlineTimeEnd.HasValue, a => a.t1.PlanOnlineTime <= request.PlanOnlineTimeEnd)
                .WhereIf(request.ActualOnlineTimeStart.HasValue, a => a.t1.ActualOnlineTime >= request.ActualOnlineTimeStart)
                .WhereIf(request.ActualOnlineTimeEnd.HasValue, a => a.t1.ActualOnlineTime <= request.ActualOnlineTimeEnd)
                .WhereIf(!string.IsNullOrEmpty(request.VersionNo), a => a.t3.VersionNo == request.VersionNo)
                .WhereIf(request.CreateTimeStart.HasValue, a => a.t1.CreateTime >= request.CreateTimeStart)
                .WhereIf(request.CreateTimeEnd.HasValue, a => a.t1.CreateTime <= request.CreateTimeEnd)
                .WhereIf(request.CreateBy.HasValue, a => a.t1.CreateBy == request.CreateBy)
                .WhereIf(request.UpdateTimeStart.HasValue, a => a.t1.UpdateTime >= request.UpdateTimeStart)
                .WhereIf(request.UpdateTimeEnd.HasValue, a => a.t1.UpdateTime <= request.UpdateTimeEnd)
                .WhereIf(request.UpdateBy.HasValue, a => a.t1.UpdateBy == request.UpdateBy)
                .ToListAsync<DemandResponse>();
            return demands;
        }

        /// <summary>
        /// 新增需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, DemandResponse?)> InsertDemandAsync(CreateDemandRequest request)
        {
            var model = _mapper.Map<CreateDemandRequest, Demand>(request);
            model.DemandState = Enums.DemandState.toBePlanned; //新建均为待规划状态
            model.CreateTime = model.UpdateTime = DateTime.Now;
            try
            {
                await InsertAsync(model);
                var result = _mapper.Map<Demand, DemandResponse>(model);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        /// <summary>
        /// 编辑需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, DemandResponse?)> UpdateDemandAsync(UpdateDemandRequest request)
        {
            var model = await _fsql.Select<Demand>().Where(a => a.Id == request.Id).FirstAsync();
            if (model == null)
            {
                return (false, "Demand does not exist.", null);
            }
            _mapper.Map(request, model);
            if (model.DemandType == Enums.DemandType.otherDemand && model.VersionId != null)
            {
                return (false, "非项目需求不允许关联版本", null);
            }
            model.UpdateTime = DateTime.Now;
            try
            {
                await UpdateAsync(model);
                var result = _mapper.Map<Demand, DemandResponse>(model);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        /// <summary>
        /// 批量关联版本
        /// </summary>
        /// <param name="versionId"></param>
        /// <param name="demandIds"></param>
        /// <returns></returns>
        public async Task<(bool, string)> UpdateDemandVersionAsync(UpdateDemandVersionRequest request)
        {
            var demands = await _fsql.Select<Demand>().Where(a => request.DemandIds.Contains(a.Id)).ToListAsync();
            foreach (var demand in demands)
            {
                if (demand.DemandType == Enums.DemandType.otherDemand)
                {
                    return (false, "非项目需求不允许关联版本");
                }
                demand.VersionId = request.VersionId;
            }
            var affectedRows = await _fsql.Update<Demand>().SetSource(demands).ExecuteAffrowsAsync();
            return (affectedRows > 0, "UpdateDemandVersionAsync completed.");
        }

        /// <summary>
        /// 修改UserDemand关联表
        /// </summary>
        /// <param name="demandId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public async Task<(bool, string)> UpdateUserDemandAsync(int demandId, List<int> userIds)
        {
            // 获取数据库中与demandId相关的所有UserDemand记录
            var existingUserDemands = await _fsql.Select<UserDemand>().Where(a => a.DemandId == demandId).ToListAsync();
            // 根据传入的userIds进行更新操作
            foreach (var userId in userIds)
            {
                var existingUserDemand = existingUserDemands.FirstOrDefault(a => a.UserId == userId);
                if (existingUserDemand != null)
                {
                    // 数据库中存在该记录将IsDelete设置为false
                    existingUserDemand.IsDelete = false;
                }
                else
                {
                    // 数据库中不存在该记录，创建新的UserDemand记录并设置IsDelete为false
                    var newUserDemand = new UserDemand
                    {
                        DemandId = demandId,
                        UserId = userId,
                        IsDelete = false
                    };
                    _fsql.Insert(newUserDemand).ExecuteAffrows();
                }
            }
            // 对于数据库中存在但传入值中没有的记录，将其IsDelete设置为true
            foreach (var existingUserDemand in existingUserDemands)
            {
                if (!userIds.Contains(existingUserDemand.UserId))
                {
                    existingUserDemand.IsDelete = true;
                }
            }
            var affectedRows = await _fsql.Update<UserDemand>().SetSource(existingUserDemands).ExecuteAffrowsAsync();
            return (true, "UpdateUserDemand completed.");
        }

        /// <summary>
        /// 批量删除需求
        /// </summary>
        /// <returns></returns>
        public async Task<(bool, string)> DeleteDemandAsync(DeleteDemandRequest request)
        {
            if (!request.DemandIds.Any())
            {
                return (false, "需求Id为空，请填写有效需求Id.");
            }
            var existingDemandIds = await _fsql.Select<Demand>()
                .Where(a => request.DemandIds.Contains(a.Id))
                .ToListAsync();
            var nonExistingDemandIds = request.DemandIds.Except(existingDemandIds.Select(a => a.Id));
            if (nonExistingDemandIds.Any())
            {
                return (false, $"删除失败，以下需求ID不存在: {string.Join(", ", nonExistingDemandIds)}.");
            }
            var affectedRows = await _fsql.Update<Demand>()
                .Set(a => a.IsDelete, true)
                .Set(a => a.UpdateTime, DateTime.Now)
                .Where(a => request.DemandIds.Contains(a.Id))
                .ExecuteAffrowsAsync();
            return affectedRows > 0 ? (true, "") : (false, "删除失败.");
        }
    }
}
