using AutoMapper;
using Spider.Code.Entities.User;
using System;
using System.Net.Mail;

namespace Merchants.Ams.Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            #region domain to dto
            CreateMap<Account, AccountDto>();
            #endregion domain to dto

            #region dto to domain
            CreateMap<AccountDto, Account>();
            #endregion dto to domain



        }
    }
}