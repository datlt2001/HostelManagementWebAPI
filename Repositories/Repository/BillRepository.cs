using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BillRepository : IBillRepository
    {
        public void AddBill(Bill bill) =>  BillDAO.AddBill(bill);
        public void UpdateBill(Bill bill) =>  BillDAO.UpdateBill(bill);
        public Bill GetBillById(int BillId) =>  BillDAO.GetBillById(BillId);
        public IEnumerable<Bill> GetBillList() =>  BillDAO.GetBillList();
    }
}
