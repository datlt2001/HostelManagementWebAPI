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
    public class LocationDAO
    {
        public static void AddLocation(Location Location)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(Location).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Location GetLocationByID(int id)
        {
            var acc = new Location();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.Locations
                    .Include(l => l.Ward)
                        .ThenInclude(l => l.District)
                            .ThenInclude(l => l.Province)
                    .SingleOrDefault(location => location.LocationId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public static IEnumerable<Location> GetLocationsList()
        {
            var listHostels = new List<Location>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.Locations
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }

        public static void UpdateLocation(Location location)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(location).State = EntityState.Modified;
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
