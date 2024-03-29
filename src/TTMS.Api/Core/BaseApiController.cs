﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace TTMS.Api.Core
{
    #region BaseApiController 控制器基类

    /// <summary>
    /// BaseApiController 控制器基类
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "default")]
    [ServiceFilter(typeof(ValidateModelAttribute))] // 应用自定义全局过滤器
    public abstract class BaseApiController : Controller
    {
        /// <summary>
        /// 错误返回
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        protected virtual JsonResult ToFailResult(string msg, int errorCode = 100)
        {
            ApiResultModel data = new ApiResultModel
            {
                ErrorCode = errorCode,
                Msg = msg
            };
            return Json(data);
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        protected virtual JsonResult ToResult(string msg, int errorCode)
        {
            ApiResultModel data = new ApiResultModel
            {
                ErrorCode = errorCode,
                Msg = msg
            };
            return Json(data);
        }

        /// <summary>
        /// 自动返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiResult"></param>
        /// <returns></returns>
        protected virtual JsonResult AutoReturnResult<T>(ApiResultModel<T> apiResult)
        {
            return Json(apiResult);
        }

        /// <summary>
        /// 成功返回，不带body
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual JsonResult ToSuccessResult(string msg = "")
        {
            ApiResultModel data = new ApiResultModel
            {
                ErrorCode = 0,
                Msg = msg
            };
            return Json(data);
        }

        /// <summary>
        /// 成功返回，带body
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual JsonResult ToSuccessResult<T>(T data, string msg = "")
        {
            return Json(new ApiResultModel<T>
            {
                Data = data,
                ErrorCode = 0,
                Msg = msg
            });
        }
    }

    #endregion

    #region AuthorizeApiController 需要认证的控制器基类

    /// <summary>
    /// AuthorizeApiController 需要认证的控制器基类
    /// </summary>
    [Authorize]
    public abstract class AuthorizeApiController : BaseApiController
    {
        private readonly IAuthPermissionService _authPermissionService;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="authPermissionService"></param>
        /// <param name="userRepository"></param>
        public AuthorizeApiController(IAuthPermissionService authPermissionService, IUserRepository userRepository)
        {
            _authPermissionService = authPermissionService;
            _userRepository = userRepository;
        }
        
        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            // 获取当前访问的接口名称

            // 获取当前用户的身份标识 token或者id
            string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];
            //var authorizationUser = await _userRepository.GetUserByTokenAsync(authorizationHeader);
            //if (authorizationUser == null)
            //{
            //    // 用户认证未通过，可以返回一个认证未通过的结果，需要重新登录
            //    //context.Result = new UnauthorizedResult();
            //    context.Result = ToFailResult("认证未通过，请重新登录");
            //    return;
            //}
            //context.HttpContext.Items["User"] = authorizationUser;
            // 检查当前用户是否有访问该接口的权限
            bool hasPermission = await _authPermissionService.HasPermissionAsync("interfaceName", "userId");

            if (!hasPermission)
            {
                // 如果用户没有权限，可以返回一个未授权的结果，或者执行其他相应的操作
                //context.Result = new UnauthorizedResult();
                context.Result = ToFailResult("没有权限.");
                return;
            }

            base.OnActionExecuting(context);
        }
    }

    #endregion

    #region ApiResultModel 返回格式，带body
    
    /// <summary>
    /// 返回格式，带body
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResultModel<T>
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string? Msg { get; set; }

        /// <summary>
        /// 数据内容
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess => ErrorCode == 0;

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="errCode"></param>
        /// <returns></returns>
        public ApiResultModel<T> ToFailResult(string errMsg = "操作失败", int errCode = 100)
        {
            Msg = errMsg;
            ErrorCode = errCode;
            return this;
        }

        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <param name="errCode"></param>
        /// <returns></returns>
        public ApiResultModel<T> ToSucceedResult(T data = default, string msg = "操作成功", int errCode = 0)
        {
            Msg = msg;
            ErrorCode = errCode;
            Data = data;
            return this;
        }
    }

    #endregion

    #region ApiResultModel 返回格式，不带body

    /// <summary>
    /// 返回格式，不带body
    /// </summary>
    public class ApiResultModel : ApiResultModel<string>
    {
        /// <summary>
        /// ApiResultModel
        /// </summary>
        public ApiResultModel()
        {
            Data = string.Empty;
        }

        /// <summary>
        /// ToFailResult
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="errCode"></param>
        /// <returns></returns>
        public new ApiResultModel ToFailResult(string errMsg = "操作失败", int errCode = 100)
        {
            Msg = errMsg;
            ErrorCode = errCode;
            return this;
        }

        /// <summary>
        /// ToSucceedResult
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <param name="errCode"></param>
        /// <returns></returns>
        public new ApiResultModel ToSucceedResult(string data = "", string msg = "操作成功", int errCode = 0)
        {
            Msg = msg;
            ErrorCode = errCode;
            Data = data;
            return this;
        }
    }

    #endregion
}
