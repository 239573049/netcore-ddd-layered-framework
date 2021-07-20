using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spider.Application.AppServices.UserService;
using Spider.Code.DbEnum;
using Spider.Code.Entities.User;
using Spider.Uitl.Util;
using Spider.Web.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Cx.NetCoreUtils.Filters.GlobalModelStateValidationFilter;

namespace Spider.Web.Controllers
{
    /// <summary>
    /// 登录接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        
        public LoginController(
            IMapper mapper,
            IAccountService accountService
            )
        {
            this.mapper = mapper;
            this.accountService = accountService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Register(string accountNumber,string passWord)
        {
            var data =await accountService.GetAccount(accountNumber);
            switch (data.Status)
            {
                case StatusEnum.Disabled:
                    return new ModelStateResult("账号已禁用请联系管理员");
                case StatusEnum.Freeze:
                    return new ModelStateResult($"账号已冻结至{(DateTime)data.Freezetime:yyyy-MM-dd HH:mm:ss}");
            }
            return new OkObjectResult("成功");
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Tuple<List<AccountDto>, int>> GetAccountList(string name, StatusEnum? status, int pageNo = 1, int pageSize = 20)
        {
            return await accountService.GetAccountList(name, status, pageNo, pageSize);
        }

    }
}
