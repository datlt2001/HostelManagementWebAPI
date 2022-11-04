using BusinessObjects.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HostelManagementAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelsController : ControllerBase
    {
        private IHostelRepository repository = new HostelRepository();
        [Authorize(Roles = "Admin")]
        //GET: api/Hostels
        [HttpGet]
        public async Task<IEnumerable<Hostel>> GetHostels() => await repository.GetHostelsList();
        //GET
        [HttpGet("GetHostelsOfAnOwner/{id}")]
        public async Task<IEnumerable<Hostel>> GetHostelsOfAnOwner(int id) => await repository.GetHostelsOfAnOwner(id);

        //PUT
        [HttpPut("DeactivateHostel/{id}")]
        public async Task<IActionResult> DeactivateHostel(int id)
        {
            var hostel = await repository.GetHostelByID(id);
            if (hostel == null)
            {
                return NotFound();
            }
            await repository.DeactivateHostel(id);
            return NoContent();
        }

        //PUT
        [HttpPut("ActivateHostel/{id}")]
        public async Task<IActionResult> ActivateHostel(int id)
        {
            var hostel = await repository.GetHostelByID(id);
            if (hostel == null)
            {
                return NotFound();
            }
            await repository.ActivateHostel(id);
            return NoContent();
        }

        //PUT
        [HttpPut("DenyHostel/{id}")]
        public async Task<IActionResult> DenyHostel(int id)
        {
            var hostel = await repository.GetHostelByID(id);
            if (hostel == null)
            {
                return NotFound();
            }
            await repository.DenyHostel(id);
            return NoContent();
        }

        // GET api/<HostelsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hostel = await repository.GetHostelByID(id);
            if (hostel == null)
            {
                return NotFound();
            }

            return Ok(hostel);
        }

        //POST: HostelsController/Hostels
        [HttpPost]
        public async Task<IActionResult> PostHostel([FromForm] Hostel hostel)
        {
            hostel.HostelId = 0;
            hostel.Category = null;
            hostel.HostelOwnerEmailNavigation = null;
            hostel.Location = null;
            await repository.AddHostel(hostel);
            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateHostel(int id, [FromForm] Hostel hostel)
        {
            var aTmp = await repository.GetHostelByID(id);
            if (aTmp == null)
            {
                return NotFound();
            }
            await repository.UpdateHostel(hostel);
            return NoContent();
        }

        // DELETE api/<HostelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
