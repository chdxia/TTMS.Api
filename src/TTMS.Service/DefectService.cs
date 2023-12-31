﻿namespace TTMS.Service
{
    public class DefectService : IDefectService
    {
        private readonly IDefectRepository _defectRepository;
        private readonly IDefectDetailRepository _defectDetailRepository;
        public DefectService(IDefectRepository defectRepository, IDefectDetailRepository defectDetailRepository)
        {
            _defectRepository = defectRepository;
            _defectDetailRepository = defectDetailRepository;
        }

        /// <summary>
        /// 编辑缺陷
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DefectResponse> UpdateDefectAsync(UpdateDefectRequest request)
        {
            // 待处理=>待验收=>通过，只能逐级向前变更状态
            var defect = await _defectRepository.GetDefectByIdAsync(request.Id);
            if (request.DefectState == Enums.DefectState.待验收 && defect.DefectState != Enums.DefectState.待处理)
            {
                throw new Exception("缺陷状态仅允许:待处理=>待验收");
            }
            else if (request.DefectState == Enums.DefectState.通过 && defect.DefectState != Enums.DefectState.待验收)
            {
                throw new Exception("缺陷状态仅允许:待验收=>通过");
            }
            // 更新缺陷
            var updateDefectResult = await _defectRepository.UpdateDefectAsync(request);
            // 新增缺陷明细
            var createDefectDetailRequest = new CreateDefectDetailRequest
            {
                DefectId = request.Id,
                Description = (request.DefectDetailDescription != null)? request.DefectDetailDescription : "",
                OldState = defect.DefectState,
                NewState = request.DefectState,
            };
            await _defectDetailRepository.InsertDefectDetailAsync(createDefectDetailRequest);
            return updateDefectResult;
        }
    }
}
