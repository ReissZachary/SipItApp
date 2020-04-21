using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SipIt.menu
{
    public class Constants
    {
        public Dictionary<string, decimal> size = new Dictionary<string, decimal>()
        {
            {"12oz", 1.25M },
            {"20oz", 1.50M },
            {"32oz", 1.75M },
            {"44oz", 2.00M }
        };
        
    }
}
