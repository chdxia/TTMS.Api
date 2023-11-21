namespace TTMS.Repository
{
    public interface IUserGroupRepository : IBaseRepository<UserGroup, long>
    {
        /// <summary>
        /// 分页获取分组列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<UserGroupResponse>> GetUserGroupPageListAsync(UserGroupRequest request);

        /// <summary>
        /// 新增分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, UserGroupResponse?)> InsertUserGroupAsync(CreateUserGroupRequest request);

        /// <summary>
        /// 编辑分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, UserGroupResponse?)> UpdateUserGroupAsync(UpdateUserGroupRequest request);

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string)> DeleteUserGroupAsync(DeleteUserGroupRequest request);
    }
}
