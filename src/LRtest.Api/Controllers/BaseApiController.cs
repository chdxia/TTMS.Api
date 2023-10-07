namespace LRtest.Api.Controllers
{
    #region BaseApiController 控制器基类

    /// <summary>
    /// BaseApiController 控制器基类
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "default")]
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
        /// <param name="body"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual JsonResult ToSuccessResult<T>(T body, string msg = "")
        {
            return Json(new ApiResultModel<T>
            {
                Body = body,
                ErrorCode = 0,
                Msg = msg
            });
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
        public T? Body { get; set; }

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
        public ApiResultModel<T> ToFailResult(string errMsg = "操作失败", int errCode = 1)
        {
            Msg = errMsg;
            ErrorCode = errCode;
            return this;
        }

        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="body"></param>
        /// <param name="msg"></param>
        /// <param name="errCode"></param>
        /// <returns></returns>
        public ApiResultModel<T> ToSucceedResult(T body = default, string msg = "操作成功", int errCode = 0)
        {
            Msg = msg;
            ErrorCode = errCode;
            Body = body;
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
        public ApiResultModel()
        {
            Body = string.Empty;
        }

        public new ApiResultModel ToFailResult(string errMsg = "操作失败", int errCode = 1)
        {
            Msg = errMsg;
            ErrorCode = errCode;
            return this;
        }

        public new ApiResultModel ToSucceedResult(string body = "", string msg = "操作成功", int errCode = 0)
        {
            Msg = msg;
            ErrorCode = errCode;
            Body = body;
            return this;
        }
    }

    #endregion
}
