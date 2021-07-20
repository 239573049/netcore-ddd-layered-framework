using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
        public SystemController(
            )
        {

        }
        /// <summary>
        /// 获取运行系统
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OSVersion()
        {
            var data =Environment.WorkingSet;
            return new OkObjectResult(Environment.OSVersion.Platform.ToString());
        }
    }
}
