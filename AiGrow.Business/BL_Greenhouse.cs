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
    }
}
