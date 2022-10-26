using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class HostelDAO
    {
        public static void AddHostel(Hostel hostel)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(hostel).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteHostel(Hostel hostel)
        {
            throw new NotImplementedException();
        }

        public static Hostel GetHostelByID(int id)
        {
            var acc = new Hostel();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.Hostels
                    .Include(h => h.Rooms)
                        .ThenInclude(h => h.RoomPics)
                    .Include(h => h.Category)
                    .Include(h => h.HostelOwnerEmailNavigation)
                    .Include(h => h.Location)
                        .ThenInclude(h => h.Ward)
                            .ThenInclude(h => h.District)
                                .ThenInclude(h => h.Province)
                    .Include(h => h.HostelPics)
                    .FirstOrDefault(hostel => hostel.HostelId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public static IEnumerable<Hostel> GetHostelsList()
        {
            var listHostels = new List<Hostel>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.Hostels
                    .Include(h => h.Rooms)
                    .Include(h => h.Category)
                    .Include(h => h.Location)
                        .ThenInclude(h => h.Ward)
                            .ThenInclude(h => h.District)
                                .ThenInclude(h => h.Province)
                    .Include(h => h.HostelPics)
                    .Include(h => h.HostelOwnerEmailNavigation)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }

        public static void UpdateHostel(Hostel hostel)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(hostel).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<Hostel> GetHostelsOfAnOwner(int id)
        {
            var accs = new List<Hostel>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    accs = context.Hostels
                    .Include(h => h.Rooms)
                    .Include(h => h.Category)
                    .Include(h => h.Location)
                        .ThenInclude(h => h.Ward)
                            .ThenInclude(h => h.District)
                                .ThenInclude(h => h.Province)
                    .Include(h => h.HostelPics)
                    .Include(h => h.HostelOwnerEmailNavigation)
                    //.ThenInclude(h => h.UserId)
                    .Where(h => h.HostelOwnerEmailNavigation.UserId == id)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accs;
        }

        public static void DeactivateHostel(int id)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    var hostel = context.Hostels.SingleOrDefault(a => a.HostelId.Equals(id));
                    context.Attach(hostel).State = EntityState.Modified;
                    hostel.Status = 2;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ActivateHostel(int id)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    var hostel = context.Hostels.SingleOrDefault(a => a.HostelId.Equals(id));
                    context.Attach(hostel).State = EntityState.Modified;
                    hostel.Status = 1;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DenyHostel(int id)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    var hostel = context.Hostels.SingleOrDefault(a => a.HostelId.Equals(id));
                    context.Attach(hostel).State = EntityState.Modified;
                    hostel.Status = 3;
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