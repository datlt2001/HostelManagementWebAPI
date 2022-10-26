using BusinessObjects.Models;
using DataAccess.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoomMemberRepository : IRoomMemberRepository
    {
        public void AddRoomMember(RoomMember RoomMember) =>  RoomMemberDAO.AddRoomMember(RoomMember);
        public IEnumerable<RoomMember> GetRoomMemberList() =>  RoomMemberDAO.GetRoomMemberList();
        public RoomMember GetRoomMemberByID(int id) =>  RoomMemberDAO.GetRoomMemberByID(id);
        public void UpdateRoomMember(RoomMember RoomMember) =>  RoomMemberDAO.UpdateRoomMember(RoomMember);
        public RoomMember GetRoomMemberByEmail(string email, int rentId) =>  RoomMemberDAO.GetRoomMemberByEmail(email, rentId);
    }
}
