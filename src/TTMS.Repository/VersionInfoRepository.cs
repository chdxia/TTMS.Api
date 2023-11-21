﻿namespace TTMS.Repository
{
    public class VersionInfoRepository : DefaultRepository<VersionInfo, long>, IVersionInfoRepository
    {
        private readonly IFreeSql _fsql;
        private readonly IMapper _mapper;

        public VersionInfoRepository(IFreeSql fsql, IMapper mapper) : base(fsql)
        {
            _fsql = fsql;
            _mapper = mapper;
        }

        /// <summary>
        /// 分页获取版本列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<VersionInfoResponse>> GetVersionInfoPageListAsync(VersionInfoRequest request)
        {
            var versions = await _fsql.Select<VersionInfo>()
                .Where(a => !a.IsDelete)
                .WhereIf(request.Id.HasValue, a => a.Id == request.Id)
                .WhereIf(request.VertionTime.HasValue, a => a.VersionTimeStart <= request.VertionTime)
                .WhereIf(request.VertionTime.HasValue, a => request.VertionTime <= a.VersionTimeEnd)
                .WhereIf(!string.IsNullOrEmpty(request.VersionNo), a =>  a.VersionNo.Contains(request.VersionNo))
                .WhereIf(request.CreateTimeStart.HasValue, a => a.CreateTime >= request.CreateTimeStart)
                .WhereIf(request.CreateTimeEnd.HasValue, a => a.CreateTime <= request.CreateTimeEnd)
                .WhereIf(request.CreateBy.HasValue, a => a.CreateBy == request.CreateBy)
                .WhereIf(request.UpdateTimeStart.HasValue, a => a.UpdateTime >= request.UpdateTimeStart)
                .WhereIf(request.UpdateTimeEnd.HasValue, a => a.UpdateTime <= request.UpdateTimeEnd)
                .WhereIf(request.UpdateBy.HasValue, a => a.UpdateBy == request.UpdateBy)
                .ToListAsync();
            var groups = await _fsql.Select<UserGroup>().WhereIf(request.GroupId.HasValue, a => a.Id == request.GroupId).ToListAsync();
            var versionInfoList = new List<VersionInfoResponse>();
            foreach (var version in versions)
            {
                foreach (var group in groups)
                {
                    var versionInfoResponse = _mapper.Map<VersionInfo, VersionInfoResponse>(version);
                    versionInfoResponse.GroupId = group.Id;
                    var demands = await _fsql.Select<Demand>().Where(a => a.GroupId == group.Id && a.VersionId == version.Id).ToListAsync();
                    versionInfoResponse.Demands = _mapper.Map<List<Demand>, List<DemandResponse>>(demands);
                    versionInfoList.Add(versionInfoResponse);
                }
            }
            return versionInfoList;
        }

        /// <summary>
        /// 新增版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, VersionInfoResponse?)> InsertVersionInfoAsync(CreateVersionInfoRequest request)
        {
            var model = _mapper.Map<CreateVersionInfoRequest, VersionInfo>(request);
            model.CreateTime = model.UpdateTime = DateTime.Now;
            try
            {
                await InsertAsync(model);
                var result = _mapper.Map<VersionInfo, VersionInfoResponse>(model);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        /// <summary>
        /// 编辑版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, VersionInfoResponse?)> UpdateVersionInfoAsync(UpdateVersionInfoRequest request)
        {
            var model = await _fsql.Select<VersionInfo>().Where(a => a.Id == request.Id).FirstAsync();
            if (model == null)
            {
                return (false, "Group does not exist.", null);
            }
            _mapper.Map(request, model);
            model.UpdateTime = DateTime.Now;
            try
            {
                await UpdateAsync(model);
                var result = _mapper.Map<VersionInfo, VersionInfoResponse>(model);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        /// <summary>
        /// 删除版本
        /// </summary>
        /// <returns></returns>
        public async Task<(bool, string)> DeleteVersionInfoAsync(DeleteVersionInfoRequest request)
        {
            if (!request.VersionIds.Any())
            {
                return (false, "版本Id为空，请填写有效版本Id.");
            }
            var existingGroupIds = await _fsql.Select<VersionInfo>()
                .Where(a => request.VersionIds.Contains(a.Id))
                .ToListAsync();
            var nonExistingGroupIds = request.VersionIds.Except(existingGroupIds.Select(a => a.Id));
            if (nonExistingGroupIds.Any())
            {
                return (false, $"删除失败，以下版本ID不存在: {string.Join(", ", nonExistingGroupIds)}.");
            }
            var affectedRows = await _fsql.Update<VersionInfo>()
                .Set(a => a.IsDelete, true)
                .Set(a => a.UpdateTime, DateTime.Now)
                .Where(a => request.VersionIds.Contains(a.Id))
                .ExecuteAffrowsAsync();
            return affectedRows > 0 ? (true, "") : (false, "删除失败.");
        }
    }
}
