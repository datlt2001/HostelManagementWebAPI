using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int BillId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int RentId { get; set; }

        public virtual Rent Rent { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
