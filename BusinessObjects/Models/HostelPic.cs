using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjects.Models
{
    public partial class HostelPic
    {
        public int HostelPicsId { get; set; }
        public string HostelPicUrl { get; set; }
        public int HostelId { get; set; }

        public virtual Hostel Hostel { get; set; }
    }
}
