using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoomMemberDAO
    {
        public static void AddRoomMember(RoomMember roomMember)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(roomMember).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<RoomMember> GetRoomMemberList()
        {
            var listHostels = new List<RoomMember>();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    listHostels = context.RoomMembers
                    .Include(r => r.Rent)
                    .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHostels;
        }

        public static void UpdateRoomMember(RoomMember roomMember)
        {
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    context.Attach(roomMember).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static RoomMember GetRoomMemberByID(int id)
        {
            var acc = new RoomMember();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.RoomMembers
                    .Include(r => r.Rent)
                    .FirstOrDefault(m => m.RoomMemberId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public static RoomMember GetRoomMemberByEmail(string email, int rentId)
        {
            var acc = new RoomMember();
            try
            {
                using (var context = new HostelManagementDBContext())
                {
                    acc = context.RoomMembers
                    .Include(r => r.Rent)
                    .FirstOrDefault(m => m.UserEmail == email && m.RentId == rentId);
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
