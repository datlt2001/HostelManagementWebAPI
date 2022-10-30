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
        public IEnumerable<Hostel> GetHostels() => repository.GetHostelsList();
        //GET
        [HttpGet("GetHostelsOfAnOwner/{id}")]
        public IEnumerable<Hostel> GetHostelsOfAnOwner(int id) => repository.GetHostelsOfAnOwner(id);

        //PUT
        [HttpPut("DeactivateHostel/{id}")]
        public IActionResult DeactivateHostel(int id)
        {
            var hostel = repository.GetHostelByID(id);
            if (hostel == null)
            {
                return NotFound();
            }
            repository.DeactivateHostel(id);
            return NoContent();
        }

        //PUT
        [HttpPut("ActivateHostel/{id}")]
        public IActionResult ActivateHostel(int id)
        {
            var hostel = repository.GetHostelByID(id);
            if (hostel == null)
            {
                return NotFound();
            }
            repository.ActivateHostel(id);
            return NoContent();
        }

        //PUT
        [HttpPut("DenyHostel/{id}")]
        public IActionResult DenyHostel(int id)
        {
            var hostel = repository.GetHostelByID(id);
            if (hostel == null)
            {
                return NotFound();
            }
            repository.DenyHostel(id);
            return NoContent();
        }

        // GET api/<HostelsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hostel = repository.GetHostelByID(id);
            if (hostel == null)
            {
                return NotFound();
            }

            return Ok(hostel);
        }

        //POST: HostelsController/Hostels
        [HttpPost]
        public IActionResult PostHostel([FromForm] Hostel hostel)
        {
            hostel.HostelId = 0;
            hostel.Category = null;
            hostel.HostelOwnerEmailNavigation = null;
            hostel.Location = null;
            repository.AddHostel(hostel);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult UpdateHostel(int id, [FromForm] Hostel hostel)
        {
            var aTmp = repository.GetHostelByID(id);
            if (aTmp == null)
            {
                return NotFound();
            }
            repository.UpdateHostel(hostel);
            return NoContent();
        }

        // DELETE api/<HostelsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
