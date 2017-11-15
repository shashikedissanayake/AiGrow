using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_Greenhouse
    {
        public bool insert(Model.ML_Greenhouse greenhouse)
        {
            var para = new MySqlParameter[4];
            para[0] = new MySqlParameter("@greenhouse_name", greenhouse.greenhouse_name);
            para[1] = new MySqlParameter("@user_id", greenhouse.owner_user_id);
            para[2] = new MySqlParameter("@location_id", greenhouse.location_id);
            para[3] = new MySqlParameter("@unique_id", greenhouse.greenhouse_unique_id);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO greenhouse ( greenhouse_name ,owner_user_id ,location_id , greenhouse_unique_id, created_date_time, last_updated_date ) VALUES ( @greenhouse_name ,@user_id ,@location_id ,@unique_id, NOW(), NOW() )", para) != -1;
           
        }
    }
}
