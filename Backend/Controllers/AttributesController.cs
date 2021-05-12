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
    public class AttributesController : ControllerBase
    {
        private readonly IVehicleRepository _repo;
        public AttributesController(IVehicleRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> PostAttributes([FromBody] VehicleAttribute attribute)
        {
            var existingItem = await _repo.Get(attribute.Vehicle.VIN);
            if (existingItem != null)
            {
                await _repo.AddAttribute(attribute);
                return Created("",attribute);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
