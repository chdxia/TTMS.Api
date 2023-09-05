using Microsoft.AspNetCore.Mvc;

namespace LRtest.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Login")]
        public IActionResult UserLogin()
        {
            var data = new { Name = "John", Age = 30, City = "New York" };
            return Ok(data);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Logout")]
        public IActionResult UserLogout()
        {
            return Ok("logout");
        }
    }
}
