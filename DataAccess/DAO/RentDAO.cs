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
        public static void AddRent(Rent Rent)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(Rent).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<Rent> GetRentListByRoom(int roomId)
        {
            var listHostels = new List<Rent>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.Rents
                        .Include(r => r.Room)
                        .Include(r => r.RentedByNavigation)
                        .Include(r => r.RoomMembers)
                        .Include(r => r.Bills)
                        .Where(r => r.RoomId == roomId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }

        public static IEnumerable<Rent> GetRentList()
        {
            var listHostels = new List<Rent>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.Rents
                        .Include(r => r.Room)
                            .ThenInclude(r => r.Hostel)
                                .ThenInclude(r => r.HostelOwnerEmailNavigation)
                        .Include(r => r.RentedByNavigation)
                        .Include(r => r.RoomMembers)
                        .Include(r => r.Bills.OrderByDescending(b => b.CreatedDate))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }

        public static Rent GetRentByID(int id)
        {
            var acc = new Rent();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.Rents
                    .Include(r => r.Room)
                            .ThenInclude(r => r.Hostel)
                                .ThenInclude(r => r.HostelOwnerEmailNavigation)
                    .Include(r => r.RentedByNavigation)
                    .Include(r => r.RoomMembers)
                    .Include(r => r.Bills.OrderByDescending(b => b.CreatedDate))
                        .ThenInclude(r => r.BillDetails)
                    .FirstOrDefault(r => r.RentId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public static void UpdateRent(Rent rent)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(rent).State = EntityState.Modified;
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
