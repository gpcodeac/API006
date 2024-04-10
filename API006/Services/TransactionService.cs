
using API006.DTOs;
using API006.Database.Models;
using API006.Database.Repositories.Interfaces;
using API006.Services.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace API006.Services
    {
    public class TransactionService : ITransactionService
        {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
            {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            }

        public List<TransactionDto> GetAllTransactions()
            {
            var transactions = _transactionRepository.GetAll();
            return _mapper.Map<List<TransactionDto>>(transactions);
            }

        public TransactionDto CreateTransaction(TransactionDto transactionDto)
            {
            var transaction = _mapper.Map<Transaction>(transactionDto);
            var createdTransaction = _transactionRepository.Create(transaction);
            return _mapper.Map<TransactionDto>(createdTransaction);
            }

        public List<TransactionDto> GetTransactionsByDate(DateTime date)
            {
            var transaction = _transactionRepository.GetByDate(date);
            return _mapper.Map<List<TransactionDto>>(transaction);
            }
        }
    }
