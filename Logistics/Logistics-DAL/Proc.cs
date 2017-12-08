using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_DAL
{
    public class Proc
    {
        public class Demo
        {
            public const string Demo_Insert = "logistics_Demo_Insert";

            public const string Demo_Select_By_Name = "logistics_Demo_Select_By_Name";

            public const string Demo_Select_By_ID = "logistics_Demo_Select_By_ID";

            public const string Demo_Delete_By_ID = "logistics_Demo_Delete_By_ID";

            public const string Demo_Modify_By_ID = "logistics_Demo_Modify_By_ID";

        }


        public class Rule
        {
            public const string Logistics_Businessnorule_Update_CurrentNo = "Logistics_Businessnorule_Update_CurrentNo";
        }

        public class User
        {
            public const string Logistics_UserInfo_Insert = "Logistics_UserInfo_Insert";
            public const string Logistics_UserInfo_Select = "Logistics_UserInfo_Select";
        }

        public class Base
        {
            public const string logistics_base_sms_validate_insert = "logistics_base_sms_validate_insert";
            public const string logistics_base_sms_validate_select = "logistics_base_sms_validate_select";
            public const string logistics_base_sms_validate_check = "logistics_base_sms_validate_check";
        }
    }
}
