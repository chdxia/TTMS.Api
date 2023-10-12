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
                context.Result = new BadRequestObjectResult(context.ModelState); // 返回验证错误信息
            }
        }
    }
}
