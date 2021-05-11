using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapMvp1.Hubs
{
    public class LiveLocationHub:Hub
    {




        //public async Task SendLiveLocationV2(decimal latitude, decimal longitude, string locationOn, string VehicleId)

        public async Task SendLiveLocationV2(decimal latitude,decimal longitude  ,long VehicleId,long timeStamp,int speed)

        {

            await Clients.All.SendAsync("ReceiveLocationV2",latitude,longitude, VehicleId, timeStamp,speed);
        }





        public async Task SendLiveLocation(decimal latitude, decimal longitude, DateTime locationOn,string VehicleId)
        {
            await Clients.All.SendAsync("ReceiveLocation", latitude, longitude, locationOn, VehicleId);
        }



        public async Task JoinRoom(string classId)
        {
           await  Groups.AddToGroupAsync(Context.ConnectionId, classId);
            await Clients.Group(classId).SendAsync("JoinedGroup",classId+ " joined.");

        }

        public async Task LeaveRoom(string classId)
        {
           await  Groups.RemoveFromGroupAsync(Context.ConnectionId, classId);
            await Clients.All.SendAsync("LeaveGroup", classId + " Leave Group.");

        }





    }
}
