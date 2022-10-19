using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class RoomMember
    {
        public int RoomMemberId { get; set; }
        public string UserEmail { get; set; }
        public int RentId { get; set; }
        public bool? IsPresentator { get; set; }
        public int? Status { get; set; }

        public virtual Rent Rent { get; set; }
    }
}
