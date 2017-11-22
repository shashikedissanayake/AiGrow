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
        public void registerBayRack(BayRackRequest bayRack)
        {

            if (!(new AiGrow.Business.BL_BayRack().doesBayRackExist(bayRack.bay_rack_unique_id)))
            {
                new BL_BayRack().insert(new ML_BayRack()
                {
                   bay_id = bayRack.bay_id,
                   rack_unique_id = bayRack.bay_rack_unique_id
                });
            }
        }
        public void bayDeviceDataEntry(BaseDeviceRequest data) {
            string device = (data.deviceID).getUniqueID();
            DateTime t = DateTime.Now;
            string time = t.ToString(UniversalProperties.MySQLDateFormat);
            new BL_BayDeviceData().insert(new ML_BayDeviceData()
            {
                received_time = time,
                device_unique_id = device,
                data = data.data,
                data_unit = data.data_unit
            });
        }

        public void greenhouseDeviceDataEntry(BaseDeviceRequest data)
        {
            string device = (data.deviceID).getUniqueID();
            DateTime t = DateTime.Now;
            string time = t.ToString(UniversalProperties.MySQLDateFormat);
            new BL_GreenhouseDeviceData().insert(new ML_GreenhouseDeviceData()
            {
                received_time = time,
                device_unique_id = device,
                data = data.data,
                data_unit = data.data_unit
            });
        }
        public void bayLineDeviceDataEntry(BaseDeviceRequest data)
        {
            string device = (data.deviceID).getUniqueID();
            DateTime t = DateTime.Now;
            string time = t.ToString(UniversalProperties.MySQLDateFormat);
            new BL_BayLineDeviceData().insert(new ML_BayLineDeviceData()
            {
                received_time = time,
                device_unique_id = device,
                data = data.data,
                data_unit = data.data_unit
            });
        }
        public void registerBayLineDevice(BayLineDeviceRequest bayLineDevice)
        {

            if (!(new AiGrow.Business.BL_BayLineDevice().doesDeviceExist(bayLineDevice.bay_line_device_unique_id)))
            {
                new BL_BayLineDevice().insert(new ML_BayLineDevice()
                {
                    bay_line_device_unique_id = bayLineDevice.bay_line_device_unique_id,
                    bay_line_device_name = bayLineDevice.bay_line_device_name,
                    default_unit = bayLineDevice.default_unit,
                    device_type = bayLineDevice.device_type,
                    io_type = bayLineDevice.io_type,
                    line_id = bayLineDevice.bay_line_id,
                    status = bayLineDevice.status
                });
            }
        }
    }
}