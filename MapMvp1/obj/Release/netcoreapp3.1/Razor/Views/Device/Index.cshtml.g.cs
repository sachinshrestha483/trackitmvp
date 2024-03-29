#pragma checksum "C:\Users\sachi\source\repos\MapMvp1\MapMvp1\Views\Device\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f12cc676182da81a8d9f6f3f49b1f20a51f6a49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Device_Index), @"mvc.1.0.view", @"/Views/Device/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\sachi\source\repos\MapMvp1\MapMvp1\Views\_ViewImports.cshtml"
using MapMvp1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sachi\source\repos\MapMvp1\MapMvp1\Views\_ViewImports.cshtml"
using MapMvp1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f12cc676182da81a8d9f6f3f49b1f20a51f6a49", @"/Views/Device/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89ffb5761c97e05b51353c617d049bbecb0362b8", @"/Views/_ViewImports.cshtml")]
    public class Views_Device_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\sachi\source\repos\MapMvp1\MapMvp1\Views\Device\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div id=""app"">

    <h1>Device</h1>

    <div class=""d-flex justify-content-center my-2"">


        <div class=""p-2 bd-highlight""></div>
        <div class=""p-2 bd-highlight"">


            <div class=""mb-3"">
                <label for=""exampleInputEmail1"" class=""form-label"">Vehicle Id</label>
                <input type=""number"" v-model=""submittedId"" class=""form-control"" id=""exampleInputEmail1"" aria-describedby=""emailHelp"">
            </div>

            <button class=""btn btn-primary"" v-on:click=""shareLocation"">Share Location</button>



        </div>
        <div class=""p-2 bd-highlight""></div>



    </div>


