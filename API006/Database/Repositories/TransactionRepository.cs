using API006.Database.Models;
using API006.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API006.Database.Repositories
    {
    public class TransactionRepository : ITransactionRepository
        {
        private readonly ApplicationDBContext _context;

        public TransactionRepository(ApplicationDBContext context)
            {
            _context = context;
            }

        public Transaction Create(Transaction transaction)
            {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return transaction;
            }

        public List<Transaction> GetAll()
            {
            var transactions = _context.Transactions.ToList();
            return transactions ?? new List<Transaction>();
            }

        public List<Transaction> GetByDate(DateTime? startDate = null, DateTime? endDate = null, bool sortByDate = false, bool sortByAmount = false)
            {
            var query = _context.Transactions.AsQueryable();
            if (startDate.HasValue)
                {
                query = query.Where(t => t.Date >= startDate.Value);
                }
            if (endDate.HasValue)
                {
                query = query.Where(t => t.Date <= endDate.Value);

                }
            if (sortByDate)
                {
                query = query.OrderBy(t => t.Date);
                }
            if (sortByAmount)
                {
                query = query.OrderBy(a => a.Amount);
                }
            return query.ToList();
            }
        }
    }
