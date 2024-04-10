using API006.Database.Repositories;
using API006.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace API006.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var users = _userRepository.GetAllUsers().Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username
                
            }).ToList();

            return Ok(users);
        }
    }
}