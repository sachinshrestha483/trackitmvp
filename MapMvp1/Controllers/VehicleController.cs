using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapMvp1.Data;
using MapMvp1.Models;
using MapMvp1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MapMvp1.Controllers
{
    public class VehicleController : Controller
    {

        private readonly Applicationdbcontext _db;




        public VehicleController(Applicationdbcontext db)
        {
            _db = db;
        }

        public IActionResult Index()

        {
            var vehicleViewModel = new VehicleViewModel();
            vehicleViewModel.Vehicles = _db.Vehicles.ToList();
            return View(vehicleViewModel);
        }

        [HttpPost]
        public IActionResult Add(Vehicle vehicle)
        {

            //_db.Vehicles.Add(vehicleVm.Vehicle);

            //_db.SaveChanges();


            _db.Vehicles.Add(vehicle);
            _db.SaveChanges();




            return RedirectToAction(nameof(Index));

        }


    }
}
