using API006.Database.Models;

namespace API006.Database.Repositories.Interfaces
    {
    public interface ITransactionRepository
        {
             List<Transaction> GetAll();
             Transaction Create(Transaction transaction);
             List<Transaction> GetByDate(DateTime date);
        }
    }
