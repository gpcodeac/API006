using API006.Services.Interfaces;
using API006.Database.Repositories.Interfaces;
using API006.Database.Models;

namespace API006.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Account Delete(string account)
        {
            return _accountRepository.Delete(account);
        }

        public Account Withdraw(string accountNumber, int amount)
        {
            return _accountRepository.Withdraw(accountNumber, amount);
        }

        public Account Deposit(string accountNumber, int amount)
        {
            return _accountRepository.Deposit(accountNumber, amount);
        }
    }
}
