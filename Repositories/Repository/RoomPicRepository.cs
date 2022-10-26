using BusinessObjects.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoomPicRepository : IRoomPicRepository
    {
        public void AddRoomPic(RoomPic RoomPic) =>  RoomPicDAO.AddRoomPic(RoomPic);
        public void DeleteRoomPic(RoomPic RoomPic) =>  RoomPicDAO.DeleteRoomPic(RoomPic);
        public IEnumerable<RoomPic> GetRoomPicsOfARoom(int RoomId) => RoomPicDAO.GetRoomPicsOfARoom(RoomId);
    }
}
