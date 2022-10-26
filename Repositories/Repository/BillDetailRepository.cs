using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BillDetailRepository : IBillDetailRepository
    {
        public void AddBillDetail(BillDetail billDetail) => BillDetailDAO.AddBillDetail(billDetail);
        public IEnumerable<BillDetail> GetBillDetailList() => BillDetailDAO.GetBillDetailList();
    }
}
