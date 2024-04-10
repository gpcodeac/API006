using Microsoft.AspNetCore.Mvc;
using API006.Services.Interfaces;

namespace API006.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
    }
}
