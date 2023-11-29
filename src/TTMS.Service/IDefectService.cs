namespace TTMS.Service
{
    public interface IDefectService
    {

        /// <summary>
        /// 编辑缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<(bool, string, DefectResponse?)> UpdateDefectAsync(UpdateDefectRequest request);
    }
}
