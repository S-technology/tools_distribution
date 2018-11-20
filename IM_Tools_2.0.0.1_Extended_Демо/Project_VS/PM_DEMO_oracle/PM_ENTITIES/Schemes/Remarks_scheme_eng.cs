using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using IM.Hierarchy;
namespace PM
{
    /// <summary>
    /// Управление проектами
    /// </summary>
    public class Remarks_scheme_eng : IScheme
    {
        /// <summary>
        /// UID графа
        /// </summary>
        public static string UID = "Remarks";
        /// <summary>
        /// получить текст схемы
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            return scheme_text;
        }
        /// <summary>
        /// текст схемы
        /// </summary>
        public static string scheme_text =
"<Task " +
"     task_caption                         ='Project Manager'" +
"     UID                                  ='" + UID + "'" +
"     cycle_enabled                        ='True'" +
"     hide_form_buttons                    ='tb_period'" +
"     strong_ierarchi_visualization        ='false'" +
">" +
"<Nodes>" +
"    <Node" +
"         caption                              ='Project'" +
"         UID                                  ='0'" +
"         entity_name                          ='SrRProjectEntity'" +
"         Name_Field                           ='NAME_PROJ_SRPJ'" +
"         ID_Field                             ='ID_SR_R_PROJECT_SRPJ'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         privileg_delete                      ='never'" +
            //"         privileg_suffix                      ='default'" + 
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Promptness'" +
"         UID                                  ='1'" +
"         entity_name                          ='SrRPromptnessEntity'" +
"         Name_Field                           ='NAME_SRPR'" +
"         ID_Field                             ='ID_SR_R_PROMPTNESS_SRPR'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         privileg_delete                      ='never'" +
            //"         privileg_suffix                      ='default'" + 
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Status'" +
"         UID                                  ='2'" +
"         entity_name                          ='SrRStatusEntity'" +
"         Name_Field                           ='NAME_STATUS_SRST'" +
"         ID_Field                             ='ID_SR_R_STATUS_SRST'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         privileg_delete                      ='never'" +
            //"         privileg_suffix                      ='default'" + 
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Executor'" +
"         UID                                  ='3'" +
"         entity_name                          ='SrRExecutiveEntity'" +
"         Name_Field                           ='FIO_SREX'" +
"         ID_Field                             ='ID_SR_R_EXECUTIVE_SREX'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         privileg_delete                      ='never'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Author'" +
"         UID                                  ='4'" +
"         entity_name                          ='SrRExecutiveEntity'" +
"         Name_Field                           ='FIO_SREX'" +
"         ID_Field                             ='ID_SR_R_EXECUTIVE_SREX'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         privileg_delete                      ='never'" +
            //"         privileg_suffix                      ='SREX'" + 
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Remark'" +
"         UID                                  ='5'" +
"         entity_name                          ='SrRemarkEntity'" +
"         form                                 ='PM.Forms.fm_Remark,PM'" +
"         Name_Field                           ='NUMBER_PP_SRRM'" +
"         ID_Field                             ='ID_SR_REMARK_SRRM'" +
"         enabled_node_statuses                ='ns_master_form;ns_detail_form;ns_master_filter;'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
//"         privileg_delete                      ='never'" +
            //"         privileg_suffix                      ='SRRM'" + 
"         append_entity_attributes             ='true'" +
"         paging_allowed                       ='true'" +
"       >" +
"       <CustomTableAttributes>" +
"           <Attribute Name   ='NUMBER_PP_SRRM'" +
"               default_width ='40'" +
"           /> " +
"           <Attribute Name   ='SR_R_PROJECT_SRRM_NAME'" +
"               default_width ='100'" +
"           /> " +
"           <Attribute Name   ='REMARK_SRRM'" +
"               default_width ='300'" +
"           /> " +
"       </CustomTableAttributes>" +
"       <Masters>" +
"           <Master" +
"             parent_UID                           ='0'" +
"             condition                            ='SR_REMARK_SRRM.ID_SR_R_PROJECT_SRRM in (:ID)'" +
"             child_Id_Field                       ='ID_SR_R_PROJECT_SRRM'" +
"             str_columns_to_hide                  ='SR_R_PROJECT_SRRM_NAME'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='1'" +
"             condition                            ='SR_REMARK_SRRM.ID_SR_R_PROMPTNESS_SRRM in (:ID)'" +
"             child_Id_Field                       ='ID_SR_R_PROMPTNESS_SRRM'" +
"             str_columns_to_hide                  ='SR_R_PROMPTNESS_SRRM_NAME'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='2'" +
"             condition                            ='SR_REMARK_SRRM.ID_SR_R_STATUS_SRRM in (:ID)'" +
//"             child_Id_Field                       ='ID_SR_R_STATUS_SRRM'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='3'" +
"             condition                            ='SR_REMARK_SRRM.ID_WHOM_SRRM in (:ID)'" +
"             child_Id_Field                       ='ID_WHOM_SRRM'" +
"             str_columns_to_hide                  ='WHOM_SRRM_NAME'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='4'" +
"             condition                            ='SR_REMARK_SRRM.ID_FROM_WHOM_SRRM in (:ID)'" +
"             child_Id_Field                       ='ID_FROM_WHOM_SRRM'" +
"             str_columns_to_hide                  ='FROM_WHOM_SRRM_NAME'" +
"           /> " +

"           <Master" +
"             parent_UID                           ='7'" +
"             condition                            ='SR_REMARK_SRRM.DATE_CREATE_SRRM &gt;= :ID'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='8'" +
"             condition                            ='SR_REMARK_SRRM.DATE_CREATE_SRRM &lt;= :ID'" +
"           /> " + 

"       </Masters>" +
"    </Node>" +
"    <Node" +
"         caption                              ='Remark details'" +
"         UID                                  ='6'" +
"         entity_name                          ='SrDetailRemarkEntity'" +
"         Name_Field                           ='NUMBER_PP_SRDR'" +
"         ID_Field                             ='ID_SR_DETAIL_REMARK_SRDR'" +
"         enabled_node_statuses                ='ns_invisible;ns_detail_form;ns_master_form;'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         privileg_suffix                      ='always'" +
//"         privileg_delete                      ='never'" +
            //"         privileg_suffix                      ='SRDR'" +
"       >" +
"       <Masters>" +
"           <Master" +
"             parent_UID                           ='5'" +
"             condition                            ='SR_DETAIL_REMARK_SRDR.ID_SR_REMARK_SRDR in (:ID)'" +
"             child_Id_Field                       ='ID_SR_REMARK_SRDR'" +
"             str_columns_to_hide                  ='SR_REMARK_SRDR_NAME'" +
"             ever_link                            ='true'" +
"           /> " +
"       </Masters>" +
"    </Node>" +

"    <Node" +
"         caption                              ='Date create from'" +
"         UID                                  ='7'" +
"         enabled_node_statuses                ='ns_master_filter;ns_invisible'" +
"         enabled_filter_types                 ='ft_date'" +
"         privileg_suffix                      ='always'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Date create to'" +
"         UID                                  ='8'" +
"         enabled_node_statuses                ='ns_master_filter;ns_invisible'" +
"         enabled_filter_types                 ='ft_date'" +
"         privileg_suffix                      ='always'" +
"       >" +
"    </Node>" + 

"</Nodes>" +
"</Task>";
    }
} 
