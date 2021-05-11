using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapMvp1.Data;
using MapMvp1.Hubs;
using MapMvp1.Models;
using MapMvp1.Models.Dtos;
using MapMvp1.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MapMvp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveLocationController : ControllerBase
    {


        private readonly Applicationdbcontext _db;

        private readonly IHubContext<LiveLocationHub> _hubContext;

        public LiveLocationController(Applicationdbcontext db , IHubContext<LiveLocationHub> hubContext)
        {
            _db = db;
            _hubContext = hubContext;
        }




        [HttpPost("AddLocationHistory")]

        public async Task<IActionResult> AddLocationHistory(List<LiveLocationDto> liveLocationDtos)
        {

            var locationHistories = new List<LocationHistory>();



            foreach (var liveLocationDto in liveLocationDtos)
            {
               var locationHistory = new LocationHistory();


                locationHistory.Latitude = liveLocationDto.Latitude;
                locationHistory.Longitude = liveLocationDto.Longitude;
                locationHistory.VehicleId = liveLocationDto.VehicleId;
                locationHistory.LocationOn = DateTimeConvertor.UnixTimeStampToDateTime(liveLocationDto.TimeStamp);
                locationHistory.Speed = liveLocationDto.Speed;


                locationHistories.Add(locationHistory);





            }


            _db.LocationHistories.AddRange(locationHistories);

            _db.SaveChanges();
            
            return Ok();
        }






        [HttpPost("AddLiveLocation")]
        public async Task<IActionResult> AddLiveLocation(LiveLocationDto liveLocationDto)
        {



            var vehicle = _db.Vehicles.FirstOrDefault(l => l.Id == liveLocationDto.VehicleId);

            if (vehicle == null)
            {
                return BadRequest();
            }


            var existingLiveLocation = _db.LiveLocations.FirstOrDefault(l => l.VehicleId == vehicle.Id);


            if (existingLiveLocation != null)
            {
                // already there

                existingLiveLocation.Latitude = liveLocationDto.Latitude;
                existingLiveLocation.Longitude = liveLocationDto.Longitude;
                existingLiveLocation.LastUpdated = DateTimeOffset.Now;
                existingLiveLocation.VehicleId = vehicle.Id;
                existingLiveLocation.IsActive = true;
                existingLiveLocation.LocationOn = DateTimeConvertor.UnixTimeStampToDateTime(liveLocationDto.TimeStamp);
                _db.SaveChanges();

                await this._hubContext.Clients.Group(existingLiveLocation.VehicleId.ToString()).SendAsync("ReceiveLocation", liveLocationDto.Latitude, liveLocationDto.Longitude, existingLiveLocation.LocationOn,existingLiveLocation.VehicleId);


            }

            else
            {
                // create new 


                var liveLocation = new LiveLocation();


                liveLocation.Latitude = liveLocation.Latitude;
                liveLocation.Longitude = liveLocation.Longitude;
                liveLocation.LastUpdated = DateTimeOffset.Now;
                liveLocation.VehicleId = vehicle.Id;
                liveLocation.IsActive = true;
                liveLocation.LocationOn = DateTimeConvertor.UnixTimeStampToDateTime(liveLocationDto.TimeStamp);


                _db.LiveLocations.Add(liveLocation);
                _db.SaveChanges();

                await this._hubContext.Clients.Group(liveLocation.VehicleId.ToString()).SendAsync("ReceiveLocation", liveLocationDto.Latitude, liveLocationDto.Longitude, liveLocation.LocationOn,liveLocation.VehicleId);

            }



            //var locationHistory = new LocationHistory();
            //locationHistory.Latitude = liveLocationDto.Latitude;
            //locationHistory.Longitude = liveLocationDto.Longitude;
            //locationHistory.VehicleId = liveLocationDto.VehicleId;
            //locationHistory.DateTime = DateTimeConvertor.UnixTimeStampToDateTime(liveLocationDto.TimeStamp);



            //_db.LocationHistories.Add(locationHistory);
           
            
            
            ////_db.SaveChanges();


            return Ok();














            //liveLocation.Latitude = "";








        }












    }
}
