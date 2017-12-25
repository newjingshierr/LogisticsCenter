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
            public const long TNTEconomicID = 890501594622358690;
            public const long FEDEXIP = 890501594622738690;
            public const long FEDEXIE = 890501594622848690;
            public const long UPSFSR = 890501594622958690;
            public const long TNT48N = 890501594632028690;
            public const long TNT15N = 890501594632128690;

        }
        public class Module
        {
            public const string CommonSMSHelpersend = "CommonSMSHelpersend";
        }

        public class Role
        {
            public const long member = 822501594632818690;
            public const long wareHouseAdmin= 822601594632818690;
            public const long customerService = 822701594632818690;
            public const long finance = 822801594632818690;
            public const long admin = 822901594632818690;

        }

        public class RegisterMailTemplate
        {
            public const string Title = "大陆注册会员邮箱验证";
            public const string body = "尊敬的客户，您好\r\n\n感谢您注册大陆国际会员，以下是您的注册验证码:\r\n验证码:{0}       请将验证码输入指定位置进行验证，为确保账户安全，请勿泄露您的验证码.";
        }
    }
}
