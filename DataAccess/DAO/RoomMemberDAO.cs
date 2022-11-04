using BusinessObjects.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class RoomMemberDAO
    {
        private static RoomMemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static RoomMemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomMemberDAO();
                    }
                    return instance;
                }
            }
        }
        public async Task AddRoomMember(RoomMember roomMember)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(roomMember).State = EntityState.Added;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RoomMember>> GetRoomMemberList()
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.RoomMembers
                    .Include(r => r.Rent)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRoomMember(RoomMember roomMember)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                HostelManagementDBContext.Attach(roomMember).State = EntityState.Modified;
                await HostelManagementDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<RoomMember> GetRoomMemberByID(int id)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.RoomMembers
                    .Include(r => r.Rent)
                    .FirstOrDefaultAsync(m => m.RoomMemberId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RoomMember> GetRoomMemberByEmail(string email, int rentId)
        {
            try
            {
                var HostelManagementDBContext = new HostelManagementDBContext();
                return await HostelManagementDBContext.RoomMembers
                    .Include(r => r.Rent)
                    .FirstOrDefaultAsync(m => m.UserEmail == email && m.RentId == rentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
