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
    public class RoomPicDAO
    {
        public static void AddRoomPic(RoomPic RoomPic)
        {
            try
            {
                //RoomPic.RoomPicsId = 0;
                //var HostelManagementContext = new HostelManagementContext();
                //HostelManagementContext.Attach(RoomPic).State = EntityState.Added;
                //int a = 3;
                //await HostelManagementContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [HostelManagement].[dbo].[RoomPics] ON");
                //await HostelManagementContext.SaveChangesAsync();
                //await HostelManagementContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [HostelManagement].[dbo].[RoomPics] OFF");
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(RoomPic).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<RoomPic> GetRoomPicsOfARoom(int RoomId)
        {
            var listHostels = new List<RoomPic>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.RoomPics
                    .Include(h => h.Room)
                    .Where(h => h.RoomId == RoomId)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }

        public static void DeleteRoomPic(RoomPic RoomPic)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.RoomPics.Remove(RoomPic);
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
