using API006.Database.Models;
using API006.Database.Repositories;
using API006.DTOs;
using API006.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API006.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var users = _userService.GetUsers().Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username

            }).ToList();

            return Ok(users);
        }

        [HttpPost]

        public ActionResult CreateUser([FromBody] UserDto userDto)
        {
            try
            {
                var user = userDto.ConvertToUser();
                _userService.CreateNewUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create user: {ex.Message}");
            }
        }


    }
}