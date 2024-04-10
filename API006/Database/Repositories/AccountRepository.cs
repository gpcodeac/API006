using API006.Database;
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

        public Account? GetAccount(string accountNumber)
        {
            return _context.Accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
        }

        public Account? GetAccount(int userId)
        {
            return _context.Accounts.FirstOrDefault(x => x.UserId == userId);
        }

        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        

    }
}
