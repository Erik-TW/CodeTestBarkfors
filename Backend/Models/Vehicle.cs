using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Backend.Models
{
    public class Vehicle
    {   
        [Key]
        public string VIN { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }

        public string ModelName { get; set; }

        public ICollection<VehicleAttribute> Attributes { get; set; }





    }
}
