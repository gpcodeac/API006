using API006.Database.Models;
using API006.DTOs;

namespace API006.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();

        User CreateNewUser(User user);

        UserDto GetUserByUsernameAndPassword(string username, string password);
    }
}
