using BusinessObjects.DTOs;
using BusinessObjects.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            ErrMessage err = new ErrMessage();
            if (result == null)
            {
                return NotFound();
            }
            else if (result.Status != 1)
            {
                err.Message = "Your account is locked!";
                return Ok(err);
            }
            else if (result.RoleName.Equals("admin"))
            {
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, result.UserId.ToString()),
                            new Claim(ClaimTypes.Role, "Admin"),
                            new Claim(ClaimTypes.Name, result.FullName),
                            new Claim(ClaimTypes.Email, result.UserEmail)
                        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                //HttpContext.Session.SetInt32("isLoggedIn", 1);
                //HttpContext.Session.SetString("ContactName", "Admin");
                //HttpContext.Session.SetString("ID", "admin");
                //return RedirectToPage("../AdminDashboard"); //return AdminDashboard

            }
            else if (result.RoleName.Equals("owner"))
            {
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, result.UserId.ToString()),
                            new Claim(ClaimTypes.Role, "Renter"),
                            new Claim(ClaimTypes.Name, result.FullName),
                            new Claim(ClaimTypes.Email, result.UserEmail)
                        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                //HttpContext.Session.SetInt32("isLoggedIn", 1);
                //HttpContext.Session.SetString("ID", cus.Result.CustomerId);
                //HttpContext.Session.SetString("ContactName", cus.Result.ContactName);
                /*var HostelView = HttpContext.Session.GetInt32("HostelID");
                if (HostelView != null)
                {
                    int rv = (int)HostelView;
                    return RedirectToPage("../Hostels/View", new { id = rv });
                }
                else
                {
                    return RedirectToPage("../Index");
                }*/
            }
            else if (result.RoleName.Equals("renter"))
            {
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, result.UserId.ToString()),
                            new Claim(ClaimTypes.Role, "Renter"),
                            new Claim(ClaimTypes.Name, result.FullName),
                            new Claim(ClaimTypes.Email, result.UserEmail)
                        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                //HttpContext.Session.SetInt32("isLoggedIn", 1);
                //HttpContext.Session.SetString("ID", cus.Result.CustomerId);
                //HttpContext.Session.SetString("ContactName", cus.Result.ContactName);
                /*var HostelView = HttpContext.Session.GetInt32("HostelID");
                if (HostelView != null)
                {
                    int rv = (int)HostelView;
                    return RedirectToPage("../Hostels/View", new { id = rv });
                }
                else
                {
                    return RedirectToPage("../Index");
                }
*/
            }

            else
            { 
                err.Message = "Your account or password is incorrect. Try again!";
                return Ok(err);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var acc = repository.GetAccountByID(id);
            if (acc == null)
            {
                return NotFound();
            }

            return Ok(acc);
        }
    }
}
