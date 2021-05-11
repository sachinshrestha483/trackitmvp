using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MapMvp1.Models
{
    public class LocationHistory
    {

        public int Id { get; set; }

        public Vehicle Vehicle { get; set; }

        public int VehicleId { get; set; }


        [Column(TypeName = "decimal(18,15)")]

        public decimal Latitude  { get; set; }
        [Column(TypeName = "decimal(18,15)")]

        public decimal Longitude { get; set; }



        public DateTimeOffset LocationOn { get; set; }




        public int Speed { get; set; }



    }
}
