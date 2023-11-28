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
            // 修改DemandUser关联表
            List<int> developersAndTesters = new List<int>();
            developersAndTesters.AddRange(request.Developer);
            developersAndTesters.AddRange(request.Tester);
            await _demandRepository.UpdateDemandUserAsync(insertDemandResult.Item3.Id, developersAndTesters);
            // 修改DemandVersionInfo关联表
            var updateDemandVersionInfoRequest = new UpdateDemandVersionInfoRequest {DemandIds=new List<int> {insertDemandResult.Item3.Id}, VersionInfoIds=request.VersionInfoIds};
            await _demandRepository.UpdateDemandVersionInfoAsync(updateDemandVersionInfoRequest);
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
            await _demandRepository.UpdateDemandUserAsync(updateDemandResult.Item3.Id, developersAndTesters);
            // 修改DemandVersionInfo关联表
            var updateDemandVersionInfoRequest = new UpdateDemandVersionInfoRequest { DemandIds = new List<int> { updateDemandResult.Item3.Id }, VersionInfoIds = request.VersionInfoIds };
            await _demandRepository.UpdateDemandVersionInfoAsync(updateDemandVersionInfoRequest);
            return (true, "", updateDemandResult.Item3);
        }
    }
}
