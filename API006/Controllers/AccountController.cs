using API006.Database.Models;
using API006.DTOs;
using API006.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            catch (Exception)
            {
                return StatusCode(500);
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
            catch (Exception)
            {
                return StatusCode(500);
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
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("/withdraw")]
        public ActionResult<Account> Withdraw(string accountNumber, int amount)
        {
            if (amount <= 0 || amount > 10000)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_accountService.Withdraw(accountNumber,amount));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        [HttpPut("/deposit")]
        public ActionResult<Account> Deposit(string accountNumber, int amount)
        {
            if (amount <= 0 || amount > 10000)
            {
                return BadRequest("Invalid amount");
            }
            try
            {
                return Ok(_accountService.Deposit(accountNumber,amount));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        [HttpDelete]
        public ActionResult Delete(string accountNumber)
        {
            return Ok(_accountService.Delete(accountNumber));
        }
    }
}
