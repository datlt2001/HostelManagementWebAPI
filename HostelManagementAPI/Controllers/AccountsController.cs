using BusinessObjects.DTOs;
using BusinessObjects.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountRepository repository = new AccountRepository();

        //GET: api/Accounts
        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts() => repository.GetAccounts();

        //POST: AccountsController/Accounts
        [HttpPost]
        public IActionResult PostAccount([FromForm] Account acc)
        {
            acc.UserId = 0;
            acc.IdCardNumberNavigation = null;
            acc.Hostels = null;
            acc.Rents = null;
            repository.AddAccount(acc);
            return NoContent();
        }

        //GET: AccountsController/Delete/4
        [HttpDelete("id")]
        public IActionResult DeleteAccount(int id)
        {
            var acc = repository.GetAccountByID(id);
            if (acc == null)
            {
                return NotFound();
            }

            repository.DeleteAccount(acc);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult UpdateAccount(int id, [FromForm]Account acc)
        {
            var aTmp = repository.GetAccountByID(id);
            if (acc == null)
            {
                return NotFound();
            }
            acc.UserId = aTmp.UserId;
            acc.UserEmail = aTmp.UserEmail;
            acc.IdCardNumberNavigation = aTmp.IdCardNumberNavigation;
            acc.Hostels = aTmp.Hostels;
            acc.Rents = aTmp.Rents;
            repository.UpdateAccount(acc);
            return NoContent();
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AccountLogin accountLogin)
        {
            var result = repository.GetLoginAccount(accountLogin.email, accountLogin.password);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
