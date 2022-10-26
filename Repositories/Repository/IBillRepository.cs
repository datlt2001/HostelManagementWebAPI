using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBillRepository
    {
        void AddBill(Bill bill);
        void UpdateBill(Bill bill);
        Bill GetBillById(int BillId);
        IEnumerable<Bill> GetBillList();
    }
}
