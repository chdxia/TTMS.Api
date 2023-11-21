namespace TTMS.DTO.Mapper
{
    /// <summary>
    /// 分组表mapper映射
    /// </summary>
    public class GroupMapper : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public GroupMapper()
        {
            CreateMap<CreateUserGroupRequest, UserGroup>().ReverseMap();
            CreateMap<UpdateUserGroupRequest, UserGroup>().ReverseMap();
            CreateMap<UserGroup, UserGroupResponse>().ReverseMap();
        }
    }
}
