using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MapMvp1.Models
{
    public class LiveLocation
    {
        public int Id { get; set; }

        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }


        public DateTime LocationOn { get; set; }
        [Column(TypeName = "decimal(18,15)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18,15)")]
        public decimal Longitude { get; set; }


        public bool IsActive { get; set; }

        public string Note { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

    }
}
