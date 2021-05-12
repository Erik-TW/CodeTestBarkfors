using Backend.Data;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {

        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            using (var db = new VehicleDBContext())
            {
                db.Vehicles.Add(vehicle);
                await db.SaveChangesAsync();
                return vehicle;
            }
        }

        public async Task Delete(string VIN)
        {
            using (var db = new VehicleDBContext())
            {
                var itemToDelete = db.Vehicles.Find(VIN);
                db.Vehicles.Remove(itemToDelete);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Vehicle>> Get()
        {
            using (var db = new VehicleDBContext())
            {
                return db.Vehicles.ToList<Vehicle>();
            }
        }

        public async Task<Vehicle> Get(string VIN)
        {
            using (var db = new VehicleDBContext())
            {
                return await db.Vehicles.FindAsync(VIN);
            }
        }

        public async Task Update(Vehicle vehicle)
        {
            using (var db = new VehicleDBContext())
            {
                db.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<VehicleAttribute>> GetAttributesOfVehicle(string VIN)
        {
            using (var db = new VehicleDBContext())
            {
                var query = from attribute in db.VehicleAttributes
                            where attribute.Vehicle.VIN.Equals(VIN)
                            select attribute;
                return query.ToList();
            }
        }

        public async Task<VehicleAttribute> AddAttribute(VehicleAttribute attribute)
        {
            using (var db = new VehicleDBContext())
            {
                var item = await Get(attribute.Vehicle.VIN);
                if (item != null)
                {
                    db.VehicleAttributes.Add(attribute);
                    await db.SaveChangesAsync();
                    return attribute;
                }
            }
            return null;
        }
    }
}
