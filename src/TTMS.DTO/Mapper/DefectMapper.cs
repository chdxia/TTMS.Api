namespace TTMS.DTO.Mapper
{
    /// <summary>
    /// 缺陷表mapper映射
    /// </summary>
    public class DefectMapper : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DefectMapper()
        {
            CreateMap<CreateDefectRequest, Defect>().ReverseMap();
            CreateMap<UpdateDefectRequest, Defect>().ReverseMap();
            CreateMap<Defect, DefectResponse>().ReverseMap();
        }
    }
}
