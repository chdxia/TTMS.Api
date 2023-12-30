namespace TTMS.Service
{
    public interface IQiniuService
    {

        /// <summary>
        /// 上传文件到七牛oss
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<string>> UploadFileAsync(UploadFileRequest request);
    }
}
