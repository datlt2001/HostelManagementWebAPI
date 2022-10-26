using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BillDAO
    {
        
        public static void AddBill(Bill bill)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(bill).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Bill GetBillById(int BillId)
        {
            var bill = new Bill();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    bill = context.Bills
                    .Include(b => b.BillDetails)
                        .Include(b => b.Rent)
                            .ThenInclude(b => b.Room)
                                .ThenInclude(b => b.Hostel)
                                    .ThenInclude(b => b.HostelOwnerEmailNavigation)
                        .Include(b => b.Rent)
                            .ThenInclude(b => b.RentedByNavigation)
                    .FirstOrDefault(bill => bill.BillId == BillId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bill;
        }

        public static IEnumerable<Bill> GetBillList()
        {
            var listBills = new List<Bill>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listBills = context.Bills
                        .Include(b => b.BillDetails)
                        .Include(b => b.Rent)
                            .ThenInclude(b => b.Room)
                                .ThenInclude(b => b.Hostel)
                                    .ThenInclude(b => b.HostelOwnerEmailNavigation)
                        .Include(b => b.Rent)
                            .ThenInclude(b => b.RentedByNavigation)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listBills;
        }

        public static void UpdateBill(Bill Bill)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(Bill).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}