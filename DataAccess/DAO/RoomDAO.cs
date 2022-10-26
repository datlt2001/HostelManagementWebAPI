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
        public static void AddRoom(Room room)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(room).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteRoom(Room Room)
        {
            throw new NotImplementedException();
        }

        public static Room GetRoomByID(int id)
        {
            var acc = new Room();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.Rooms
                    .Include(r => r.Hostel)
                        .ThenInclude(r => r.HostelOwnerEmailNavigation)
                    .Include(r => r.RoomPics)
                    .Include(r => r.Rents)
                    .FirstOrDefault(m => m.RoomId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public static IEnumerable<Room> GetRoomsList()
        {
            var listHostels = new List<Room>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.Rooms
                    .Include(r => r.Hostel)
                        .ThenInclude(h => h.HostelOwnerEmailNavigation)
                    .Include(r => r.RoomPics)
                    .Include(r => r.Rents)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }

        public static IEnumerable<Room> GetRoomsOfAHostel(int hostelId)
        {
            var listHostels = new List<Room>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.Rooms
                        .Include(r => r.Hostel)
                        .Include(r => r.RoomPics)
                        .Include(r => r.Rents)
                        .Where(r => r.HostelId == hostelId)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }

        public static void UpdateRoom(Room room)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(room).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ActivateRoom(int id)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    var room = context.Rooms.SingleOrDefault(h => h.RoomId.Equals(id));
                    context.Attach(room).State = EntityState.Modified;
                    room.Status = 1;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DenyRoom(int id)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    var room = context.Rooms.SingleOrDefault(h => h.RoomId.Equals(id));
                    context.Attach(room).State = EntityState.Modified;
                    room.Status = 3;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void PendingRoom(int id)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    var room = context.Rooms.SingleOrDefault(h => h.RoomId.Equals(id));
                    context.Attach(room).State = EntityState.Modified;
                    room.Status = 0;
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
