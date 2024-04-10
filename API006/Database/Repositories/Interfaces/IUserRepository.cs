using API006.Database.Models;

namespace API006.Database.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User CreateNewUser(User user);

    }
}
