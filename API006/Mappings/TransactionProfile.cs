using API006.DTOs;
using AutoMapper;
using System.Transactions;

namespace API006.Mappings
    {
    public class TransactionProfile : Profile
        {
        public TransactionProfile()
            {
            CreateMap<Transaction, TransactionDto>().ReverseMap();

            }
        }
    }
