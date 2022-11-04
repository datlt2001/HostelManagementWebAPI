using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RentDAO
    {
        private static RentDAO instance = null;
        private static readonly object instanceLock = new object();
        public static RentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RentDAO();
                    }
                    return instance;
                }
            }
        }
        private RentDAO() { }
        public async Task AddRent(Rent Rent)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(Rent).State = EntityState.Added;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Rent>> GetRentListByRoom(int roomId)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Rents
                        .Include(r => r.Room)
                        .Include(r => r.RentedByNavigation)
                        .Include(r => r.RoomMembers)
                        .Include(r => r.Bills)
                        .Where(r => r.RoomId == roomId)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Rent>> GetRentList()
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Rents
                        .Include(r => r.Room)
                            .ThenInclude(r => r.Hostel)
                                .ThenInclude(r => r.HostelOwnerEmailNavigation)
                        .Include(r => r.RentedByNavigation)
                        .Include(r => r.RoomMembers)
                        .Include(r => r.Bills.OrderByDescending(b => b.CreatedDate))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Rent> GetRentByID(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Rents
                    .Include(r => r.Room)
                            .ThenInclude(r => r.Hostel)
                                .ThenInclude(r => r.HostelOwnerEmailNavigation)
                    .Include(r => r.RentedByNavigation)
                    .Include(r => r.RoomMembers)
                    .Include(r => r.Bills.OrderByDescending(b => b.CreatedDate))
                        .ThenInclude(r => r.BillDetails)
                    .FirstOrDefaultAsync(r => r.RentId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRent(Rent rent)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(rent).State = EntityState.Modified;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
