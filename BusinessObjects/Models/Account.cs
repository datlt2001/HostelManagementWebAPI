﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class Account
    {
        public Account()
        {
            Hostels = new HashSet<Hostel>();
            Rents = new HashSet<Rent>();
        }

        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "The {0} must be {2} - {1} characters long.", MinimumLength = 5)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format")]
        public string UserEmail { get; set; }
        [StringLength(30, ErrorMessage = "The {0} must be {2} - {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        public int Status { get; set; }
        [Display(Name = "Fullname")]
        public string FullName { get; set; }
        [Phone]
        [StringLength(15, ErrorMessage = "The {0} must be {2} - {1} characters long.", MinimumLength = 9)]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime? Dob { get; set; }
        [Display(Name = "Avatar")]
        public string ProfilePicUrl { get; set; }
        [Display(Name = "Identity Card Number")]
        public string IdCardNumber { get; set; }

        public virtual IdentityCard IdCardNumberNavigation { get; set; }
        public virtual ICollection<Hostel> Hostels { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
