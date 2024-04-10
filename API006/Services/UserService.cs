using API006.Database.Models;
using API006.Database.Repositories;
using API006.Database.Repositories.Interfaces;
using API006.DTOs;
using API006.Services.Interfaces;
using AutoMapper;

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
                Id = user.Id,
                Username = user.Username
            }).ToList();
        }
        public User CreateNewUser(User user)
        {
            var createdUser = _userRepository.CreateNewUser(user);
            return (createdUser);
        }
    }
}
