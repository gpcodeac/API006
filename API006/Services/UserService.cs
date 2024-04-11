using API006.Database.Models;
using API006.Database.Repositories.Interfaces;
using API006.DTOs;
using API006.Services.Interfaces;

namespace API006.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _userRepository.GetAllUsers().Select(user => new UserDto
            {
                Username = user.Username
            }).ToList();

        }

        public User CreateNewUser(User user)
        {
            var createdUser = _userRepository.CreateNewUser(user);
            return (createdUser);
        }


        public UserDto GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            
            if (user == null)
                return null;

            return new UserDto
            {
                Username = user.Username
                //PasswordHash = user.PasswordHash //Ar tinka sitas? Siaip cia sensitive data tai gal nereikia
            };
        }

        public UserDto GetUserByUsernameAndPassword(string username, string password)
        {
            var user = _userRepository.GetByUsernameAndPassword(username, password);

            if (user == null)
                return null;

            return new UserDto
            {
                Username = user.Username
                //PasswordHash = user.PasswordHash //Ar tinka sitas? Siaip cia sensitive data tai gal nereikia
            };
        }
    }
}
