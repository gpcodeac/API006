using API006.Database.Models;
using API006.DTOs;

namespace API006.Services.Interfaces
{
    public interface IAccountService
    {
        Account? GetAccount(string accountNumber);
        Account? GetAccount(int userId);
        void AddAccount(AccountDto account);
    }
}
