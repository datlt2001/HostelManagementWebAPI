using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRoomPicRepository
    {
        void AddRoomPic(RoomPic RoomPic);
        IEnumerable<RoomPic> GetRoomPicsOfARoom(int RoomId);
        void DeleteRoomPic(RoomPic RoomPic);
    }
}
