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
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, IUserService userService, ITransactionService transactionService)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _userService = userService;
            _transactionService = transactionService;
        }

        public Account? Delete(string account)
        {
            return _accountRepository.Delete(account);
        }

        public Account? Withdraw(string accountNumber, int amount)
        {
            var account = _accountRepository.Withdraw(accountNumber, amount);
            if (account is null)
            {
                return null;
            }

            TransactionDto transactionDto = new()
            {
                Amount = amount*(-1),
                Date = System.DateTime.Now
            };
            _transactionService.CreateTransaction(transactionDto);
            //account.Transactions.Add(transactionDto);
            return account;
        }

        public Account? Deposit(string accountNumber, int amount)
        {
            var account = _accountRepository.Deposit(accountNumber, amount);
            if (account is null)
            {
                return null;
            }

            TransactionDto transactionDto = new()
            {
                Amount = amount,
                Date = System.DateTime.Now
            };
            _transactionService.CreateTransaction(transactionDto);
            return account;
        }



        public Account? GetAccount(string accountNumber)
        {
            return _accountRepository.GetAccount(accountNumber);
        }

        public List<Account>? GetAccounts(int userId)
        {
            return _accountRepository.GetAccounts(userId);
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
            if (userId == 0 || _userService.GetUserById(userId) is null)
            {
                throw new System.ArgumentException("User does not exist", nameof(userId));
            }
            Account? accountToAdd = new();
            _mapper.Map(account, accountToAdd);
            accountToAdd.UserId = userId; 
            _accountRepository.AddAccount(accountToAdd);
        }
    }
}
