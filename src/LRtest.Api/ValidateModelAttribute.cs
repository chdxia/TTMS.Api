using Microsoft.AspNetCore.Mvc.Filters;

namespace LRtest.Api
{
    /// <summary>
    /// 自定义全局过滤器;用于request模型验证
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorMessages = new List<string>();
                foreach (var modelStateEntry in context.ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        errorMessages.Add(error.ErrorMessage);
                    }
                }
                var formattedErrorMessage = string.Join(", ", errorMessages);
                var apiResult = new Controllers.ApiResultModel
                {
                    ErrorCode = 100,
                    Msg = formattedErrorMessage
                };
                context.Result = new JsonResult(apiResult); // 返回验证错误信息
            }
        }
    }
}
