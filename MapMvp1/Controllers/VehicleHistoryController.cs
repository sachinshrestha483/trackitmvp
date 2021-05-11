using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapMvp1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapMvp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleHistoryController : ControllerBase
    {



        private readonly Applicationdbcontext _db;

        public VehicleHistoryController(Applicationdbcontext db)
        {
            _db = db;
        }


        [HttpGet("GetLocationHistory")]

        public async Task<IActionResult> GetLocationHistory(int id)
        {


            var vehicle = _db.Vehicles.FirstOrDefault(v => v.Id == id);


            if (vehicle == null)
            {
                return BadRequest();
            }



            var locationHistories =  _db.LocationHistories.Where(l => l.VehicleId == id).OrderBy(d=>d.LocationOn).ToList();





            return Ok(locationHistories);



        }


        [HttpGet("GetLocationHistoryInRange")]
        public IActionResult GetLocationHistoryInRange(DateTime startDateTime, DateTime endDateTime )
        {

            return Ok();

        }




    }
}
