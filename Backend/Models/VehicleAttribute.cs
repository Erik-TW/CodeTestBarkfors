using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class VehicleAttribute
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public string Value { get; set; }
        [Required]
        public Vehicle Vehicle { get; set; }
    }
}
