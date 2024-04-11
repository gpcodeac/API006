using API006.Database.Models;
using API006.Database.Repositories.Interfaces;

namespace API006.Database.Repositories
{
    public class UserRepository : IUserRepository
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

        public User CreateNewUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
        }
    }
}
