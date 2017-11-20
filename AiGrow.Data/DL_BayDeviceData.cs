using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayDeviceData
    {
        public bool insert(Model.ML_BayDeviceData data)
        {
            var para = new MySqlParameter[2];
            para[1] = new MySqlParameter("@data", data.data);
            para[0] = new MySqlParameter("@unique_id", data.device_unique_id);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO bay_device_data (device_unique_id, received_time, data, data_unit) VALUES (@unique_id, NOW(), @data, '')", para) != -1;
        }
    }
}
