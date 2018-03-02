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
            public const string customerorder = "customerorder";
            public const string mergeorder = "customermergeorder";
        }

        public class Admin
        {
            public const long TenantID = 890501594632818690;

        }
        public class Channel
        {
            public const long EMSStandard = 890501594632328690;
            public const long EUB = 890501594632324490;
            public const long EMSPreferential = 890501594632395590;
            public const long DHLStandard = 890501594632398690;
            public const long FEDEXPrior = 890501594622738690;
            public const long FEDEXEconomic = 890501594622848690;
            public const long UPSPrior = 890501594622958690;
            public const long TNTEconomic = 890501594632028690;
            public const long TNTPrior = 890501594632128690;

        }
        public class Module
        {
            public const string CommonSMSHelpersend = "CommonSMSHelpersend";
        }

        public class Role
        {
            public const long member = 822501594632818690;
            public const long wareHouseAdmin = 822601594632818690;
            public const long customerService = 822701594632818690;
            public const long finance = 822801594632818690;
            public const long admin = 822901594632818690;

        }

        public class RegisterMailTemplate
        {
            public const string Title = "大陆注册会员邮箱验证";
            public const string body = "尊敬的客户，您好\r\n\n感谢您注册大陆国际会员，以下是您的注册验证码:\r\n验证码:{0}       请将验证码输入指定位置进行验证，为确保账户安全，请勿泄露您的验证码.";
        }

        public class CustomerOrderMergeStep
        {
            public const string CustomerServiceConfirm = "1";
            public const string WarehousePackege = "2";
            public const string WaitForPay = "3";
            public const string WaitForDelivery = "4";
        }

        public class CustomerOrderMergeBalanceType
        {
            public const int receivable = 0;
            public const int payable = 1;
        }

        public class CustomerOrderMergeStatus
        {
            public const string waitapprove = "0";
            public const string confirmed = "1";
            public const string refused = "2";

        }
    }
}
