using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public static class ApplicationUtilities
    {
        public static bool IsEmpty(this string str)
        {
            return str == null ? string.IsNullOrEmpty(str) : string.IsNullOrEmpty(str.Trim());
        }
    }
}