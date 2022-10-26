using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRoomMemberRepository
    {
        void AddRoomMember(RoomMember RoomMember);
        IEnumerable<RoomMember> GetRoomMemberList();
        void UpdateRoomMember(RoomMember Room);
        RoomMember GetRoomMemberByID(int id);
        RoomMember GetRoomMemberByEmail(string email, int rentId);
    }
}
