using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using IM.Hierarchy; 
 
namespace PM  
{ 
    /// <summary>
    /// Пользователи - привилегии
    /// </summary>
    public class User_Privs : IScheme 
    { 
        /// <summary>
        /// UID графа
        /// </summary>
        public static string UID = "User_Privs";
        /// <summary>
        /// получить текст схемы
        /// </summary>
        public string GetText() 
        { 
            return scheme_text; 
        } 
        /// <summary>
        /// текст схемы
        /// </summary>
        public static string scheme_text = 
"<Task " + 
"     task_caption                         ='Пользователи - привилегии'" + 
"     UID                                  ='" + UID + "'" + 
"     max_filters_in_row                   ='9'" + 
">" + 
"<Nodes>" + 
"    <Node" + 
"         caption                              ='Пользователи'" + 
"         UID                                  ='Users'" + 
"         entity_name                          ='s_UserEntity'" + 
"         Name_Field                           ='USER_FIO'" +
"         ID_Field                             ='DBCONNECT_NAME'" + //ROWID
"         enabled_node_statuses                ='ns_master_filter'" + //;ns_master_form
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
//"         hide_form_buttons                    ='tb_card;tb_copy'" +
"       >" + 
"    </Node>" + 
"    <Node" + 
"         caption                              ='Привилегии'" + 
"         UID                                  ='Privs'" + 
"         entity_name                          ='s_PrivilegeEntity'" + 
"         Name_Field                           ='PRIV_NAME'" + 
"         ID_Field                             ='PRIV_ID'" +
"         enabled_node_statuses                ='ns_master_form'" + //;ns_detail_form
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
//"         hide_form_buttons                    ='tb_card;tb_copy'" +
"         allow_check_rows                     ='true'" +
"       >" + 
"       <Masters>" + 
"           <Master" +
"             parent_UID                           ='Users'" + 
"           /> " + 
"       </Masters>" + 
"    </Node>" + 
"</Nodes>" + 
"</Task>";
    } 
} 
