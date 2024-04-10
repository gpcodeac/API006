using API006.Database.Models;

namespace API006.Database.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Account Withdraw(string accountNumber, int amount);
        public Account Delete(string accountNumber);
        public Account Deposit(string accountNumber, int amount);
    }
}
