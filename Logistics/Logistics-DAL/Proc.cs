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
        public class File
        {
            public const string logistics_base_attachment_get_by_id = "logistics_base_attachment_get_by_id";
            public const string logistics_base_attachment_get_by_customer_order_id = "logistics_base_attachment_get_by_customer_order_id";
            public const string logistics_base_attachment_Insert = "logistics_base_attachment_Insert";
            public const string logistics_base_attachment_update_by_id = "logistics_base_attachment_update_by_id";
            public const string logistics_base_attachment_delete_by_id = "logistics_base_attachment_delete_by_id";
            public const string logistics_base_attachment_delete_by_customer_order_id = "logistics_base_attachment_delete_by_customer_order_id";
        }
        public class TokenLog
        {
            public const string logistics_base_token_log_delete_by_user_id = "logistics_base_token_log_delete_by_user_id";
            public const string logistics_base_token_log_insert = "logistics_base_token_log_insert";
            public const string logistics_base_token_log_select_by_user_id = "logistics_base_token_log_select_by_user_id";
        }
        public class ExpressType
        {
            public const string logistics_base_express_type_insert = "logistics_base_express_type_insert";
            public const string logistics_base_express_type_select_all = "logistics_base_express_type_select_all";
            public const string logistics_express_type_select_index = "logistics_express_type_select_index";
        }
        public class Channel
        {
            public const string logistics_base_channel_insert = "logistics_base_channel_insert";
            public const string logistics_base_channel_select_by_page = "logistics_base_channel_select_by_page";
            public const string logistics_quotation_channel_select_by_id = "logistics_quotation_channel_select_by_id";
            public const string logistics_base_channel_delete_by_id = "logistics_base_channel_delete_by_id";
            public const string logistics_base_channel_update_by_id = "logistics_base_channel_update_by_id";

        }


        public class Warehouse
        {
            public const string logistics_base_warehouse_select_all = "logistics_base_warehouse_select_all";
            public const string logistics_base_warehouse_Insert = "logistics_base_warehouse_Insert";
            public const string logistics_base_warehouse_select_by_page = "logistics_base_warehouse_select_by_page";
            public const string logistics_base_warehouse_select_by_id = "logistics_base_warehouse_select_by_id";
            public const string logistics_base_warehouse_detete_by_id = "logistics_base_warehouse_detete_by_id";
            public const string logistics_base_warehouse_update_by_id = "logistics_base_warehouse_update_by_id";
            public const string logistics_base_warehouse_update_volumne_by_id = "logistics_base_warehouse_update_volumne_by_id";
            public const string logistics_warehouse_select_index = "logistics_warehouse_select_index";
        }

        public class RecipientsAddress
        {
            public const string logistics_base_recipients_address_insert = "logistics_base_recipients_address_insert";
            public const string logistics_base_recipients_address_select_by_id = "logistics_base_recipients_address_select_by_id";
            public const string logistics_base_recipients_address_delete_by_id = "logistics_base_recipients_address_delete_by_id";
            public const string logistics_base_recipients_address_update = "logistics_base_recipients_address_update";
            public const string logistics_base_recipients_address_select_all = "logistics_base_recipients_address_select_all";

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
            public const string logistics_customer_order_merge_select_for_approve_by_page = "logistics_customer_order_merge_select_for_approve_by_page";
            public const string logistics_customer_order_merge_select_by_page = "logistics_customer_order_merge_select_by_page";
            public const string logistics_customer_order_merge_balance_ADD = "logistics_customer_order_merge_balance_ADD";
            public const string logistics_customer_order_merge_balance_Delete = "logistics_customer_order_merge_balance_Delete";
            public const string logistics_customer_order_merge_balance_Exists = "logistics_customer_order_merge_balance_Exists";
            public const string logistics_customer_order_merge_balance_GetList = "logistics_customer_order_merge_balance_GetList";
            public const string logistics_customer_order_merge_balance_GetModel = "logistics_customer_order_merge_balance_GetModel";
            public const string logistics_customer_order_merge_balance_GetModel_By_MergeID = "logistics_customer_order_merge_balance_GetModel_By_MergeID";
            public const string logistics_customer_order_merge_balance_log_ADD = "logistics_customer_order_merge_balance_log_ADD";
            public const string logistics_customer_order_merge_balance_log_Exists = "logistics_customer_order_merge_balance_log_Exists";
            public const string logistics_customer_order_merge_balance_log_GetList = "logistics_customer_order_merge_balance_log_GetList";
            public const string logistics_customer_order_merge_balance_log_GetModel = "logistics_customer_order_merge_balance_log_GetModel";
            public const string logistics_customer_order_merge_balance_log_Update = "logistics_customer_order_merge_balance_log_Update";
            public const string logistics_customer_order_merge_balance_Update = "logistics_customer_order_merge_balance_Update";
            public const string logistics_customer_order_merge_transaction_ADD = "logistics_customer_order_merge_transaction_ADD";
            public const string logistics_customer_order_merge_transaction_Delete = "logistics_customer_order_merge_transaction_Delete";
            public const string logistics_customer_order_merge_transaction_Exists = "logistics_customer_order_merge_transaction_Exists";
            public const string logistics_customer_order_merge_transaction_GetList = "logistics_customer_order_merge_transaction_GetList";
            public const string logistics_customer_order_merge_transaction_GetModel = "logistics_customer_order_merge_transaction_GetModel";
            public const string logistics_customer_order_merge_transaction_log_GetList = "logistics_customer_order_merge_transaction_log_GetList";
            public const string logistics_customer_order_merge_transaction_log_Delete = "logistics_customer_order_merge_transaction_log_Delete";
            public const string logistics_customer_order_merge_transaction_log_GetModel = "logistics_customer_order_merge_transaction_log_GetModel";
            public const string logistics_customer_order_merge_transaction_log_Update = "logistics_customer_order_merge_transaction_log_Update";
            public const string logistics_customer_order_merge_transaction_Update = "logistics_customer_order_merge_transaction_Update";
            public const string logistics_customer_order_merge_balance_log_Delete = "logistics_customer_order_merge_balance_log_Delete";
            public const string logistics_customer_order_merge_transaction_log_ADD = "logistics_customer_order_merge_transaction_log_ADD";
            public const string logistics_customer_order_merge_status_summary = "logistics_customer_order_merge_status_summary";
            public const string logistics_customer_order_merge_status_admin_summary = "logistics_customer_order_merge_status_admin_summary";
        }
        public class CustomerOrderMergeDetail
        {
            public const string logistics_customer_order_merge_detail_insert = "logistics_customer_order_merge_detail_insert";
            public const string logistics_customer_order_merge_detail_update = "logistics_customer_order_merge_detail_update";
            public const string logistics_customer_order_merge_detail_delete_by_id = "logistics_customer_order_merge_detail_delete_by_id";
            public const string logistics_customer_order_merge_detail_delete_by_merge_id = "logistics_customer_order_merge_detail_delete_by_merge_id";
            public const string logistics_customer_order_merge_detail_select_by_merge_id = "logistics_customer_order_merge_detail_select_by_merge_id";

        }

        public class CustomerOrderMergeStatus
        {
            public const string logistics_customer_order_merge_status_insert = "logistics_customer_order_merge_status_insert";
            public const string logistics_customer_order_merge_status_select_by_id = "logistics_customer_order_merge_status_select_by_id";
            public const string logistics_customer_order_merge_status_Update = "logistics_customer_order_merge_status_Update";
            public const string logistics_customer_order_merge_status_delete_by_id = "logistics_customer_order_merge_status_delete_by_id";
            public const string logistics_customer_order_merge_status_delete_by_merge_id = "logistics_customer_order_merge_status_delete_by_merge_id";
            public const string logistics_customer_order_merge_status_select_by_merge_id = "logistics_customer_order_merge_status_select_by_merge_id";
        }

        public class CustomerOrderMergeRelation
        {
            public const string logistics_customer_order_merge_relation_insert = "logistics_customer_order_merge_relation_insert";
            public const string logistics_customer_order_merge_relation_select_by_id = "logistics_customer_order_merge_relation_select_by_id";
            public const string logistics_customer_order_merge_relation_update_by_id = "logistics_customer_order_merge_relation_update_by_id";
            public const string logistics_customer_order_merge_relation_delete_by_id = "logistics_customer_order_merge_relation_delete_by_id";
            public const string logistics_customer_order_merge_relation_delete_by_merge_id = "logistics_customer_order_merge_relation_delete_by_merge_id";
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

        public class CustomerOrderStatus
        {
            public const string logistics_customer_order_status_delete_by_id = "logistics_customer_order_status_delete_by_id";
            public const string logistics_order_status_select_by_order_id = "logistics_order_status_select_by_order_id";
            public const string logistics_order_select_by_userid_summary = "logistics_order_select_by_userid_summary";
            public const string logistics_customer_order_select_by_warehouseAdmin_summary = "logistics_customer_order_select_by_warehouseAdmin_summary";
            public const string logistics_customer_order_status_insert = "logistics_customer_order_status_insert";
            public const string logistics_customer_order_status_update_by_id = "logistics_customer_order_status_update_by_id";
        }

        public class CustomerOrder
        {
            public const string logistics_customer_order_delete_by_id = "logistics_customer_order_delete_by_id";
            public const string logistics_customer_order_update_by_id = "logistics_customer_order_update_by_id";
            public const string logistics_customer_order_insert = "logistics_customer_order_insert";
            public const string logistics_customer_order_select_by_where = "logistics_customer_order_select_by_where";
            public const string logistics_customer_order_select_by_page = "logistics_customer_order_select_by_page";
            public const string logistics_customer_order_select_by_id = "logistics_customer_order_select_by_id";
            public const string logistics_customer_order_express_index = "logistics_customer_order_express_index";
            public const string logistics_customer_order_index = "logistics_customer_order_index";
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
            public const string logistics_base_userinfo_log_select_by_time = "logistics_base_userinfo_log_select_by_time";
            public const string logistics_base_userinfo_select_member_index = "logistics_base_userinfo_select_member_index";
            public const string logistics_base_userinfo_select_customer_service_index = "logistics_base_userinfo_select_customer_service_index";
            public const string logistics_base_userinfo_select_warehouse_admin_index = "logistics_base_userinfo_select_warehouse_admin_index";
 
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
            public const string logistics_base_message_select_by_latest = "logistics_base_message_select_by_latest";
            public const string logistics_base_message_select_by_page = "logistics_base_message_select_by_page";
            public const string logistics_base_message_insert = "logistics_base_message_insert";
        }
    }
}
