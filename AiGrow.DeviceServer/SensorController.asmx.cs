using System;
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
            BaseDeviceRequest request = new BaseDeviceRequest();
            request.data = "123";
            request.deviceID = "G_001:B_001:BD_001";
            request.command = "dataEntry";
            //List<BayRequest> baylist = new List<BayRequest>();
            //List<BayDeviceRequest> devicelist = new List<BayDeviceRequest>();

            //GreenhouseRequest gr = new GreenhouseRequest();
            //BayRequest br = new BayRequest();
            //BayDeviceRequest bdr = new BayDeviceRequest();

            //bdr.bay_device_unique_id = "device_2";
            //bdr.bay_device_name = "sensor_2";
            //bdr.device_type = "humiditySensor";
            //bdr.io_type = "in";
            //bdr.bay_id = 2;
            //bdr.status = "up";

            //br.greenhouse_id = 1;
            //br.bay_unique_id = "bay-2";
            //br.listOfBayDevices = devicelist;

            //baylist.Add(br);
            //devicelist.Add(bdr);

            //gr.command = "registerGreenhouse";
            //gr.listOfBays = baylist;

            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(request));
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
