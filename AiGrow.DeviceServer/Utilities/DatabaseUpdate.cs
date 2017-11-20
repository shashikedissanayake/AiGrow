using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AiGrow.Business;
using AiGrow.Model;
using AiGrow.DeviceServer;

namespace AiGrow.DeviceServer
{
    public class DatabaseUpdate
    {
        public void registerBayDevice(BayDeviceRequest bayDevice)
        {

            if (!(new AiGrow.Business.BL_BayDevice().doesDeviceExist(bayDevice.bay_device_unique_id)))
            {
                new BL_BayDevice().insert(new ML_BayDevice()
                {
                    bay_device_unique_id = bayDevice.bay_device_unique_id,
                    bay_device_name = bayDevice.bay_device_name,
                    device_type = bayDevice.device_type,
                    io_type = bayDevice.io_type,
                    bay_id = bayDevice.bay_id,
                    default_unit = bayDevice.default_unit,
                    status = bayDevice.status
                });
            }
        }

        public void registerBay(BayRequest bay)
        {

            if (!(new AiGrow.Business.BL_Bay().doesBayExist(bay.bay_unique_id)))
            {
                new BL_Bay().insert(new ML_Bay()
                {
                    bay_unique_id = bay.bay_unique_id,
                    greenhouse_id = bay.greenhouse_id
                });
            }
        }
        public void registerBayLine(BayLineRequest bayLine)
        {

            if (!(new AiGrow.Business.BL_BayLine().doesBayLineExist(bayLine.bay_line_unique_id)))
            {
                new BL_BayLine().insert(new ML_BayLine()
                {
                    bay_line_unique_id = bayLine.bay_line_unique_id,
                    bay_id = bayLine.bay_id
                });
            }
        }

        public void bayDeviceDataEntry(BaseDeviceRequest data) {
            string device = (data.deviceID).getUniqueID();
            new BL_BayDeviceData().insert(new ML_BayDeviceData()
            {
                device_unique_id = device,
                data = data.data
            });
        }
    }
}