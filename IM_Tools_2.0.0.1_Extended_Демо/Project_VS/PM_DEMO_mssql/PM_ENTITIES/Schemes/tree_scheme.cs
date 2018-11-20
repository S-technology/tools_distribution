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
    public class Remarks : IScheme 
    { 
        /// <summary>
        /// UID графа
        /// </summary>
        public static string UID = "Remarks";
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
"     task_caption                         ='Управление проектами'" + 
"     UID                                  ='" + UID + "'" + 
"     need_save_config                     ='False'" + 
"     max_filters_in_row                   ='9'" + 
"     is_tree                              ='True'" + 
">" + 
"<Nodes>" + 
"    <Node" + 
"         caption                              ='Проект'" + 
"         UID                                  ='0'" + 
"         entity_name                          ='SrRProjectEntity'" + 
"         Name_Field                           ='NAME_PROJ_SRPJ'" + 
"         ID_Field                             ='ID_SR_R_PROJECT_SRPJ'" + 
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" + 
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" + 
"         multi_select                         ='True'" + 
"         privileg_suffix                      ='always'" + 
"         privileg_view_name                   ='VIEW_always'" + 
"         privileg_edit_name                   ='CHAN_always'" + 
"         privileg_insert_name                 ='BUILD_always'" + 
"         privileg_delete_name                 ='never'" + 
"         privileg_copy_name                   ='COPY_always'" + 
"       >" + 
"    </Node>" + 
"    <Node" + 
"         caption                              ='Срочность выполнения'" + 
"         UID                                  ='1'" + 
"         entity_name                          ='SrRPromptnessEntity'" + 
"         Name_Field                           ='NAME_SRPR'" + 
"         ID_Field                             ='ID_SR_R_PROMPTNESS_SRPR'" + 
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" + 
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" + 
"         multi_select                         ='True'" + 
"         privileg_suffix                      ='always'" + 
"         privileg_view_name                   ='VIEW_always'" + 
"         privileg_edit_name                   ='CHAN_always'" + 
"         privileg_insert_name                 ='BUILD_always'" + 
"         privileg_delete_name                 ='never'" + 
"         privileg_copy_name                   ='COPY_always'" + 
"       >" + 
"       <Masters>" + 
"           <Master" + 
"             parent_UID                           ='5'" + 
"           /> " + 
"       </Masters>" + 
"    </Node>" + 
"    <Node" + 
"         caption                              ='Статус задания'" + 
"         UID                                  ='2'" + 
"         entity_name                          ='SrRStatusEntity'" + 
"         Name_Field                           ='NAME_STATUS_SRST'" + 
"         ID_Field                             ='ID_SR_R_STATUS_SRST'" + 
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" + 
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" + 
"         multi_select                         ='True'" + 
"         privileg_suffix                      ='always'" + 
"         privileg_view_name                   ='VIEW_always'" + 
"         privileg_edit_name                   ='CHAN_always'" + 
"         privileg_insert_name                 ='BUILD_always'" + 
"         privileg_delete_name                 ='never'" + 
"         privileg_copy_name                   ='COPY_always'" + 
"       >" + 
"       <Masters>" + 
"           <Master" + 
"             parent_UID                           ='5'" + 
"           /> " + 
"       </Masters>" + 
"    </Node>" + 
"    <Node" + 
"         caption                              ='Исполнитель'" + 
"         UID                                  ='3'" + 
"         entity_name                          ='SrRExecutiveEntity'" + 
"         Name_Field                           ='FIO_SREX'" + 
"         ID_Field                             ='ID_SR_R_EXECUTIVE_SREX'" + 
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" + 
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" + 
"         multi_select                         ='True'" + 
"         privileg_suffix                      ='always'" + 
"         privileg_view_name                   ='VIEW_always'" + 
"         privileg_edit_name                   ='CHAN_always'" + 
"         privileg_insert_name                 ='BUILD_always'" + 
"         privileg_delete_name                 ='never'" + 
"         privileg_copy_name                   ='COPY_always'" + 
"       >" + 
"       <Masters>" + 
"           <Master" + 
"             parent_UID                           ='2'" + 
"           /> " + 
"       </Masters>" + 
"    </Node>" + 
"    <Node" + 
"         caption                              ='Автор задания'" + 
"         UID                                  ='4'" + 
"         entity_name                          ='SrRExecutiveEntity'" + 
"         Name_Field                           ='FIO_SREX'" + 
"         ID_Field                             ='ID_SR_R_EXECUTIVE_SREX'" + 
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" + 
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" + 
"         multi_select                         ='True'" + 
"         privileg_suffix                      ='always'" + 
"         privileg_view_name                   ='VIEW_always'" + 
"         privileg_edit_name                   ='CHAN_always'" + 
"         privileg_insert_name                 ='BUILD_always'" + 
"         privileg_delete_name                 ='never'" + 
"         privileg_copy_name                   ='COPY_always'" + 
"       >" + 
"       <Masters>" + 
"           <Master" + 
"             parent_UID                           ='2'" + 
"           /> " + 
"       </Masters>" + 
"    </Node>" + 
"    <Node" + 
"         caption                              ='Задания'" + 
"         UID                                  ='5'" + 
"         form_name                            ='PM.Forms.fm_Remark,PM'" + 
"         entity_name                          ='SrRemarkEntity'" + 
"         Name_Field                           ='NUMBER_PP_SRRM'" + 
"         ID_Field                             ='ID_SR_REMARK_SRRM'" + 
"         enabled_node_statuses                ='ns_master_form;ns_detail_form;ns_master_filter;'" + 
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" + 
"         multi_select                         ='True'" + 
"         privileg_suffix                      ='always'" + 
"         privileg_view_name                   ='VIEW_always'" + 
"         privileg_edit_name                   ='CHAN_always'" + 
"         privileg_insert_name                 ='BUILD_always'" + 
"         privileg_delete_name                 ='never'" + 
"         privileg_copy_name                   ='COPY_always'" + 
"       >" + 
"       <Masters>" + 
"           <Master" + 
"             parent_UID                           ='0'" + 
"             condition                            ='ID_SR_R_PROJECT_SRRM in (:ID)'" + 
"             child_Id_Field                       ='ID_SR_R_PROJECT_SRRM'" + 
"             str_columns_to_hide                  ='SR_R_PROJECT_SRRM_NAME'" + 
"           /> " + 
"       </Masters>" + 
"    </Node>" + 
"    <Node" + 
"         caption                              ='Детализация задания'" + 
"         UID                                  ='6'" + 
"         entity_name                          ='SrDetailRemarkEntity'" + 
"         Name_Field                           ='NUMBER_PP_SRDR'" + 
"         ID_Field                             ='ID_SR_DETAIL_REMARK_SRDR'" + 
"         enabled_node_statuses                ='ns_detail_form;ns_master_form;ns_invisible'" + 
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" + 
"         privileg_suffix                      ='always'" + 
"         privileg_view_name                   ='VIEW_always'" + 
"         privileg_edit_name                   ='CHAN_always'" + 
"         privileg_insert_name                 ='BUILD_always'" + 
"         privileg_delete_name                 ='never'" + 
"         privileg_copy_name                   ='COPY_always'" + 
"       >" + 
"       <Masters>" + 
"           <Master" + 
"             parent_UID                           ='5'" + 
"             condition                            ='ID_SR_REMARK_SRDR in (:ID)'" + 
"             child_Id_Field                       ='ID_SR_REMARK_SRDR'" + 
"             str_columns_to_hide                  ='SR_REMARK_SRDR_NAME'" + 
"             ever_link                            ='True'" + 
"           /> " + 
"       </Masters>" + 
"    </Node>" + 
"</Nodes>" + 
"</Task>";
    } 
} 
