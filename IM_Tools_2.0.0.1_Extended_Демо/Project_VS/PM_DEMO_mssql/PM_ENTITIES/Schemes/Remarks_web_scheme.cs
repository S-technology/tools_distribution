using IM.Hierarchy;
using IM.Functions;

namespace PM
{
    /// <summary>
    /// Управление проектами
    /// </summary>
    public class Remarks_web_scheme : IScheme
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
        static string f_num_class = "";
        /// <summary>
        /// номер класса "Задания" в таблице CLASS_DESCRIPTION
        /// </summary>
        static public string num_class
        {
            get
            {
                if (f_num_class.IsEmpty())
                {
                    f_num_class = FuncDB.GetNppById("CLASS_DESCRIPTION", "NAME_CLASS", "\'SrRemarkEntity\'", "NUM_CLASS").ObjToStr();
                }
                return f_num_class;
            }
        }
        /// <summary>
        /// текст схемы
        /// </summary>
        public static string scheme_text =
"<Task " +
"     task_caption                         ='Управление проектами'" +
"     UID                                  ='" + UID + "'" +
"     cycle_enabled                        ='True'" +
"     max_filters_in_row                   ='7'" +
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
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         privileg_delete                      ='never'" +
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
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         privileg_delete                      ='never'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Статус задания'" +
"         UID                                  ='2'" +
"         entity_name                          ='SrRStatusEntity'" +
"         Name_Field                           ='NAME_STATUS_SRST'" +
"         ID_Field                             ='ID_SR_R_STATUS_SRST'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         privileg_delete                      ='never'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Исполнитель'" +
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
"         caption                              ='Автор задания'" +
"         UID                                  ='4'" +
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
"         caption                              ='Задания'" +
"         UID                                  ='5'" +
"         entity_name                          ='SrRemarkEntity'" +
"         form                                 ='PM.Forms.fm_Remark,PM'" +
"         Name_Field                           ='NUMBER_PP_SRRM'" +
"         ID_Field                             ='ID_SR_REMARK_SRRM'" +
"         enabled_node_statuses                ='ns_master_form;ns_detail_form;ns_master_filter;'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         append_entity_attributes             ='true'" +
"       >" +
"       <CustomTableAttributes>" +
"           <Attribute Name   ='NUMBER_PP_SRRM'" +
"               default_width ='40'" +
"           /> " +
"           <Attribute Name   ='SR_R_PROJECT_SRRM_NAME'" +
"               default_width ='100'" +
"           /> " +
"           <Attribute Name   ='DATE_CREATE_SRRM'" +
"           /> " +
"           <Attribute Name   ='REMARK_SRRM'" +
"               default_width ='300'" +
"               empty_control_rows_count='6'" +
"           /> " +
"           <Attribute Name   ='SR_R_STATUS_SRRM_NAME'" +
"           /> " +
"           <Attribute Name   ='COMMENT_EXECUT_SRRM'" +
"               default_width ='200'" +
"           /> " +
"           <Attribute Name   ='FROM_WHOM_SRRM_NAME'" +
"           /> " +
"           <Attribute Name   ='WHOM_SRRM_NAME'" +
"           /> " +
"           <Attribute Name   ='SR_R_PROMPTNESS_SRRM_NAME'" +
"           /> " +
"           <Attribute Name   ='NAME_DB_SRRM'" +
"           /> " +
"           <Attribute Name   ='PROGRAM_SRRM'" +
"           /> " +
"           <Attribute Name   ='PLACE_ERROR_SRRM'" +
"               default_width ='150'" +
"           /> " +
"           <Attribute Name   ='LINK_SRRM'" +
"               default_width ='150'" +
"           /> " +
"           <Attribute Name   ='PARENT_REMARK_SRRM_NAME'" +
"           /> " +
"           <Attribute Name   ='DATE_EXECUTE_SRRM'" +
"           /> " +
"           <Attribute Name   ='DATE_CHECKED_SRRM'" +
"           /> " +
"           <Attribute Name   ='VVOD_ID_CONTRACTOR_SRRM'" +
"           /> " +
"           <Attribute Name   ='CHANGE_ID_CONTRACTOR_SRRM'" +
"           /> " +
"           <Attribute Name   ='DATE_INPUT_SRRM'" +
"           /> " +
"           <Attribute Name   ='DATE_CHANGE_SRRM'" +
"           /> " +
"           <Attribute Name   ='ID_SR_REMARK_SRRM'" +
"               default_width ='50'" +
"           /> " +
"           <Attribute Name   ='IsFavorite'" +
"               Visible       ='false'" +
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
"         caption                              ='Детализация задания'" +
"         UID                                  ='6'" +
"         entity_name                          ='SrDetailRemarkEntity'" +
"         Name_Field                           ='NUMBER_PP_SRDR'" +
"         ID_Field                             ='ID_SR_DETAIL_REMARK_SRDR'" +
"         enabled_node_statuses                ='ns_detail_form;ns_master_form;'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         privileg_suffix                      ='always'" +
"         hide_form_buttons                    ='tb_delforce;tb_add_by_card'" +
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
"         caption                              ='Дата создания От'" +
"         UID                                  ='7'" +
"         enabled_node_statuses                ='ns_master_filter'" + 
"         enabled_filter_types                 ='ft_date'" +
"         privileg_suffix                      ='always'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Дата создания По'" +
"         UID                                  ='8'" +
"         enabled_node_statuses                ='ns_master_filter'" + 
"         enabled_filter_types                 ='ft_date'" +
"         privileg_suffix                      ='always'" +
"       >" +
"    </Node>" +

"    <Node" +
"         caption                              ='Дополнительные данные'" +
"         UID                                  ='9'" +
"         entity_name                          ='DdObjectEntity'" +
"         Name_Field                           ='NUMBER_PP_DDOB'" +
"         ID_Field                             ='ID_DD_OBJECT_DDOB'" +
"         enabled_node_statuses                ='ns_detail_form'" +
"         enabled_filter_types                 ='ft_show_data'" +
"         privileg_suffix                      ='always'" +
"         append_entity_attributes             ='true'" +
"         hide_form_buttons                    ='tb_delforce;tb_add_by_card;tb_card;tb_add'" +
"       >" +

"       <CustomTableAttributes>" +
"           <Attribute Name   ='NUM_CLASS_DDOB_NAME'" +
"               ReadOnly      ='true'" +
"           /> " +
"           <Attribute Name   ='NUMBER_PP_DDOB'" +
"               ReadOnly      ='true'" +
"           /> " +
"           <Attribute Name   ='TYPE_DATA_DDOB'" +
"               ReadOnly      ='true'" +
"           /> " +
"           <Attribute Name   ='COMMENT_DDOB'" +
"               default_width ='200'" +
"           /> " +
"           <Attribute Name   ='DOP_DATA_DDOB'" +
"           /> " +
"           <Attribute Name   ='EXPAND_DDOB'" +
"               ReadOnly      ='true'" +
"           /> " +
"           <Attribute Name   ='ID_OBJECT_DDOB'" +
"               ReadOnly      ='true'" +
"           /> " +
"           <Attribute Name   ='ID_DD_OBJECT_DDOB'" +
"               ReadOnly      ='true'" +
"           /> " +
"       </CustomTableAttributes>" +

"       <Masters>" +
"           <Master" +
"             parent_UID                           ='5'" +
"             condition                            ='DD_OBJECT_DDOB.ID_OBJECT_DDOB in (:ID)'" +
"             child_Id_Field                       ='ID_OBJECT_DDOB'" +
"             ever_link                            ='true'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='10'" +
"             condition                            ='DD_OBJECT_DDOB.NUM_CLASS_DDOB = :ID'" +
"             child_Id_Field                       ='NUM_CLASS_DDOB'" +
"             ever_link                            ='true'" +
"           /> " +
"       </Masters>" +
"    </Node>" +

"    <Node" +
"         caption                              ='Класс заданий'" +
"         UID                                  ='10'" +
"         Name_Field                           ='ID_Field'" +
"         ID_Field                             ='ID_Field'" +
"         enabled_node_statuses                ='ns_invisible;'" +
"         privileg_suffix                      ='always'" +
"         disable_save_Value                   ='true'" +
"         Value                                ='" + num_class + "' " +
"       >" +
"       <CustomTableAttributes>" +
"           <Attribute Name   ='ID_Field'" +
"               RusName       ='Код'" +
"               ReadOnly      ='true'" +
"               default_width ='30'" +
"               visible       ='false'" +
"           /> " +
"       </CustomTableAttributes>" +
"       <CustomTableRows>" +
"           <Row" +
"               cell_0     ='" + num_class + "'" +
"           /> " +
"       </CustomTableRows>" +
"    </Node>" +

"</Nodes>" +
"</Task>";
    }
} 
