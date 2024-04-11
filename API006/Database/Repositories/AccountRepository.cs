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

        //public Account? Delete(Account? account)
        //{
        //    Account acc = account;
        //    _context.Accounts.Remove(account);
        //    _context.SaveChanges();
        //    return acc;
        //}

        public Account? Delete(string accountNumber)
        {
            var acc = _context.Accounts.FirstOrDefault(account => account != null && account.AccountNumber == accountNumber);
            if (acc == null)
            {
                return null;
            }
            _context.Accounts.Remove(acc);
            _context.SaveChanges();
            return acc;
        }

        public Account? Withdraw(string accountNumber, int amount)
        {
            var acc = _context.Accounts.FirstOrDefault(account1 => account1.AccountNumber == accountNumber);
            if (acc != null && (acc.Balance > amount))
            {
                acc.Balance -= amount;
                _context.Accounts.Update(acc);
                _context.SaveChanges();
                return acc;
            }
            return null;
        }

        public Account? Deposit(string accountNumber, int amount)
        {
            var acc = _context.Accounts.FirstOrDefault(account1 => account1 != null && account1.AccountNumber == accountNumber);
            if (acc != null)
            {
                acc.Balance += amount;
                _context.Accounts.Update(acc);
                _context.SaveChanges();
                return acc;
            }
            return null;
        }

        public Account? GetAccount(string accountNumber)
        {
            return _context.Accounts.FirstOrDefault(x => x != null && x.AccountNumber == accountNumber);
        }

        public List<Account>? GetAccounts(int userId)
        {
            return _context.Accounts.Where(x => x.UserId == userId).ToList();
        }

        public void AddAccount(Account? account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        

    }
}
