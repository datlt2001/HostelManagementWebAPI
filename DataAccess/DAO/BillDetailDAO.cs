using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BillDetailDAO
    {

        public static void AddBillDetail(BillDetail billDetail)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(billDetail).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<BillDetail> GetBillDetailList()
        {
            var listBillDetails = new List<BillDetail>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listBillDetails = context.BillDetails
                    .Include(b => b.Bill)
                        .ThenInclude(b => b.Rent)
                            .ThenInclude(b => b.Room)
                                .ThenInclude(b => b.Hostel)
                                    .ThenInclude(b => b.HostelOwnerEmailNavigation)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBillDetails;
        }
    }
}