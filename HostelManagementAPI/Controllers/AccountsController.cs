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
        public IActionResult PostAccount(Account acc)
        {
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
        public IActionResult UpdateAccount(int id, Account acc)
        {
            var aTmp = repository.GetAccountByID(id);
            if (acc == null)
            {
                return NotFound();
            }

            repository.UpdateAccount(acc);
            return NoContent();
        }
    }
}
