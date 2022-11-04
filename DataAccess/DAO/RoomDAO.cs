using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance = null;
        private static readonly object instanceLock = new object();
        public static RoomDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomDAO();
                    }
                    return instance;
                }
            }
        }
        public async Task AddRoom(Room room)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(room).State = EntityState.Added;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteRoom(Room Room)
        {
            throw new NotImplementedException();
        }

        public async Task<Room> GetRoomByID(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Rooms
                    .Include(r => r.Hostel)
                        .ThenInclude(r => r.HostelOwnerEmailNavigation)
                    .Include(r => r.RoomPics)
                    .Include(r => r.Rents)
                    .FirstOrDefaultAsync(m => m.RoomId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Room>> GetRoomsList()
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Rooms
                    .Include(r => r.Hostel)
                        .ThenInclude(h => h.HostelOwnerEmailNavigation)
                    .Include(r => r.RoomPics)
                    .Include(r => r.Rents)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Room>> GetRoomsOfAHostel(int hostelId)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.Rooms
                        .Include(r => r.Hostel)
                        .Include(r => r.RoomPics)
                        .Include(r => r.Rents)
                        .Where(r => r.HostelId == hostelId)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRoom(Room room)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(room).State = EntityState.Modified;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task ActivateRoom(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                var room = HostelManagementDBContext.Rooms.SingleOrDefault(h => h.RoomId.Equals(id));
                HostelManagementDBContext.Rooms.Attach(room);
                room.Status = 1;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DenyRoom(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                var room = HostelManagementDBContext.Rooms.SingleOrDefault(h => h.RoomId.Equals(id));
                HostelManagementDBContext.Rooms.Attach(room);
                room.Status = 3;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task PendingRoom(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                var room = HostelManagementDBContext.Rooms.SingleOrDefault(h => h.RoomId.Equals(id));
                HostelManagementDBContext.Rooms.Attach(room);
                room.Status = 0;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
