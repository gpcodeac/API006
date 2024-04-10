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
        
        // missing Get By Name and Password method


        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            // in get all select method is not needed (it should be in repository layer)
            var users = _userService.GetUsers().Select(user => new UserDto
            {
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
                return Ok(_userService.CreateNewUser(user));
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create user: {ex.Message}");
            }
        }


    }
}