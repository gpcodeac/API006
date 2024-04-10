using API006.Database.Models;
using Microsoft.AspNetCore.Mvc;
using API006.Services.Interfaces;

namespace API006.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
