using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBillDetailRepository
    {
        void AddBillDetail(BillDetail billDetail);
        IEnumerable<BillDetail> GetBillDetailList();
    }
}
