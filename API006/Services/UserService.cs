using API006.Database.Repositories;
using API006.DTOs;

namespace API006.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _userRepository.GetAllUsers().Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username
            }).ToList();
        }
    }
}
