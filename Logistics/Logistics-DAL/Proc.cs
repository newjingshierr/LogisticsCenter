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
        public class ExpressType
        {
            public const string logistics_base_express_type_insert = "logistics_base_express_type_insert";
            public const string logistics_base_express_type_select_all = "logistics_base_express_type_select_all";
        }
        public class Channel
        {
            public const string logistics_base_channel_insert = "logistics_base_channel_insert";
            public const string logistics_base_channel_select_by_page = "logistics_base_channel_select_by_page";
            public const string logistics_base_channel_select_by_id = "logistics_base_channel_select_by_id";
            public const string logistics_base_channel_delete_by_id = "logistics_base_channel_delete_by_id";
            public const string logistics_base_channel_update_by_id = "logistics_base_channel_update_by_id";

        }


        public class Warehouse
        {
            public const string logistics_base_warehouse_address_insert = "logistics_base_warehouse_address_insert";
            public const string logistics_base_warehouse_select_by_page = "logistics_base_warehouse_select_by_page";
            public const string logistics_base_warehouse_select_by_id = "logistics_base_warehouse_select_by_id";
            public const string logistics_base_warehouse_delete_by_id = "logistics_base_warehouse_delete_by_id";
            public const string logistics_base_warehouse_update_by_id = "logistics_base_warehouse_update_by_id";

        }

        public class RecipientsAddress
        {
            public const string logistics_base_recipients_address_insert = "logistics_base_recipients_address_insert";
            public const string logistics_base_recipients_select_by_page = "logistics_base_recipients_select_by_page";
            public const string logistics_base_recipients_select_by_id = "logistics_base_recipients_select_by_id";
            public const string logistics_base_recipients_delete_by_id = "logistics_base_recipients_delete_by_id";
            public const string logistics_base_recipients_update_by_id = "logistics_base_recipients_update_by_id";

        }
        public class Attachment
        {
            public const string logistics_base_attachment_insert = "logistics_base_attachment_insert";
            public const string logistics_base_attachment_get_by_order_id = "logistics_base_attachment_get_by_customer_order_id";
        }


        public class CustomerOrderMerge
        {
            public const string logistics_customer_order_merge_select_by_id = "logistics_customer_order_merge_select_by_id";
            public const string logistics_customer_order_merge_insert = "logistics_customer_order_merge_insert";
            public const string logistics_customer_order_merge_update_by_id = "logistics_customer_order_merge_update_by_id";
            public const string logistics_customer_order_merge_delete_by_id = "logistics_customer_order_merge_delete_by_id";
            public const string logistics_customer_order_merge_select_by_page = "logistics_customer_order_merge_select_by_page";
        }
        public class CustomerOrderMergeDetail
        {
            public const string logistics_customer_order_merge_detail_insert = "logistics_customer_order_merge_detail_insert";
            public const string logistics_customer_order_merge_detail_update = "logistics_customer_order_merge_detail_update";
            public const string logistics_customer_order_merge_detail_delete_by_order_merge_id = "logistics_customer_order_merge_detail_delete_by_order_merge_id";
            public const string logistics_customer_order_merge_detail_select_by_order_merge_id = "logistics_customer_order_merge_detail_select_by_order_merge_id";

        }

        public class CustomerOrderMergeStatus
        {
            public const string logistics_customer_order_merge_status_insert= "logistics_customer_order_merge_status_insert";
            public const string logistics_customer_order_merge_status_select_by_id = "logistics_customer_order_merge_status_select_by_id";
            public const string logistics_customer_order_merge_status_update_by_id = "logistics_customer_order_merge_status_update_by_id";
        }

        public class CustomerOrderMergeRelation
        {
            public const string logistics_customer_order_merge_relation_insert = "logistics_customer_order_merge_relation_insert";
            public const string logistics_customer_order_merge_relation_select_by_id = "logistics_customer_order_merge_relation_select_by_id";
            public const string logistics_customer_order_merge_relation_update_by_id = "logistics_customer_order_merge_relation_update_by_id";
        }



        public class Agent
        {
            public const string logistics_base_agent_insert = "logistics_base_agent_insert";
            public const string logistics_base_agent_select_where = "logistics_base_agent_select_where";
            public const string logistics_base_agent_select_by_page = "logistics_base_agent_select_by_page";
            public const string logistics_base_agent_select_by_id = "logistics_base_agent_select_by_id";
            public const string logistics_base_agent_delete_by_id = "logistics_base_agent_select_all";
            public const string logistics_base_agent_update_by_id = "logistics_base_agent_update_by_id";
        }

        public class CustomerOrder
        {
            public const string logistics_customer_order_update_by_id = "logistics_customer_order_update_by_id";
            public const string logistics_customer_order_insert = "logistics_customer_order_insert";
            public const string logistics_customer_order_select_by_where = "logistics_customer_order_select_by_where";
        }

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

            public const string logistics_base_agent_update_by_id = "logistics_Demo_Modify_By_ID";

            public const string Demo_Modify_By_ID = " Demo_Modify_By_ID";

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
            public const string logistics_base_navigation_select_children_items = "logistics_base_navigation_select_children_items";
        }
        public class Base
        {
            public const string logistics_base_sms_validate_insert = "logistics_base_sms_validate_insert";
            public const string logistics_base_sms_validate_select = "logistics_base_sms_validate_select";
            public const string logistics_base_sms_validate_check = "logistics_base_sms_validate_check";
            public const string logistics_base_message_select_by_userid = "logistics_base_message_select_by_userid";
            public const string logistics_base_message_insert = "logistics_base_message_insert";
        }
    }
}
