using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> Get();
        Task<Vehicle> Get(string VIN);
        Task<Vehicle> Create(Vehicle vehicle);
        Task Update(Vehicle vehicle);
        Task Delete (string VIN);
        Task<VehicleAttribute> AddAttribute(VehicleAttribute attribute);
    }
}
