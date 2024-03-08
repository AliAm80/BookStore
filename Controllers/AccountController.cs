using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Interfaces;
using BookStore.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignUpDto signUpDto)
        {
            var result = await _accountRepository.SignUp(signUpDto);
            if (result.Succeeded)
                return Ok();
            return BadRequest(result.Errors.Select(x => x.Description).ToList());
        }
    }
}