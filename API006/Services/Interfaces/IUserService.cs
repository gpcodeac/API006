namespace API006.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        User CreateNewUser(User user);

    }
}
