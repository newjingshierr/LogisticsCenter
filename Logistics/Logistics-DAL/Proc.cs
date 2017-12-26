using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics_DAL
{
    /// <summary>
    /// 存储过程的名字一律都是小写；
    /// </summary>
    public class Proc
    {
        public class Quotation
        {
            public const string logistics_base_country_insert = "logistics_base_country_insert";

            public const string logistics_quotation_country_by_name = "logistics_quotation_country_by_name";

            public const string logistics_quotation_partition_select_by_Code_channelID = "logistics_quotation_partition_select_by_Code_channelID";

            public const string logistics_quotation_partition_select_by_country = "logistics_quotation_partition_select_by_country";

            public const string logistics_quotation_partition_price_select_by_country = "logistics_quotation_partition_price_select_by_country";

            public const string logistics_Select_Price_By_PartitionID_Weight = "logistics_select_price_by_partitionID_weight";

            public const string logistics_Select_IPF_Price_By_PartitionID_Weight = "logistics_select_ipf_price_by_partitionid_weight";

            public const string logistics_quotation_channel_select_all = "logistics_quotation_channel_select_all";

            public const string logistics_quotation_partition_price_Insert = "logistics_quotation_partition_price_Insert";


            public const string logistics_quotation_partition_ipf_price_Insert = "logistics_quotation_partition_ipf_price_Insert";

            public const string logistics_quotation_partition_insert = "logistics_quotation_partition_insert";

            public const string logistics_quotation_partition_country_insert = "logistics_quotation_partition_country_insert";

        }

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
            public const string Logistics_Businessnorule_Update_CurrentNo = "logistics_businessnorule_update_currentNo";
        }

        public class User
        {
            public const string Logistics_UserInfo_Insert = "logistics_base_userinfo_insert";
            public const string Logistics_UserInfo_Select = "logistics_base_userinfo_select";
            public const string logistics_userInfo_validate = "logistics_base_userInfo_validate";
            public const string logistics_userinfo_update_pwd = "logistics_base_userinfo_update_pwd";
            public const string logistics_base_userinfo_log_insert = "logistics_base_userinfo_log_insert";
        }


        public class Role
        {
            public const string logistics_base_role_select_by_userid = "logistics_base_role_select_by_userid";
            public const string logistics_base_role_user_binding_Insert = "logistics_base_role_user_binding_Insert";

        }
        public class Navigation
        {
            public const string logistics_base_navigation_select_by_roleid = "logistics_base_navigation_select_by_roleid";
        }
        public class Base
        {
            public const string logistics_base_sms_validate_insert = "logistics_base_sms_validate_insert";
            public const string logistics_base_sms_validate_select = "logistics_base_sms_validate_select";
            public const string logistics_base_sms_validate_check = "logistics_base_sms_validate_check";
        }
    }
}
