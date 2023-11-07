namespace TTMS.Repository
{
    public class GroupRepository : DefaultRepository<Group, long>, IGroupRepository
    {
        private readonly IFreeSql _fsql;
        private readonly IMapper _mapper;

        public GroupRepository(IFreeSql fsql, IMapper mapper) : base(fsql)
        {
            _fsql = fsql;
            _mapper = mapper;
        }

        /// <summary>
        /// 分页获取分组列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<GroupResponse>> GetGroupPageListAsync(GroupRequest request)
        {
            var query = _fsql.Select<Group>()
                .Where(a => !a.IsDelete)
                .WhereIf(!string.IsNullOrEmpty(request.GroupName), a => a.GroupName.Contains(request.GroupName))
                .WhereIf(request.CreateTimeStart.HasValue, a => a.CreateTime >= request.CreateTimeStart)
                .WhereIf(request.CreateTimeEnd.HasValue, a=> a.CreateTime <= request.CreateTimeEnd)
                .WhereIf(request.CreateBy.HasValue, a=> a.CreateBy == request.CreateBy)
                .WhereIf(request.UpdateTimeStart.HasValue, a=> a.UpdateTime >= request.UpdateTimeStart)
                .WhereIf(request.UpdateTimeEnd.HasValue, a=> a.UpdateTime <= request.UpdateTimeEnd)
                .WhereIf(request.UpdateBy.HasValue, a=> a.UpdateBy == request.UpdateBy)
                .OrderByDescending(a => a.CreateTime);
            var List = await query.ToListAsync<GroupResponse>();
            return List;
        }

        /// <summary>
        /// 新增分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, GroupResponse?)> InsertGroupAsync(CreateGroupRequest request)
        {
            var model = _mapper.Map<CreateGroupRequest, Group>(request);
            model.IsDelete = false;
            model.CreateTime = model.UpdateTime = DateTime.Now;
            try
            {
                await InsertAsync(model);
                var result = _mapper.Map<Group, GroupResponse>(model);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        /// <summary>
        /// 编辑分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, GroupResponse?)> UpdateGroupAsync(UpdateGroupRequest request)
        {
            var model = await _fsql.Select<Group>().Where(a => a.Id == request.Id).FirstAsync();
            if(model == null)
            {
                return (false, "Group does not exist.", null);
            }
            _mapper.Map(request, model);
            model.UpdateTime = DateTime.Now;
            try
            {
                await UpdateAsync(model);
                var result = _mapper.Map<Group, GroupResponse>(model);
                return (true, "", result);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string)> DeleteGroupAsync(DeleteGroupRequest request)
        {
            if (!request.GroupIds.Any())
            {
                return (false, "分组Id为空，请填写有效分组Id.");
            }
            var existingGroupIds = await _fsql.Select<Group>()
                .Where(a => request.GroupIds.Contains(a.Id))
                .ToListAsync();
            var nonExistingGroupIds = request.GroupIds.Except(existingGroupIds.Select(u => u.Id));
            if (nonExistingGroupIds.Any())
            {
                return (false, $"删除失败，以下分组ID不存在: {string.Join(", ", nonExistingGroupIds)}.");
            }
            var affectedRows = await _fsql.Update<Group>()
                .Set(a => a.IsDelete, true)
                .Where(a => request.GroupIds.Contains(a.Id))
                .ExecuteAffrowsAsync();
            return affectedRows > 0? (true, "") : (false, "删除失败.");
        }
    }
}
