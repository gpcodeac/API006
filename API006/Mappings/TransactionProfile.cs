using API006.DTOs;
using AutoMapper;
using API006.Database.Models;
using Transaction = System.Transactions.Transaction;

namespace API006.Mappings
    {
    public class TransactionProfile : Profile
        {
        public TransactionProfile()
            {
            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            }
        }
    }
