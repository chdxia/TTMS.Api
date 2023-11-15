namespace TTMS.Service
{
    public class DemandService : IDemandService
    {
        private readonly IDemandRepository _demandRepository;
        public DemandService(IDemandRepository demandRepository)
        {
            _demandRepository = demandRepository;
        }

        /// <summary>
        /// 新增需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, DemandResponse?)> CreateDemandAsync(CreateDemandRequest request)
        {
            // 新增需求
            var insertDemandResult =  await _demandRepository.InsertDemandAsync(request);
            if (!insertDemandResult.Item1)
            {
                return (false, insertDemandResult.Item2, null);
            }
            // 修改UserDemand关联表
            List<int> developersAndTesters = new List<int>();
            developersAndTesters.AddRange(request.Developer);
            developersAndTesters.AddRange(request.Tester);
            var updateUserDemandResult = await _demandRepository.UpdateUserDemandAsync(insertDemandResult.Item3.Id, developersAndTesters);
            if (!updateUserDemandResult.Item1)
            {
                return (false, "关联用户失败", null);
            }
            return (true, "", insertDemandResult.Item3);
        }

        /// <summary>
        /// 编辑需求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<(bool, string, DemandResponse?)> UpdateDemandAsync(UpdateDemandRequest request)
        {
            // 编辑需求
            var updateDemandResult = await _demandRepository.UpdateDemandAsync(request);
            if (!updateDemandResult.Item1)
            {
                return (false, updateDemandResult.Item2, null);
            }
            // 修改UserDemand关联表
            List<int> developersAndTesters = new List<int>();
            developersAndTesters.AddRange(request.Developer);
            developersAndTesters.AddRange(request.Tester);
            var updateUserDemandResult = await _demandRepository.UpdateUserDemandAsync(updateDemandResult.Item3.Id, developersAndTesters);
            if (!updateUserDemandResult.Item1)
            {
                return (false, "关联用户失败", null);
            }
            return (true, "", updateDemandResult.Item3);
        }
    }
}
