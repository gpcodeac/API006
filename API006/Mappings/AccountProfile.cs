using API006.Database.Models;
using API006.DTOs;
using AutoMapper;

namespace API006.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
        }
    }
}
