namespace TTMS.DTO.Mapper
{
    /// <summary>
    /// 用户表mapper映射
    /// </summary>
    public class UserMapper : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<UpdateUserRequest, User>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, UserLoginResponse>().ReverseMap();
        }
    }
}
