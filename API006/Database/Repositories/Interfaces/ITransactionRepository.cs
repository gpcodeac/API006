using API006.Database.Models;
using System;
using System.Collections.Generic;

namespace API006.Database.Repositories.Interfaces
    {
    public interface ITransactionRepository
        {
        public List<Transaction> GetAll();
        public Transaction Create(Transaction transaction);
        public List<Transaction> GetByDate(DateTime date);
        }
    }
