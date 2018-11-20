using IM.Hierarchy;
using IM.Functions;
using PM.Entity;
using S_;
/*
	01.03.16 Киселев добавлена закладка с избранными замечаниями
    02.03.16 Киселев fix 14103 добавлен фильтр "Авторство"
*/
namespace PM
{
    /// <summary>
    /// Управление проектами
    /// </summary>
    public class Remarks_scheme : IScheme
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
        public static string scheme_text = string.Format(
"<Task " +
"     task_caption                         ='Управление проектами'" +
"     UID                                  ='{0}'" +
"     cycle_enabled                        ='True'" +
"     hide_form_buttons                    ='tb_period'" +
"     strong_ierarchi_visualization        ='false'" +
"     SchemeAdapterName                    ='PM_ENTITIES.PMSchemeAdapter,PM_ENTITIES' " +
"	  HideUnlinkedTopFilters               = 'true'" +
//"	  HideUnlinkedDetails                  = 'true'" +
">" +
"<Nodes>" +
"    <Node" +
"         caption                              ='Проект'" +
"         UID                                  ='0'" +
"         Form                                 ='PM.Forms.FormProjects,PM'" +
"         entity_name                          ='SrRProjectEntity'" +
"         Name_Field                           ='NAME_PROJ_SRPJ'" +
"         ID_Field                             ='ID_SR_R_PROJECT_SRPJ'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox;ft_graf'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='default'" +
"         privileg_delete                      ='never'" +
"         paging_allowed                       ='true'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Срочность выполнения'" +
"         UID                                  ='01'" +
"         entity_name                          ='SrRPromptnessEntity'" +
"         Name_Field                           ='NAME_SRPR'" +
"         ID_Field                             ='ID_SR_R_PROMPTNESS_SRPR'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='default'" +
"         privileg_delete                      ='never'" +
"         paging_allowed                       ='true'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Статус задания'" +
"         UID                                  ='02'" +
"         entity_name                          ='SrRStatusEntity'" +
"         Name_Field                           ='NAME_STATUS_SRST'" +
"         ID_Field                             ='ID_SR_R_STATUS_SRST'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='default'" +
"         privileg_delete                      ='never'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Исполнитель'" +
"         UID                                  ='03'" +
"         entity_name                          ='SrRExecutiveEntity'" +
"         Name_Field                           ='FIO_SREX'" +
"         ID_Field                             ='ID_SR_R_EXECUTIVE_SREX'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='default'" +
"         privileg_delete                      ='never'" +
"         paging_allowed                       ='true'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Автор задания'" +
"         UID                                  ='04'" +
"         entity_name                          ='SrRExecutiveEntity'" +
"         Name_Field                           ='FIO_SREX'" +
"         ID_Field                             ='ID_SR_R_EXECUTIVE_SREX'" +
"         enabled_node_statuses                ='ns_master_filter;ns_master_form'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='default'" +
"         privileg_delete                      ='never'" +
"         paging_allowed                       ='true'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Задания'" +
"         UID                                  ='05'" +
"         entity_name                          ='SrRemarkEntity'" +
"         form                                 ='PM.Forms.fm_Remark,PM'" +
"         Name_Field                           ='NUMBER_PP_SRRM'" +
"         ID_Field                             ='ID_SR_REMARK_SRRM'" +
"         enabled_node_statuses                ='ns_master_form;ns_detail_form;ns_master_filter;'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
//"         privileg_suffix                      ='always'" +
//"         privileg_suffix                      ='SRRM'" +
"         privileg_view_name                   ='VIEW_SRRM'" +
"         privileg_edit_name                   ='CHAN_SRRM'" +
"         privileg_insert_name                 ='BUILD_SRRM'" +
"         privileg_delete_name                 ='DEL_SRRM'" +
"         privileg_copy_name                   ='COPY_SRRM'" + 
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
//"       <CustomFormButtons>" +
//"           <Button Name   ='tb_custom'" +
//"               Title         ='Из схемы'" +
//"               EnabledInEdit ='True'" +
//"               Image         ='s_Light'" +
//"               IsSplitter    ='False'" +
//"               PrevButton    ='tb_tree'" +
//"           /> " +
//"       </CustomFormButtons>" +
"       <Masters>" +
"           <Master" +
"             parent_UID                           ='0'" +
"             condition                            ='SR_REMARK_SRRM.ID_SR_R_PROJECT_SRRM in (:ID)'" +
"             child_Id_Field                       ='ID_SR_R_PROJECT_SRRM'" +
"             str_columns_to_hide                  ='SR_R_PROJECT_SRRM_NAME'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='01'" +
"             condition                            ='SR_REMARK_SRRM.ID_SR_R_PROMPTNESS_SRRM in (:ID)'" +
"             child_Id_Field                       ='ID_SR_R_PROMPTNESS_SRRM'" +
"             str_columns_to_hide                  ='SR_R_PROMPTNESS_SRRM_NAME'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='02'" +
"             condition                            ='SR_REMARK_SRRM.ID_SR_R_STATUS_SRRM in (:ID)'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='03'" +
"             condition                            ='SR_REMARK_SRRM.ID_WHOM_SRRM in (:ID)'" +
"             child_Id_Field                       ='ID_WHOM_SRRM'" +
"             str_columns_to_hide                  ='WHOM_SRRM_NAME'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='04'" +
"             condition                            ='SR_REMARK_SRRM.ID_FROM_WHOM_SRRM in (:ID)'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='07'" +
"             condition                            ='SR_REMARK_SRRM.DATE_CREATE_SRRM &gt;= :ID'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='08'" +
"             condition                            ='SR_REMARK_SRRM.DATE_CREATE_SRRM &lt;= :ID'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='11'" +
"             condition                            ='1=2 or SR_REMARK_SRRM.ID_SR_REMARK_SRRM in (:ID)'" +
"           /> " +
"       </Masters>" +
"    </Node>" +
"    <Node" +
"         caption                              ='Избранное'" +
"         UID                                  ='055'" +
"         entity_name                          ='SrRemarkEntity'" +
"         form                                 ='PM.Forms.fm_Remark,PM'" +
"         Name_Field                           ='NUMBER_PP_SRRM'" +
"         ID_Field                             ='ID_SR_REMARK_SRRM'" +
"         enabled_node_statuses                ='ns_master_form;ns_detail_form;ns_master_filter;'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         multi_select                         ='true'" +
"         privileg_suffix                      ='always'" +
"         append_entity_attributes             ='true'" +
"         paging_allowed                       ='true'" +
//"		  read_only='true'" +				   // fix 14102
"	      condition_before_open				   ='SR_REMARK_SRRM.ID_SR_REMARK_SRRM in (" +
" select ID_SR_REMARK_SRFV " +
" from " + "SR_FAVORITE_SRFV".ToFullObjectName(s_DatabaseObjectType.Table) +
" where ID_SR_R_EXECUTIVE_SRFV = {1})'" + 
"       >" +
"  <Masters>" +
"           <Master" +
"             parent_UID                           ='12'" +
"             condition                            =':ID'" +
"           /> " +
"           <Master" +
"             parent_UID                           ='13'" +
"             condition                            =':ID'" +
"           /> " +
"       </Masters>" +
"</Node>"+
"    <Node" +
"         caption                              ='Детализация задания'" +
"         UID                                  ='06'" +
"         entity_name                          ='SrDetailRemarkEntity'" +
"         Name_Field                           ='NUMBER_PP_SRDR'" +
"         ID_Field                             ='ID_SR_DETAIL_REMARK_SRDR'" +
"         enabled_node_statuses                ='ns_detail_form;ns_master_form;ns_invisible;'" +
"         enabled_filter_types                 ='ft_show_data;ft_comboBox'" +
"         privileg_suffix                      ='SRDR'" +
"       >" +
"       <Masters>" +
"           <Master" +
"             parent_UID                           ='05'" +
"             condition                            ='SR_DETAIL_REMARK_SRDR.ID_SR_REMARK_SRDR in (:ID)'" +
"             child_Id_Field                       ='ID_SR_REMARK_SRDR'" +
"             str_columns_to_hide                  ='SR_REMARK_SRDR_NAME'" +
"             ever_link                            ='true'" +
"           /> " +
"       </Masters>" +
"    </Node>" +

"    <Node" +
"         caption                              ='Дата создания От'" +
"         UID                                  ='07'" +
"         enabled_node_statuses                ='ns_master_filter;ns_invisible'" +
"         enabled_filter_types                 ='ft_date'" +
"         privileg_suffix                      ='always'" +
"       >" +
"    </Node>" +
"    <Node" +
"         caption                              ='Дата создания По'" +
"         UID                                  ='08'" +
"         enabled_node_statuses                ='ns_master_filter;ns_invisible'" +
"         enabled_filter_types                 ='ft_date'" +
"         privileg_suffix                      ='always'" +
"       >" +
"    </Node>" +

"    <Node" +
"         caption                              ='Дополнительные данные'" +
"         UID                                  ='09'" +
"         form                                 ='IM.Hierarchy.Forms.FormDDOB,IM.CommonForms'" +
"         entity_name                          ='DdObjectEntity'" +
"         Name_Field                           ='NUMBER_PP_DDOB'" +
"         ID_Field                             ='ID_DD_OBJECT_DDOB'" +
"         enabled_node_statuses                ='ns_detail_form;ns_master_form;ns_invisible;'" +
"         enabled_filter_types                 ='ft_show_data'" +
"         privileg_suffix                      ='DDOB'" +
"       >" +
"       <Masters>" +
"           <Master" +
"             parent_UID                           ='05'" +
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
"         Value                                ='{2}' " +
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
"               cell_0     ='{2}'" +
"           /> " +
"       </CustomTableRows>" +
"    </Node>" +

"    <Node" +
"         caption                              ='ID задания'" +
"         UID                                  ='11'" +
"         enabled_node_statuses                ='ns_master_filter;ns_invisible'" +
"         enabled_filter_types                 ='ft_const'" +
"         privileg_suffix                      ='always'" +
"         ValueIsNumber                        ='true'" +
"       >" +
"    </Node>" +

"    <Node" +
"       Caption          ='Автор'" +
"       ind              ='12'" +
"       Name_Field       ='Name_Field'" +
"       ID_Field         ='ID_Field'" +
"       Enabled_node_statuses='ns_show_data;ns_comboBox' " +
"       Default_node_status  ='ns_show_data'" +
//"       MultiSelect      ='true' " +
"       privileg_suffix  ='always'" +
"       row_num          ='2'" +
"       col_num          ='8'" +
"       >" +
"       <CustomTableAttributes>" +
"           <Attribute Name   ='ID_Field'" +
"               RusName       ='Код'" +
"               ReadOnly      ='true'" +
"               default_width ='45'" +
"               visible='false'" +
"           /> " +
"           <Attribute Name   ='Name_Field'" +
"               RusName       ='Значение'" +
"               ReadOnly      ='true'" +
"               default_width ='400'" +
"           /> " +
"       </CustomTableAttributes>" +
"       <CustomTableRows>" +
/*
"           <Row" +
"               cell_0     ='1=1'" +
"               cell_1     ='Все'" +
"           /> " +
"           <Row" +
"               cell_0     ='SR_REMARK_SRRM.ID_SR_REMARK_SRRM in (" +
" select ID_SR_REMARK_SRFV " +
" from " + "SR_FAVORITE_SRFV".ToFullObjectName(s_DatabaseObjectType.Table) +
" 	join " + SrRemarkEntity.TableName  + " on " + SrRemarkEntity.ColumnIdSrRemark + " = " + SrFavoriteEntity.ColumnIdSrRemark + 
" where ID_SR_R_EXECUTIVE_SRFV = {1}" + 
" 	 and " + SrRemarkEntity.ColumnIdFromWhom + " = {1})'" +
"               cell_1     ='Свои'" +
"           /> " +
"           <Row" +
"               cell_0     ='SR_REMARK_SRRM.ID_SR_REMARK_SRRM in (" +
" select ID_SR_REMARK_SRFV " +
" from " + "SR_FAVORITE_SRFV".ToFullObjectName(s_DatabaseObjectType.Table) +
" 	join " + SrRemarkEntity.TableName + " on " + SrRemarkEntity.ColumnIdSrRemark + " = " + SrFavoriteEntity.ColumnIdSrRemark +
" where ID_SR_R_EXECUTIVE_SRFV = {1}" + 
" 	 and " + SrRemarkEntity.ColumnIdFromWhom + " &lt;&gt; {1})'" +
"               cell_1     ='Чужие'" +
"           /> " +								 */
"       </CustomTableRows>" +
"    </Node>" +

"    <Node" +
"       Caption          ='Исполнитель'" +
"       ind              ='13'" +
"       Name_Field       ='Name_Field'" +
"       ID_Field         ='ID_Field'" +
"       Enabled_node_statuses='ns_show_data;ns_comboBox' " +
"       Default_node_status  ='ns_show_data'" +
//"       MultiSelect      ='true' " +
"       privileg_suffix  ='default'" +
"       row_num          ='2'" +
"       col_num          ='8'" +
"       >" +
"       <CustomTableAttributes>" +
"           <Attribute Name   ='ID_Field'" +
"               RusName       ='Код'" +
"               ReadOnly      ='true'" +
"               default_width ='45'" +
"               visible='false'" +
"           /> " +
"           <Attribute Name   ='Name_Field'" +
"               RusName       ='Значение'" +
"               ReadOnly      ='true'" +
"               default_width ='400'" +
"           /> " +
"       </CustomTableAttributes>" +
"    </Node>" +
"</Nodes>" +
"</Task>", UID, SrRExecutiveEntity.GetIdCurrentUser(), num_class);
    }
} 
