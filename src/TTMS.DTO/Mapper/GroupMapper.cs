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
            CreateMap<CreateGroupRequest, Group>().ReverseMap();
            CreateMap<UpdateGroupRequest, Group>().ReverseMap();
            CreateMap<Group, GroupResponse>().ReverseMap();
        }
    }
}
