namespace TTMS.DTO.Mapper
{
    /// <summary>
    /// 需求表mapper映射
    /// </summary>
    public class DemandMapper : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DemandMapper()
        {
            CreateMap<CreateDemandRequest, Demand>().ReverseMap();
            CreateMap<UpdateDemandRequest, Demand>().ReverseMap();
            CreateMap<Demand, DemandResponse>().ReverseMap();
        }
    }

    /// <summary>
    /// 需求文件表mapper映射
    /// </summary>
    public class DemandFileMapper : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DemandFileMapper()
        {
            CreateMap<CreateDefectDetailFileRequest, DemandFile>().ReverseMap();
            CreateMap<DemandFile, DemandFileResponse>().ReverseMap();
        }
    }
}
