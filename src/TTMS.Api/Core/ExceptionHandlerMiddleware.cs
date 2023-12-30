using Newtonsoft.Json;

namespace TTMS.Api.Core
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // 调用下一个中间件
                await _next(context);
            }
            catch (Exception ex)
            {
                // 处理异常并返回指定的格式
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // 调用 ToFailResult 方法获取错误响应对象
            var errorResponse = ToFailResult(ex.Message, 100);

            // 设置响应的状态码和内容类型
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";

            // 将错误响应对象序列化为 JSON 字符串
            var json = JsonConvert.SerializeObject(errorResponse);

            // 将 JSON 字符串写入响应流
            await context.Response.WriteAsync(json);
        }

        private object ToFailResult(string message, int errorCode)
        {
            return new ApiResultModel
            {
                ErrorCode = errorCode,
                Msg = message
            };
        }
    }
}
