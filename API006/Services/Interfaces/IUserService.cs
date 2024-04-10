using API006.DTOs;
using API006.Database.Models;

namespace API006.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        User CreateNewUser(User user);

    }
}
