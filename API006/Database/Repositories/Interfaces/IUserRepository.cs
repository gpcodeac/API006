using API006.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace API006.Database.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User CreateNewUser(User user);

    }
}
