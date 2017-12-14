using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_Model
{

    public class BusinessConstants
    {
        public class Defkey
        {
            public const string user = "user";
            public const string order = "order";
        }

        public class Admin
        {
            public const long TenantID = 890501594632818690;
        }
        public class Channel
        {
            public const long EMSEconomicID = 890501594632328690;
            public const long FedxEconomicID = 890501594622318690;
            public const long UPSEconomicID = 890501594622338690;
            public const long DHLEconomicID = 890501594622348690;

        }
        public class Module
        {
            public const string CommonSMSHelpersend = "CommonSMSHelpersend";
        }
    }
}
