using API006.Database.Models;

namespace API006.Services.Interfaces
{
    public interface IAccountService
    {
         Account Delete(string account);
         Account Withdraw(string accountNumber, int amount);
         Account Deposit(string accountNumber, int amount);
    }
}
