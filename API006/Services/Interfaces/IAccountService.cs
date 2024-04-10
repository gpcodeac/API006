using API006.Database.Models;

namespace API006.Services.Interfaces
{
    public interface IAccountService
    {
        public Account Delete(string account);
        public Account Withdraw(string accountNumber, int amount);
        public Account Deposit(string accountNumber, int amount);
    }
}
