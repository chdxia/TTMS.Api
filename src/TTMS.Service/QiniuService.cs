namespace TTMS.Service
{
    /// <summary>
    /// 七牛服务
    /// </summary>
    public class QiniuService : IQiniuService
    {
        public async Task<(bool, string)> UploadFileAsync(int a)
        {
            await Task.CompletedTask;
            return (true, "");
        }
    }
}
