using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XiaoHu.Uitl.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Uitl.Util;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using XiaoHu.Web.Code.Model.System;

namespace XiaoHu.Web.Controllers
{
    /// <summary>
    /// 系统信息接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        /// <summary>
        /// 获取系统信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OSVersion()
        {
            var obj = new SystemDataVM();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                var use = LinuxData.ReadMemInfo();
                obj= new SystemDataVM
                {   
                    Available=use.Available,
                    Total=use.Total,
                    Usage= use.Usage,
                    Cpu = LinuxData.QUERY_CPULOAD(false),
                    SystemOs = "Linux"
                }; 
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                obj = new SystemDataVM
                {

                    Available = WinData.GetRAM(),
                    SystemOs = "Windows",
                    SystemUpTime = WinData.GetSystemUpTime(),
                    Total = WinData.GetMemory(),
                    Cpu = WinData.GetCpuUsage(),
                };
                obj.Usage = Convert.ToInt32((obj.Total - obj.Available) / obj.Total * 100);
            }
            return new OkObjectResult(obj);
        }
       
    }
}
