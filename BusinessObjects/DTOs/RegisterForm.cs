using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessObjects.DTOs
{
    public class RegisterForm
    {
        public Account account { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be {2} to {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        //[Compare(nameof(account.UserPassword), ErrorMessage = "Did not match with password")]
        public string ConfirmPassword { get; set; }
        public IdentityCard IdCard { get; set; }
        public IFormFile FrontPicUrl { get; set; }
        public IFormFile BackPicUrl { get; set; }
    }
}
