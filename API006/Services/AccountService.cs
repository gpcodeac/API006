using API006.Services.Interfaces;
using API006.Database.Repositories.Interfaces;
using API006.Database.Models;
using API006.Services.Interfaces;

namespace API006.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

    }
}
