﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Model
{
    public class ML_LevelDevice
    {
        public string level_device_unique_id { get; set; }
        public string level_device_name { get; set; }
        public string device_type { get; set; }
        public string io_type { get; set; }
        public string default_unit { get; set; }
        public string status { get; set; }
        public int device_id { get; set; }
        public int level_id { get; set; }

    }
}
