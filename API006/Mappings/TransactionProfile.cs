using API006.DTOs;
using AutoMapper;
//using System.Transactions;
using API006.Database.Models;

namespace API006.Mappings
    {
    public class TransactionProfile : Profile
        {
        public TransactionProfile()
            {
            CreateMap<TransactionDto, Transaction>()
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.Date, opt => opt.Ignore())
            .ReverseMap();

            }
        }
    }
