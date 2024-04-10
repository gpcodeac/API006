using API006.Database.Models;
using API006.Database.Repositories;

namespace API006.Database.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Account? GetAccount(string accountNumber);
        Account? GetAccount(int userId);
        void AddAccount(Account account);
    }
}
