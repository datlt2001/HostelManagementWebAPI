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
        private static RoomPicDAO instance = null;
        private static readonly object instanceLock = new object();
        public static RoomPicDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomPicDAO();
                    }
                    return instance;
                }
            }
        }
        private RoomPicDAO() { }
        public async Task AddRoomPic(RoomPic RoomPic)
        {
            try
            {
                RoomPic.RoomPicsId = 0;
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(RoomPic).State = EntityState.Added;
                int a = 3;
                await HostelManagementDBContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [HostelManagement].[dbo].[RoomPics] ON");
                await HostelManagementDBContext.SaveChangesAsync();
                await HostelManagementDBContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [HostelManagement].[dbo].[RoomPics] OFF");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RoomPic>> GetRoomPicsOfARoom(int RoomId)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.RoomPics
                    .Include(h => h.Room)
                    .Where(h => h.RoomId == RoomId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteRoomPic(RoomPic RoomPic)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.RoomPics.Remove(RoomPic);
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
