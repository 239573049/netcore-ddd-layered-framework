﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XiaoHu.Application.AppServices.UserService;
using XiaoHu.Code.DbEnum;
using XiaoHu.Code.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaoHu.Web.Controllers
{
    /// <summary>
    /// 账号接口
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        public AccountController(
            IMapper mapper,
            IAccountService accountService
            )
        {
            this.mapper = mapper;
            this.accountService = accountService;
        }
        /// <summary>
        /// 新增账号
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Guid> CreateAccount(AccountDto account)
        {
            return await accountService.CreateAccount(account);
        }
        /// <summary>
        /// 封禁账号
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="time">封至时间</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> FreezeAccount(List<Guid> ids, DateTime time) =>
            await accountService.FreezeAccount(ids, time);

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
