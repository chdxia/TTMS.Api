namespace TTMS.DTO.Mapper
{
    /// <summary>
    /// 版本表mapper映射
    /// </summary>
    public class VersionInfoMapper : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public VersionInfoMapper()
        {
            CreateMap<CreateVersionInfoRequest, VersionInfo>().ReverseMap();
            CreateMap<UpdateVersionInfoRequest, VersionInfo>().ReverseMap();
            CreateMap<VersionInfo, VersionInfoResponse>().ReverseMap();
        }
    }
}
