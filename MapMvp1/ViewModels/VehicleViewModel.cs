using MapMvp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapMvp1.ViewModels
{
    public class VehicleViewModel
    {
        public Vehicle  Vehicle { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
