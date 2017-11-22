using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class RegisterComponent
    {
        public bool registerBay(BayRequest bay)
        {
            try
            {
                new DatabaseUpdate().registerBay(bay);

                foreach (BayDeviceRequest device in bay.listOfBayDevices)
                {
                    new DatabaseUpdate().registerBayDevice(device);
                }

                foreach (BayLineRequest line in bay.listOfBayLines)
                {
                    registerBayLine(line);
                }

                foreach (BayRackRequest rack in bay.listOfBayRacks)
                {
                    registerBayRack(rack);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        public bool registerBayLine(BayLineRequest line)
        {
            try
            {
                new DatabaseUpdate().registerBayLine(line);

                foreach (BayLineDeviceRequest device in line.listOfBayLineDevices)
                {
                    new DatabaseUpdate().registerBayLineDevice(device);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
        public bool registerBayRack(BayRackRequest rack)
        {
            try
            {
                new DatabaseUpdate().registerBayRack(rack);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}