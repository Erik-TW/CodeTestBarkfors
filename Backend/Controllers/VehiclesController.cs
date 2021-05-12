using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _repo;
        public VehiclesController(IVehicleRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _repo.Get();
        }

        [HttpGet("{VIN}")]
        public async Task<ActionResult<Vehicle>> GetVehicles(string VIN)
        {
            return await _repo.Get(VIN);
        }
        [HttpPost]
        public async Task<ActionResult> PostVehicles ([FromBody] Vehicle vehicle)
        {
            var existingItem = await _repo.Get(vehicle.VIN);
            if(existingItem == null)
            {
                var item = await _repo.Create(vehicle);
                return Created("",vehicle);
            }
            else
            {
                return BadRequest();
            }           
        }
        [HttpPut]
        public async Task<ActionResult> PutVehicles([FromBody] Vehicle vehicle)
        {
            var existingItem = await _repo.Get(vehicle.VIN);
            if (existingItem != null)
            {
                await _repo.Update(vehicle);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{VIN}")]
        public async Task<ActionResult> DeleteVehicles(string VIN)
        {
            var existingItem = await _repo.Get(VIN);
            if (existingItem != null)
            {
                await _repo.Delete(VIN);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
