using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class HostelPicDAO
    {
        public static void AddHostelPic(HostelPic hostelPic)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(hostelPic).State = EntityState.Added;
                    context.SaveChanges();

                    //HostelManagementContext.Attach(hostelPic).State = EntityState.Added;
                    //await HostelManagementContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [HostelManagement].[dbo].[HostelPics] ON");
                    //await HostelManagementContext.SaveChangesAsync();
                    //await HostelManagementContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [HostelManagement].[dbo].[HostelPics] OFF");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<HostelPic> GetHostelPicsOfAHostel(int hostelId)
        {
            var listHostels = new List<HostelPic>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.HostelPics
                    .Include(h => h.Hostel)
                    .Where(h => h.HostelId == hostelId)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }

        public static void DeleteHostelPic(HostelPic hostelPic)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.HostelPics.Remove(hostelPic);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static HostelPic GetHostelPic(int id)
        {
            var acc = new HostelPic();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.HostelPics.SingleOrDefault(hp => hp.HostelPicsId.Equals(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }
    }
}