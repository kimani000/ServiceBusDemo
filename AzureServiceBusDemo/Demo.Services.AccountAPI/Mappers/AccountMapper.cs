using AutoMapper;
using Demo.Services.AccountAPI.DTOs;
using Demo.Services.AccountAPI.Models;

namespace Demo.Services.AccountAPI.Mappers
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
        }
    }
}
