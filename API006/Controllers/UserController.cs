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
        
        [HttpGet("{username}/{password}")]
        public ActionResult<UserDto> GetByNameAndPassword(string username, string password)
        {
            var user = _userService.GetUserByUsernameAndPassword(username, password);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
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