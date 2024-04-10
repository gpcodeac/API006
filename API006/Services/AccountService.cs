using API006.Services.Interfaces;
using API006.Database.Repositories.Interfaces;
using API006.Database.Models;
using API006.DTOs;
using AutoMapper;

namespace API006.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;   

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
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
        public Account? GetAccount(string accountNumber)
        {
            return _accountRepository.GetAccount(accountNumber);
        }

        public Account? GetAccount(int userId)
        {
            return _accountRepository.GetAccount(userId);
        }

        public void AddAccount(AccountDto account, int userId)
        {
            if (account == null)
            {
                throw new System.ArgumentNullException(nameof(account));
            }
            if (string.IsNullOrEmpty(account.AccountNumber))
            {
                throw new System.ArgumentException("Account number cannot be empty", nameof(account.AccountNumber));
            }
            if (GetAccount(account.AccountNumber) is not null)
            {
                throw new System.ArgumentException("Account already exists", nameof(account.AccountNumber));
            }
            Account accountToAdd = new();
            _mapper.Map(account, accountToAdd);
            accountToAdd.UserId = userId;
            _accountRepository.AddAccount(accountToAdd);
        }
    }
}
