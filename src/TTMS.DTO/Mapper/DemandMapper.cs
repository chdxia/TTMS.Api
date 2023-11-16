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
}
