using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AiGrow.Data
{
    public class DL_GreenHouses
    {
        public DataTable select()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM greenhouse g");
        }
    }
}
