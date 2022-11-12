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
    public class RentsController : ControllerBase
    {
        private IRentRepository repository = new RentRepository();

        [HttpGet]
        public async Task<IEnumerable<Rent>> GetRentList() => await repository.GetRentList();
        //GET
        [HttpGet("GetRentListByRoom/{id}")]
        public async Task<IEnumerable<Rent>> GetRentListByRoom(int id) => await repository.GetRentListByRoom(id);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentByID(int id)
        {
            var rent = await repository.GetRentByID(id);
            if (rent == null)
            {
                return NotFound();
            }

            return Ok(rent);
        }

        //POST: RentsController/Rents
        [HttpPost]
        public async Task<IActionResult> PostRent([FromForm] Rent rent)
        {
            await repository.AddRent(rent);
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateRent(int id, [FromForm] Rent rent)
        {
            var aTmp = await repository.GetRentByID(id);
            if (aTmp == null)
            {
                return NotFound();
            }
            await repository.UpdateRent(rent);
            return NoContent();
        }
    }
}
