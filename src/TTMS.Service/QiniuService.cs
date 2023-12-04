using Microsoft.Extensions.Configuration;
using Qiniu.Http;
using Qiniu.IO.Model;
using Qiniu.IO;
using Qiniu.Util;

namespace TTMS.Service
{
    /// <summary>
    /// 七牛服务
    /// </summary>
    public class QiniuService : IQiniuService
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _bucket;
        private readonly string[] permittedExtensions = { "jpg", "png" };

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public QiniuService(IConfiguration configuration)
        {
            _accessKey = configuration.GetSection("Qiniu:AccessKey").Value;
            _secretKey = configuration.GetSection("Qiniu:SecretKey").Value;
            _bucket = configuration.GetSection("Qiniu:Bucket").Value;
        }

        /// <summary>
        /// 上传文件到七牛oss
        /// </summary>
        /// <param name="fileCollection"></param>
        /// <returns></returns>
        public async Task<(bool, List<string>)> UploadFileAsync(UploadFileRequest request)
        {
            Mac mac = new Mac(_accessKey, _secretKey);
            List<string> savedKeys = new List<string>();

            var tasks = request.FileCollection.Select(async file =>
            {
                string saveKey = Guid.NewGuid().ToString();
                // 验证文件扩展名
                string fileExtension = Path.GetExtension(file.FileName).TrimStart('.');
                if (!permittedExtensions.Contains(fileExtension))
                {
                    throw new ArgumentException($"File extension '{fileExtension}' is not allowed.");
                }
                // 创建临时文件路径
                string tempFilePath = Path.GetTempFileName();
                // 将文件保存到临时文件路径
                using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                // 创建上传策略
                PutPolicy putPolicy = new PutPolicy();
                putPolicy.Scope = _bucket;
                putPolicy.SetExpires(3600);
                putPolicy.DeleteAfterDays = 1;
                // 生成上传凭证
                string uploadToken = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
                // 创建上传管理器
                var uploadManager = new UploadManager();
                // 上传文件到七牛云
                HttpResult result = await uploadManager.UploadFileAsync(tempFilePath, saveKey, uploadToken);
                if (result.Code == 200)
                {
                    savedKeys.Add(saveKey);
                }
                else
                {
                    throw new Exception("Failed to upload file to Qiniu OSS.");
                }
                // 删除临时文件
                File.Delete(tempFilePath);
            });
            // 等待所有上传任务完成
            await Task.WhenAll(tasks);
            return (true, savedKeys);
        }
    }
}
