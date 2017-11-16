using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AiGrow.Model;

namespace AiGrow.DeviceServer
{
    public class GreenhouseRequest : BaseRequest
    {
        public List<ML_Bay> listOfBays { get; set; }
        public List<ML_BayLine> listOfBayLines { get; set; }
        public List<ML_BayLineDevice> listOfBayLineDevices { get; set; }
        public List<ML_BayDevice> listOfBayDevices { get; set; }
        public List<ML_Rack> listOfBayRacks { get; set; }
        public List<ML_RackDevice> listOfBayRackDevices { get; set; }
        public List<ML_Level> listOfBayRackLevels { get; set; }
        public List<ML_LevelDevice> listOfBayRackLevelDevices { get; set; }
        public List<ML_LevelLine> listOfBayRackLevelLines { get; set; }
        public List<ML_LevelLineDevice> listofBayRAckLevelLineDevices { get; set; }
    }
}