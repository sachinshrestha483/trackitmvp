using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapMvp1.Models.Dtos
{
    public class LiveLocationDto
    {
        public int VehicleId { get; set; }


        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int Speed { get; set; }


        public long TimeStamp { get; set; }
    }
}
