using Microsoft.AspNetCore.Mvc;
using API006.Services.Interfaces;
using API006.DTOs;


namespace API006.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("{accountNumber}")]
        public IActionResult GetAccount(string accountNumber)
        {
            try
            {
                var account = _accountService.GetAccount(accountNumber);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        [HttpGet]
        //[Route("/user/{userId}")]
        public IActionResult GetAccount([FromQuery] int userId)
        {
            try
            {
                var account = _accountService.GetAccount(userId);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        [HttpPost]
        public IActionResult AddAccount([FromBody] AccountDto account)
        {
            try
            {
                _accountService.AddAccount(account);
                return NoContent();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
                throw;
            }
        }
    }
}