</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>

        const { createApp, ref, watch } = Vue;









        const App = {
            setup() {

                let g = JSON.parse(localStorage.getItem(""locationHistory""))

                var firstTime = true;

                try {
                    console.log(g.length)
                    firstTime = false;
                }
                catch (e) {
                    console.log(""----------Page Loading For First Time--------"")
                }





                var lastcordinate = {lat:0,lon:0,isSet:false}




                function getSpeedFromLatLonInKm(lat1, lon1, lat2, lon2) {
                    var R = 6371; // Radius of the earth in km
                    var dLat = deg2rad(lat2 - lat1);  // deg2rad below
                    var dLon = deg2rad(lon2 - lon1);
                    var a =
                        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2))");
                WriteLiteral(@" *
                        Math.sin(dLon / 2) * Math.sin(dLon / 2)
                        ;
                    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
                    var d = R * c; // Distance in km

                  //  0.0833333 // 5 secondin minute..... 


                    var speed = d / 0.0833333;// in km/h

                    return speed;
                }





                function deg2rad(deg) {
                    return deg * (Math.PI / 180)
                }







                const getSpeed = (lat, lon) => {


                    console.log(""Calculating The Speed"");

                    let speed = getSpeedFromLatLonInKm(
                        lat,
                        lon,
                        lastcordinate.lat,
                        lastcordinate.lon


                    );


                    return speed;




                }





                const SendLocationsToServer = (latitude, lon");
                WriteLiteral(@"gitude) => {
                    let locations = JSON.parse(localStorage.getItem(""locationHistory""))
                    axios
                        .post(""/api/LiveLocation/AddLocationHistory"", locations)
                        .then(function (response) {
                            console.log(""hi"");
                            console.log(response);



                        })
                        .catch(function (error) {
                            console.log(error);
                            var lastLocationHistory = JSON.parse(localStorage.getItem(""locationHistory""))

                            localStorage['locationHistory'] = JSON.stringify([...lastLocationHistory, ...locations]);

                        });

                    localStorage['locationHistory'] = JSON.stringify([]);

                };


                console.log(""----------Sharing Location----------ss"")

                const vehicleId = ref(null);
                const submittedId = ref(null");
                WriteLiteral(@");



                var connection = ref(new signalR.HubConnectionBuilder().withUrl(""/LiveLocation"").build());

                console.log(""--------Connection----------"")
                console.log(connection);
                console.log(""--------Connection----------"")


                //Disable send button until connection is established

                connection
                    .value
                    .start()
                    .then(function () {


                        console.log(""connection is Here"")

                        console.log(connection.value);// Watch these
                        console.log(""connection is Here"")



                        console.log(""----Connection Id Here------ "");
                        console.log(connection.value.connectionId);
                        //console.log(connection.hub.id);
                        console.log(""----Connection Id Here------ "");

                        console.log(""connected"");
             ");
                WriteLiteral(@"       })
                    .catch(function (err) {




                        return console.error(err.toString());
                    });








                const reConnectSignalr = () => {






                    connection.value = new signalR.HubConnectionBuilder().withUrl(""/LiveLocation"").build();



                    console.log(""--------------Getting Reconnect ----------"")
                    console.log(""--------------Getting Reconnect ----------"")
                    console.log(""--------------Getting Reconnect ----------"")
                    console.log(""--------------Getting Reconnect ----------"")

                    connection
                        .value
                        .start()
                        .then(function () {


                            console.log(""connection is Here"")

                            console.log(connection.value);// Watch these
                            console.log(""connection is Here"")



      ");
                WriteLiteral(@"                      console.log(""----Connection Id Here------ "");
                            console.log(connection.value.connectionId);
                            //console.log(connection.hub.id);
                            console.log(""----Connection Id Here------ "");

                            console.log(""connected"");
                        })
                        .catch(function (err) {




                            return console.error(err.toString());
                        });






                    console.log(""--------------Getting Recoect ----------"")
                    console.log(""--------------Getting Reconnect ----------"")
                    console.log(""--------------Getting Reconnect ----------"")
                    console.log(""--------------Getting Reconnect ----------"")




                }







                //watch(connection.value, () => {
                //    console.log(""---------Connection State Changed---------------"")
");
                WriteLiteral("\n\r\n                //    if (connection.value.connectionState == \"Connected\") {\r\n                //        console.log(\"");
                WriteLiteral("@");
                WriteLiteral("@");
                WriteLiteral("@");
                WriteLiteral("@-----------It is Connected------------");
                WriteLiteral("@");
                WriteLiteral("@");
                WriteLiteral("@\")\r\n                //    }\r\n\r\n\r\n                //    else {\r\n                //        console.log(\"");
                WriteLiteral("@");
                WriteLiteral("@");
                WriteLiteral("@ connection Broken   ");
                WriteLiteral("@");
                WriteLiteral("@");
                WriteLiteral(@"@ "");

                //        reConnectSignalr();

                //    }


                //    console.log(""---------Connection State Changed---------------"")

                //    console.log(""---------Connection State Changed---------------"")


                //})










                const shareLocation = () => {

                    console.log(""----------Sharing Location----------"")
                    console.log(""----------Sharing Location----------"")
                    console.log(""----------Sharing Location----------"")

                    if (submittedId.value != null) {

                        vehicleId.value = submittedId.value;
                        setInterval(function () {
                            navigator.geolocation.getCurrentPosition(showPosition);

                        }, 5000);



                        setInterval(function () {
                            console.log(""--------------Save Data To Internet--------------"")
   ");
                WriteLiteral(@"                         SendLocationsToServer()
                            console.log(""--------------Save Data To Internet--------------"")

                        }, 15000);







                      

                    }

                }








                function showPosition(position) {
                    let lat = position.coords.latitude;
                    let lon = position.coords.longitude;

                    console.log(lat);
                    console.log(lon);

                    SetLiveLocation(lat, lon);
                    console.log(""------Calling The Api------"");
                }







                const SetLiveLocation = async (latitude, longitude) => {



                    let speed = getSpeed(latitude, longitude);

                    console.log(""type of Speed"")
                    console.log(typeof speed);
                    console.log(""type of Speed"")

                    if (typeof speed != ""number"") {");
                WriteLiteral(@"
                        speed = 0;
                    }



                    var liveLocationObject = {
                        VehicleId: Number(submittedId.value),
                        Latitude: latitude,
                        Longitude: longitude,
                        TimeStamp: Math.floor(Date.now() / 1000),
                        speed:0
                    };



                    console.log(liveLocationObject);




                    if (firstTime == true) {

                        localStorage['locationHistory'] = JSON.stringify([liveLocationObject]);
                        firstTime = false;
                    }



                    else {
                        var lastLocationHistory = JSON.parse(localStorage.getItem(""locationHistory""))

                        localStorage['locationHistory'] = JSON.stringify([...lastLocationHistory, liveLocationObject]);

                    }



                    console.log(typeof JSON.parse(localStora");
                WriteLiteral(@"ge.getItem(""locationHistory"")));


                    console.log(""location From Db"");
                    console.log(JSON.parse(localStorage.getItem(""locationHistory"")));





                    if (lastcordinate.isSet == false) {

                        connection.value.invoke(""SendLiveLocationV2"", liveLocationObject.Latitude, liveLocationObject.Longitude, liveLocationObject.VehicleId, liveLocationObject.TimeStamp, speed).catch(function (err) {

                            reConnectSignalr();
                            return console.error(err.toString());
                        });

                    }

                    else {


                        connection.value.invoke(""SendLiveLocationV2"", liveLocationObject.Latitude, liveLocationObject.Longitude, liveLocationObject.VehicleId, liveLocationObject.TimeStamp, speed).catch(function (err) {

                            reConnectSignalr();
                            return console.error(err.toString());
            ");
                WriteLiteral(@"            });



                    }                    





                    lastcordinate.lat = liveLocationObject.Latitude;
                    lastcordinate.lon = liveLocationObject.Longitude;
                    lastcordinate.isSet = true;

                };

                return { shareLocation, submittedId };
            },

        };

        createApp(App).mount(""#app"");

    </script>


");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
