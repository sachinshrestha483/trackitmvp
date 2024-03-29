#pragma checksum "C:\Users\sachi\source\repos\MapMvp1\MapMvp1\Views\Tracker\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d608978d860a7375cbd9a04439b0987fcb990f07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tracker_Index), @"mvc.1.0.view", @"/Views/Tracker/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d608978d860a7375cbd9a04439b0987fcb990f07", @"/Views/Tracker/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89ffb5761c97e05b51353c617d049bbecb0362b8", @"/Views/_ViewImports.cshtml")]
    public class Views_Tracker_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\sachi\source\repos\MapMvp1\MapMvp1\Views\Tracker\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1> Tracker</h1>

<div id=""app"">
    <div class=""d-flex justify-content-center my-2"">


        <div class=""p-2 bd-highlight""></div>
        <div class=""p-2 bd-highlight"">


            <div class=""mb-3"">
                <label for=""exampleInputEmail1"" class=""form-label"">Vehicle Id</label>
                <input type=""email"" class=""form-control"" v-model=""vehicleId"" id=""exampleInputEmail1"" aria-describedby=""emailHelp"">
                <button class=""btn btn-primary text-center  my-4""     v-on:click=""addVehicle"">Add </button>
            </div>

            <div class=""row"" v-for=""(item,index) in  trackingVehicles"" :key=""item"">

                <div class=""col-sm-8""> {{item}}</div>
                <div class=""col-sm-4"" v-on:click=""removeVehicle(index)"">X</div>
            </div>

        </div>

        <div class=""p-2 bd-highlight""></div>

");
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n    </div>\r\n\r\n\r\n\r\n\r\n    <div class=\"container  mx-4 text-center\">\r\n        <div id=\"mapid\" ref=\"map\"></div>\r\n\r\n    </div>\r\n\r\n\r\n\r\n\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>



      //  import { onMounted } from ""../../wwwroot/js/LocalVue"";
        const { createApp, ref, onMounted } = Vue;

        const App = {
            setup() {


                const map = ref(null);

                const vehicleId = ref(null);
                const latitude = ref(null);
                const longitude = ref(null);
                const locationOn = ref(null);
                const trackingVehicles = ref([]);

















                var mymap;

                onMounted(() => {
                    console.log(map);
                    console.log(""Making The map"");
                    mymap = L.map(map.value).setView([23.3315, 75.0367], 5);
                    const tileUrl = ""https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"";

                    const attribution =
                        '&copy; <a href=""https://www.openstreetmap.org/copyright"">OpenStreetMap</a> contributors';

                    const tileLayer");
                WriteLiteral(@" = L.tileLayer(tileUrl, { attribution });
                    tileLayer.addTo(mymap);
                });















                const removeVehicle = (index) => {
                    leaveIndividualGroup(trackingVehicles.value[index]);

                    let vehicle = trackingVehicles.value[index];
                    mymap.removeLayer(vehicle.marker);



                    trackingVehicles.value.splice(index, 1);
                 //   joinVehicleGroups();

                }

                const addVehicle = async() => {
                    if (vehicleId.value != null && !trackingVehicles.value.includes(vehicleId.value)) {
                        //trackingVehicles.values;
                        //  console.log(trackingVehicles.value);


                        let trackingVehicleObj = {
                            vehicleId: vehicleId.value,
                             marker : null

                        }


                        trackingVehicl");
                WriteLiteral(@"es.value.push(trackingVehicleObj);
                        vehicleId.value = null
                    }

                  await  leaveVehicleGroups();
                 await   joinVehicleGroups();

                }




                const leaveIndividualGroup = (item) => {

                    connection.invoke(""LeaveRoom"", item.vehicleId).catch(function (err) {



                        return console.error(err.toString());
                        });

                   
                }



                const leaveVehicleGroups = () => {
                    trackingVehicles.value.forEach(item => {
                        connection.invoke(""LeaveRoom"", item.vehicleId).catch(function (err) {

                            return console.error(err.toString());
                        });

                    });
                }



                const joinVehicleGroups =  () => {


                    trackingVehicles.value.forEach(item => {
                 ");
                WriteLiteral(@"       connection.invoke(""JoinRoom"", item.vehicleId).catch(function (err) {

                            return console.error(err.toString());
                        });

                    });


                }







                //console.log(""it is Here "")

                var connection = new signalR.HubConnectionBuilder().withUrl(""/LiveLocation"").build();

                console.log(""--------Connection----------"")
                console.log(connection);
                console.log(""--------Connection----------"")


                //Disable send button until connection is established

                connection
                    .start()
                    .then(function () {
                        console.log(""----Connection Id Here------ "");
                        console.log(""Connection Id"");
                        console.log(connection.connectionId);
                        //console.log(connection.hub.id);
                        console.log(""----Con");
                WriteLiteral(@"nection Id Here------ "");

                        console.log(""connected"");
                    })
                    .catch(function (err) {
                        return console.error(err.toString());
                    });
                                                                                //datetime

                connection.on(""ReceiveLocationV2"", function (latitude,longitude ,vehicleId,timeStamp,speed) {

                    console.log("" Data Received "");

                    console.log(""latitude:"" + latitude + """");
                    console.log(""longitude:"" + longitude + """");

                    console.log(""vehicle Id:"" + vehicleId + """");

                    console.log(""Time Stamp:"" + timeStamp + """");


                    console.log(""speed:"" + speed+"" "");


                    console.log(""------------------------------"");

                //    getNewValues(latitude, longitude);
                    console.log(""------------------------------"");
");
                WriteLiteral(@"
                    drawMarkerOnMap(latitude, longitude, timeStamp, vehicleId,speed)

                });




                connection.on(""JoinedGroup"", function (message) {
                    console.log(""message"" + message);
                });


                connection.on(""LeaveGroup"", function (message) {
                    console.log(""message"" + message);
                });

                
                

                const getNewValues = (lat, lon, dt) => {
                    console.log(""From Function"");
                    console.log(lat + "" "" + lon + "" "" + dt);
                    latitude.value = lat;
                    longitude.value = lon;
                    locationOn.value = dt;


                };



                const drawMarkerOnMap = (latitude, longitude, dateTime, vehicleId,speed) => {






                    const vehicle = trackingVehicles.value.find(element => element.vehicleId == vehicleId);



                    console.l");
                WriteLiteral(@"og(""-----drawing Marker------"");

                    console.log(vehicle);

                    console.log(""-----drawing Marker------"");


                    if (typeof vehicle != undefined) {


                        if (vehicle.marker != null) {
                            mymap.removeLayer(vehicle.marker);

                        }

                        const newMarker = new L.marker([latitude, longitude]);
                        newMarker.bindPopup('Marker' + vehicleId + "" "" + ""lastUpdated:"" + dateTime+ ""speed:""+speed).openPopup();

                        newMarker.addTo(mymap)
                        newMarker.bindPopup('Marker' + vehicleId + "" "" + ""lastUpdated:"" + dateTime + ""speed:"" + speed).openPopup();

                        try {
                            vehicle.marker = newMarker ;

                        }
                        catch (e) {
                            console.log(e);
                        }
                    }







         ");
                WriteLiteral("       }\r\n\r\n\r\n\r\n                return { vehicleId, latitude, longitude, locationOn, trackingVehicles, addVehicle, removeVehicle, map};\r\n            },\r\n\r\n        };\r\n\r\n        createApp(App).mount(\"#app\");\r\n\r\n    </script>\r\n\r\n\r\n");
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
