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
    }
}
