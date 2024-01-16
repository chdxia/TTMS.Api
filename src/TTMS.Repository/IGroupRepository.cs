namespace TTMS.Repository
{
    public interface IGroupRepository : IBaseRepository<Group, long>
    {
        /// <summary>
        /// 分页获取分组列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PageListGroupResponse> GetGroupPageListAsync(GroupRequest request);

        /// <summary>
        /// 新增分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GroupResponse> InsertGroupAsync(CreateGroupRequest request);

        /// <summary>
        /// 编辑分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GroupResponse> UpdateGroupAsync(UpdateGroupRequest request);

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task DeleteGroupAsync(DeleteGroupRequest request);
    }
}
