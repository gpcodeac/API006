using API006.DTOs;

namespace API006.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
    }
}
