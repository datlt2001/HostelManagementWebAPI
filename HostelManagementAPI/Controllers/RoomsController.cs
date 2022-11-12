using BusinessObjects.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private IRoomRepository repository = new RoomRepository();

        [HttpGet]
        public async Task<IEnumerable<Room>> GetRooms() => await repository.GetRoomList();

        [HttpGet("GetRoomsOfAHostel/{id}")]
        public async Task<IEnumerable<Room>> GetRoomsOfAHostel(int id) => await repository.GetRoomsOfAHostel(id);
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomByID(int id)
        {
            var hostel = await repository.GetRoomByID(id);
            if (hostel == null)
            {
                return NotFound();
            }

            return Ok(hostel);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateRoom(int id, [FromForm] Room room)
        {
            var aTmp = await repository.GetRoomByID(id);
            if (aTmp == null)
            {
                return NotFound();
            }
            await repository.UpdateRoom(room);
            return NoContent();
        }

        //PUT
        [HttpPut("ActivateRoom/{id}")]
        public async Task<IActionResult> ActivateRoom(int id)
        {
            var room = await repository.GetRoomByID(id);
            if (room == null)
            {
                return NotFound();
            }
            await repository.ActivateRoom(id);
            return NoContent();
        }

        //PUT
        [HttpPut("DenyRoom/{id}")]
        public async Task<IActionResult> DenyRoom(int id)
        {
            var room = await repository.GetRoomByID(id);
            if (room == null)
            {
                return NotFound();
            }
            await repository.DenyRoom(id);
            return NoContent();
        }

        //PUT
        [HttpPut("PendingRoom/{id}")]
        public async Task<IActionResult> PendingRoom(int id)
        {
            var room = await repository.GetRoomByID(id);
            if (room == null)
            {
                return NotFound();
            }
            await repository.PendingRoom(id);
            return NoContent();
        }
    }
}
