using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Data;

namespace DataAccess.DAO
{
    public class BillDAO
    {
        private static BillDAO instance = null;
        private static readonly object instanceLock = new object();
        public static BillDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BillDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task AddBill(Bill bill)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(bill).State = EntityState.Added;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bill> GetBillById(int BillId)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Bills
                    .Include(b => b.BillDetails)
                        .Include(b => b.Rent)
                            .ThenInclude(b => b.Room)
                                .ThenInclude(b => b.Hostel)
                                    .ThenInclude(b => b.HostelOwnerEmailNavigation)
                        .Include(b => b.Rent)
                            .ThenInclude(b => b.RentedByNavigation)
                    .FirstOrDefaultAsync(bill => bill.BillId == BillId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Bill>> GetBillList()
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Bills
                        .Include(b => b.BillDetails)
                        .Include(b => b.Rent)
                            .ThenInclude(b => b.Room)
                                .ThenInclude(b => b.Hostel)
                                    .ThenInclude(b => b.HostelOwnerEmailNavigation)
                        .Include(b => b.Rent)
                            .ThenInclude(b => b.RentedByNavigation)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateBill(Bill Bill)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(Bill).State = EntityState.Modified;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
