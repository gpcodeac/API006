using API006.Database.Models;
using API006.DTOs;

namespace API006.Services.Interfaces
{
    public interface IAccountService
    {
        Account? Delete(string account);
        Account? Withdraw(string accountNumber, int amount);
        Account? Deposit(string accountNumber, int amount);
        Account? GetAccount(string accountNumber);
        List<Account>? GetAccounts(int userId);
        void AddAccount(AccountDto account, int userId);
    }
}
