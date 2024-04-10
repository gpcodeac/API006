using API006.Database.Models;

namespace API006.Database.Repositories
{
    public class UserRepository
    {

        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
