﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace AiGrow.DeviceServer
{
    /// <summary>
    /// Summary description for SensorController
    /// </summary>
    [WebService(Namespace = "http://aigrow.lk/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SensorController : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public string AddDeviceToBayLine(string deviceID, string status)
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetDeviceJSONTest()
        {
            //BaseDeviceRequest request = new BaseDeviceRequest();
            //request.data = "12345";
            //request.deviceID = "G_001:B_001:BL_001:BLD_001";
            //request.command = "dataEntry";
            //request.received_time = "2017-12-33 21:32:43";

            List<BayRequest> baylist1 = new List<BayRequest>();
            List<BayDeviceRequest> devicelist1 = new List<BayDeviceRequest>();
            List<BayLineRequest> linelist1 = new List<BayLineRequest>();
            List<BayLineDeviceRequest> lineDevicelist1 = new List<BayLineDeviceRequest>();
            List<BayRackRequest> racklist1 = new List<BayRackRequest>();

            GreenhouseRequest gr1 = new GreenhouseRequest();
            BayRequest br1 = new BayRequest();
            BayRequest br2 = new BayRequest();
            BayDeviceRequest bdr1 = new BayDeviceRequest();
            BayDeviceRequest bdr2 = new BayDeviceRequest();
            BayLineDeviceRequest bldr1 = new BayLineDeviceRequest();
            BayLineDeviceRequest bldr2 = new BayLineDeviceRequest();
            BayLineRequest blr1 = new BayLineRequest();
            BayLineRequest blr2 = new BayLineRequest();
            BayRackRequest brr1 = new BayRackRequest();
            BayRackRequest brr2 = new BayRackRequest();

            brr1.command = "registerBayRack";
            brr1.bay_id = 4;
            brr1.bay_rack_unique_id = "BR_002";
            brr2.command = "registerBayRack";
            brr2.bay_id = 4;
            brr2.bay_rack_unique_id = "BR_003";

            bldr1.bay_line_device_name = "pump";
            bldr1.bay_line_id = 3;
            bldr1.bay_line_device_unique_id = "BLD_002";
            bldr1.device_type = "actuator";
            bldr1.io_type = "out";
            bldr1.status = "down";
            bldr1.command = "registerBayLineDevice";
            bldr1.default_unit = "litres";
            bldr2.bay_line_device_name = "pump";
            bldr2.bay_line_id = 3;
            bldr2.bay_line_device_unique_id = "BLD_003";
            bldr2.device_type = "actuator";
            bldr2.io_type = "out";
            bldr2.status = "down";
            bldr2.command = "registerBayLineDevice";
            bldr2.default_unit = "litres";

            bdr1.bay_device_unique_id = "BD_002";
            bdr1.bay_device_name = "sensor_2";
            bdr1.device_type = "humiditySensor";
            bdr1.io_type = "in";
            bdr1.bay_id = 4;
            bdr1.status = "up";
            bdr2.bay_device_unique_id = "BD_003";
            bdr2.bay_device_name = "sensor_2";
            bdr2.device_type = "humiditySensor";
            bdr2.io_type = "in";
            bdr2.bay_id = 4;
            bdr2.status = "up";

            br1.greenhouse_id = 1;
            br1.bay_unique_id = "B_002";
            br1.listOfBayDevices = devicelist1;
            br2.greenhouse_id = 1;
            br2.bay_unique_id = "B_003";
            br2.listOfBayDevices = devicelist1;


            blr1.bay_id = 4;
            blr1.bay_line_unique_id = "BL_002";
            blr1.command = "registerBayLine";

            blr2.bay_id = 4;
            blr2.bay_line_unique_id = "BL_003";
            blr2.command = "registerBayLine";

            gr1.command = "registerGreenhouse";

            devicelist1.Add(bdr1);
            devicelist1.Add(bdr2);

            linelist1.Add(blr2);
            linelist1.Add(blr1);

            lineDevicelist1.Add(bldr1);
            lineDevicelist1.Add(bldr2);

            racklist1.Add(brr2);
            racklist1.Add(brr1);

            br1.listOfBayRacks = racklist1;
            br2.listOfBayRacks = racklist1;

            blr1.listOfBayLineDevices = lineDevicelist1;
            blr2.listOfBayLineDevices = lineDevicelist1;

            br1.listOfBayDevices = devicelist1;
            br2.listOfBayDevices = devicelist1;
            br1.listOfBayLines = linelist1;
            br2.listOfBayLines = linelist1;

            baylist1.Add(br1);
            baylist1.Add(br2);

            gr1.listOfBays = baylist1;

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(gr1));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void AddDeviceTest()
        {
            GreenhouseRequest gr = new GreenhouseRequest();
            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new GreenhouseRequest() { }));
        }
    }
}
