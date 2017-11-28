using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_Greenhouse
    {
        public bool insert(AiGrow.Model.ML_Greenhouse greenhouse)
        {
            return new DL_Greenhouse().insert(greenhouse);
        }
        public bool doesGreenhouseExist(string greenhouse)
        {
            return new DL_Greenhouse().doesGreenhouseExist(greenhouse);
        }


        public System.Data.DataTable selectAllGreenhouses()
        {
            return new DL_Greenhouse().select();
        }

        public System.Data.DataTable selectComponentsByNetworkID(string greenHouseID)
        {
            return new AiGrow.Data.DL_Greenhouse().selectComponentsByGreenHouseID(greenHouseID);
        }
    }
}
