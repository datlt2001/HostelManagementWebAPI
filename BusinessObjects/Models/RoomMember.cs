using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class RoomMember
    {
        public int RoomMemberId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "The {0} must be {2} - {1} characters long.", MinimumLength = 5)]
        public string UserEmail { get; set; }
        public int RentId { get; set; }
        public bool? IsPresentator { get; set; }
        public int? Status { get; set; }

        public virtual Rent Rent { get; set; }
    }
}
