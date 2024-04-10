using API006.Database.Models;
using API006.Database.Repositories.Interfaces;

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
            return transactions;
        }

        public List<Transaction> GetByDate(DateTime date)
        {
            var transactions = _context.Transactions
                .Where(t => t.Date.Date == date.Date)
                .ToList();
            return transactions;
        }
    }
}