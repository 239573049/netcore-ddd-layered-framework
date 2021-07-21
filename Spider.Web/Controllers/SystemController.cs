using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spider.Uitl.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Web.Controllers
{
    /// <summary>
    /// 系统信息接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        /// <summary>
        /// 获取运行系统
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OSVersion()
        {
            var sys =new SystemUtil();
            return new OkObjectResult(new { CpuState= sys.GetCpuState(), Mem = sys.GetMem(), PidInfo = sys.GetPidInfo(), Tasks = sys.GetTasks() });
        }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetData() =>
            new OkObjectResult(SystemUtil.GetSystemData());
        /// <summary>
        /// 获取网络速度
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetInternetSpeed() =>
            new OkObjectResult(SystemUtil.InternetSpeed());
    }
}
