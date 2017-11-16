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
            BayDeviceRequest br = new BayDeviceRequest();
            br.command = "registerBayDevice";
            br.bay_device_unique_id = "device_1";
            br.bay_device_name = "sensor";
            br.bay_id = 1;
            br.default_unit = "kg";
            br.device_type = "pump";
            br.io_type = "in";
            br.status = "up";
            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(br));
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
