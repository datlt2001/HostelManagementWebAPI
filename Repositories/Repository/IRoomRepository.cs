using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRoomRepository
    {
        Room GetRoomByID(int id);
        void UpdateRoom(Room Room);
        void DeleteRoom(Room Room);
        void AddRoom(Room Room);
        IEnumerable<Room> GetRoomList();
        IEnumerable<Room> GetRoomsOfAHostel(int hostelId);
        void ActivateRoom(int id);
        void DenyRoom(int id);
        void PendingRoom(int id);
    }
}
