using BusinessObjects.Models;
using DataAccess.DAO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public void AddRoom(Room Room) =>  RoomDAO.AddRoom(Room);
        public void DeleteRoom(Room Room) =>  RoomDAO.DeleteRoom(Room);

        public Room GetRoomByID(int id) =>  RoomDAO.GetRoomByID(id);

        public IEnumerable<Room> GetRoomList() =>  RoomDAO.GetRoomsList();
        public IEnumerable<Room> GetRoomsOfAHostel(int hostelId) =>  RoomDAO.GetRoomsOfAHostel(hostelId);

        public void UpdateRoom(Room Room) =>  RoomDAO.UpdateRoom(Room);
        public void ActivateRoom(int id) =>  RoomDAO.ActivateRoom(id);
        public void DenyRoom(int id) =>  RoomDAO.DenyRoom(id);
        public void PendingRoom(int id) =>  RoomDAO.PendingRoom(id);
    }
}
