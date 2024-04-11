
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
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper, ILogger<TransactionService> logger)
            {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _logger = logger;
            }

        public List<TransactionDto> GetAllTransactions()
        {
            try
            {
                _logger.LogInformation("Fetching all transactions.");
                var transactions = _transactionRepository.GetAll();
                return _mapper.Map<List<TransactionDto>>(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all transactions.");
                throw;
            }

        }

        public TransactionDto CreateTransaction(TransactionDto transactionDto)
        {
            try
            {
                _logger.LogInformation("Creating a new transaction.");
                var transaction = _mapper.Map<Transaction>(transactionDto);
                var createdTransaction = _transactionRepository.Create(transaction);
                return _mapper.Map<TransactionDto>(createdTransaction);
                }
            catch (AutoMapperMappingException ex)
                {

                _logger.LogError(ex, "Mapping failed in CreateTransaction");
                throw;
                }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a transaction.");
                throw;
            }

        }

        public List<TransactionDto> GetTransactionsByDate(DateTime? startDate, DateTime? endDate, decimal amount)
            {
            try
                {
                _logger.LogInformation("Fetching transactions from the repository with date filter.");
                var transactions = _transactionRepository.GetByDate(startDate, endDate, amount);

                return _mapper.Map<List<TransactionDto>>(transactions);
            }

            catch (Exception ex)
                {
                _logger.LogError(ex, "Error occurred while fetching transactions with date filters.");
                throw;
            }
        } 
        }
    }
