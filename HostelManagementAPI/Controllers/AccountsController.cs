using BusinessObjects.DTOs;
using BusinessObjects.Models;
using DataAccess.Repository;
using HostelManagementAPI.Helpers;
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
        private IIdentityCardRepository identityCardRepository = new IdentityCardRepository();
        //GET: api/Accounts
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var isSuccessResult = await repository.GetAccountList();
            if (isSuccessResult == null) return BadRequest();
            return Ok(isSuccessResult);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string searchUser)
        {
            var isSuccessResult = await repository.GetAccountList();
            if (!String.IsNullOrEmpty(searchUser))
            {
                isSuccessResult = isSuccessResult.Where(a => a.FullName.ToLower().Contains(searchUser.ToLower()) ||
                                            a.UserEmail.ToLower().Contains(searchUser.ToLower()))
                                        .ToList();
            }
            if (isSuccessResult == null) return BadRequest();
            return Ok(isSuccessResult);
        }
        //POST: AccountsController/Accounts
        [HttpPost]
        public async Task<IActionResult> PostAccount([FromForm] Account acc)
        {
            acc.UserId = 0;
            acc.IdCardNumberNavigation = null;
            acc.Hostels = null;
            acc.Rents = null;
            await repository.AddAccount(acc);
            return Ok(acc);
        }
        [HttpGet("Deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            await repository.InactivateUser(id);
            return Ok();
        }

        [HttpGet("Reactivate")]
        public async Task<IActionResult> Reactivate(int id)
        {
            await repository.ActivateUser(id);
            return Ok();
        }

        //GET: AccountsController/Delete/4
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var acc = await repository .GetAccountByID(id);
            if (acc == null)
            {
                return NotFound();
            }

            await repository.DeleteAccount(acc);
            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody]Account acc)
        {
            var aTmp = await repository.GetAccountByID(id);
            if (acc == null)
            {
                return NotFound();
            }
            acc.UserId = aTmp.UserId;
            acc.UserEmail = aTmp.UserEmail;
            acc.IdCardNumberNavigation = aTmp.IdCardNumberNavigation;
            acc.Hostels = aTmp.Hostels;
            acc.Rents = aTmp.Rents;
            await repository.UpdateAccount(acc);
            return Ok(acc);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AccountLogin accountLogin)
        {
            var result = await repository.GetLoginAccount(accountLogin.email, accountLogin.password);
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

                await HttpContext.SignInAsync(
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

                await HttpContext.SignInAsync(
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

                await HttpContext.SignInAsync(
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
        
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var acc = await repository.GetAccountByID(id);
            if (acc == null)
            {
                return NotFound();
            }

            return Ok(acc);
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromForm] RegisterForm Input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (CheckExist(Input.account.UserEmail))
            {
                return new JsonResult(new { MessageExistEmail = "Email is existing. Please choose other email." }); 
            }
            else if (IdExists(Input.account.IdCardNumber))
            {
                return new JsonResult(new { MessageExistId = "ID is existing. Please choose other ID." });
                
            }
            else if (!CheckDob(Input.account.Dob))
            {
                return new JsonResult(new { MessageDob = "Invalid DOB. Your age must be 16 or greater." });
            }
            else
            {
                Account acc = null;
                Input.IdCard.IdCardNumber = Input.account.IdCardNumber;
                if (Input.FrontPicUrl != null && Input.BackPicUrl != null)
                {
                    Input.IdCard.FrontIdPicUrl = await Utilities.UploadFile(Input.FrontPicUrl, @"images\accounts\idCard", Input.FrontPicUrl.FileName);
                    Input.IdCard.BackIdPicUrl = await Utilities.UploadFile(Input.BackPicUrl, @"images\accounts\idCard", Input.BackPicUrl.FileName);
                }
                await identityCardRepository.AddIdCard(Input.IdCard);
                var account = new Account()
                {

                    UserEmail = Input.account.UserEmail,
                    FullName = Input.account.FullName,
                    UserPassword = Input.account.UserPassword,
                    PhoneNumber = Input.account.PhoneNumber,
                    RoleName = "renter",
                    Status = 1,
                    Dob = Input.account.Dob,
                    IdCardNumber = Input.account.IdCardNumber,
                    IdCardNumberNavigation = Input.IdCard
                };


                await repository.AddAccount(account);

                acc = repository.GetAccountByEmail(account.UserEmail).Result;
                HttpContext.Session.SetInt32("isLoggedIn", 1);
                HttpContext.Session.SetInt32("ID", acc.UserId);
                HttpContext.Session.SetString("ContactName", acc.FullName);
                string success = $"Email {acc.UserEmail} register successfully.";
                HttpContext.Session.SetString("RegisterSuccess", success);
                return Ok(acc);
            }
        }

        private bool CheckDob(DateTime? Dob)
        {
            TimeSpan timeDifference = DateTime.Now - Dob.Value;
            double Age = timeDifference.TotalDays / 365.2425;
            if (Age >= 16 && Age <= 100) return true;
            else return false;
        }

        private bool IdExists(string idCardNumber)
        {
            Task<IdentityCard> idCard = identityCardRepository.GetIdentityCardByID(idCardNumber);
            if (idCard.Result != null) return true;
            else return false;
        }

        private bool CheckExist(string userEmail)
        {
            var acc = repository.GetAccountByEmail(userEmail);
            if (acc.Result != null) return true;
            else return false;
        }
    }
}
