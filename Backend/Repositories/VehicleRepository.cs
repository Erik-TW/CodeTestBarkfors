using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
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
                var query =  db.Vehicles
                     .ToList();
                foreach(Vehicle v in query)
                {
                    var item = await db.Vehicles.FindAsync(v.VIN);
                    v.Attributes = await GetAttributesOfVehicle(v.VIN);
                }

                return query;
            }
        }

        public async Task<Vehicle> Get(string VIN)
        {
            using (var db = new VehicleDBContext())
            {
                var item = await db.Vehicles.FindAsync(VIN);
                if(item != null)
                {
                    var attributes = await GetAttributesOfVehicle(VIN);
                    if(attributes != null)
                    {
                    item.Attributes = attributes;
                    }
                }
                return item;
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
                var item = await Get(attribute.VehicleVIN);
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
