using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class IdentityCard
    {
        public IdentityCard()
        {
            Accounts = new HashSet<Account>();
        }
        [Display(Name = "Identity Card Number")]
        public string IdCardNumber { get; set; }
        [Display(Name = "Front Image")]
        public string FrontIdPicUrl { get; set; }
        [Display(Name = "Back Image")]
        public string BackIdPicUrl { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
