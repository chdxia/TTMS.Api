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

    /// <summary>
    /// 缺陷文件表mapper映射
    /// </summary>
    public class DefectFileMapper : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DefectFileMapper()
        {
            CreateMap<CreateDefectFileRequest, DefectFile>().ReverseMap();
            CreateMap<DefectFile, DefectFileResponse>().ReverseMap();
        }
    }

    /// <summary>
    /// 缺陷明细表mapper映射
    /// </summary>
    public class DefectDetailMapper : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DefectDetailMapper()
        {
            CreateMap<CreateDefectDetailRequest, DefectDetail>().ReverseMap();
            CreateMap<DefectDetail, DefectDetailResponse>().ReverseMap();
        }
    }

    /// <summary>
    /// 缺陷明细文件表mapper映射
    /// </summary>
    public class DefectDetailFileMapper : Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DefectDetailFileMapper()
        {
            CreateMap<CreateDefectDetailFileRequest, DefectDetailFile>().ReverseMap();
            CreateMap<DefectDetailFile, DefectDetailFileResponse>().ReverseMap();
        }
    }
}
