namespace TTMS.Service
{
    public class DefectService : IDefectService
    {
        private readonly IDefectRepository _defectRepository;
        public DefectService(IDefectRepository defectRepository)
        {
            _defectRepository = defectRepository;
        }

        /// <summary>
        /// 编辑缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, DefectResponse?)> UpdateDefectAsync(UpdateDefectRequest request)
        {
            // 待处理=>待验收=>通过，只能逐级向前变更状态
            var defect = await _defectRepository.GetDefectByIdAsync(request.Id);
            if (request.DefectState == Enums.DefectState.待验收 && defect.DefectState != Enums.DefectState.待处理)
            {
                return (false, "缺陷状态仅允许:待处理=>待验收", null);
            }
            else if (request.DefectState == Enums.DefectState.通过 && defect.DefectState != Enums.DefectState.待验收)
            {
                return (false, "缺陷状态仅允许:待验收=>通过", null);
            }
            var updateDefectResult = await _defectRepository.UpdateDefectAsync(request);
            return (true, "", updateDefectResult.Item3);
        }
    }
}
