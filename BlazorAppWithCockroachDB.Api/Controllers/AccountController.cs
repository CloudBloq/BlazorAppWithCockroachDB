using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CockroachDbLib.Models;
using CockroachDbLib.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWithCockroachDB.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllAccounts()
        {
            List<Account> allAccounts = accountRepository.GetAllAccounts();

            if (allAccounts.Count == 0)
            {
                return BadRequest("No account exit, try creating a new account");
            }

            return Ok(allAccounts);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetAccount(int? id)
        {
            Account account = await accountRepository.GetAccountById(id);

            if(account == null)
            {
                return NotFound($"Account with Id {id} doesn't exit");
            }

            return Ok(account);
        }


        [HttpGet("GetLastAccountId")]
        public int GetLastAccountId()
        {
            return accountRepository.GetLastAccountId();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Account newAccount)
        {
            Account createdAccount = await accountRepository.CreateAccount(newAccount);

            if(createdAccount != null)
            {
                return new CreatedAtActionResult("GetAccount", "Account", new { createdAccount.id }, createdAccount);
            }
            else
            {
                return BadRequest("Error occured please try again.");
            }
        }

        [HttpPost("Update")]
        public IActionResult UpdateAccount([FromBody] Account account)
        {
            accountRepository.UpdateAccount(account);

            return Ok("Account updated successfully.");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            string result = await accountRepository.DeleteAccount(id);

            if(result == null)
            {
                return BadRequest("Account doesn't exit");
            }

            return Ok("Account deleted successfully");
        }
    }
}
