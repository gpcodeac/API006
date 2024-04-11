using API006.Database.Models;
using System;
using System.Collections.Generic;

namespace API006.Database.Repositories.Interfaces
    {
    public interface ITransactionRepository
        {
        List<Transaction> GetAll();
        Transaction Create(Transaction transaction);
        List<Transaction> GetByDate(DateTime? startDate = null, DateTime? endDate = null, bool sortByDate = false, bool sortByAmount = false);
        }
    }
