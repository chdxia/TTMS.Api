namespace TTMS.Service
{
    public interface IQiniuService
    {
        Task<(bool, string)> UploadFileAsync(int a);
    }
}
