using API006.Database.Models;
using API006.Database.Repositories.Interfaces;


namespace API006.Database.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _context;

        public AccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Account Delete(Account account)
        {
            return _context.Accounts.Remove(account).Entity;
        }

        public Account Withdraw(string accountNumber, int amount)
        {
            var acc = _context.Accounts.FirstOrDefault(account1 => account1.AccountNumber == accountNumber);
            if (acc != null && (acc.Balance > amount))
            {
                acc.Balance -= amount;
                return _context.Accounts.Update(acc).Entity;
            }
            return null;
        }

        public Account Delete(string accountNumber)
        {
            var acc = _context.Accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);
            return _context.Accounts.Remove(acc).Entity;
        }

        public Account Deposit(string accountNumber, int amount)
        {
            var acc = _context.Accounts.FirstOrDefault(account1 => account1.AccountNumber == accountNumber);
            if (acc != null)
            {
                acc.Balance += amount;
                return _context.Accounts.Update(acc).Entity;
            }
            return null;
        }
    }
}
