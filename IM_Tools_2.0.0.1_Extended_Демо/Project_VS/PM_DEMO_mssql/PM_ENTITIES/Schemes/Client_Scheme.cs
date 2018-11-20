using IM.Hierarchy; 
using System; 
 
namespace IM.Hierarchy.Forms  
{ 
    /// <summary>
    /// Заказчики
    /// </summary>
    public class ClientsScheme : IScheme 
    { 
        /// <summary>
        /// UID
        /// </summary>
        public static string UID = "Clients";
        /// <summary>
        /// текст схемы
        /// </summary>
        public string GetText() 
        { 
            return SchemeText; 
        } 
        /// <summary>
        /// текст схемы
        /// </summary>
        public static string SchemeText = String.Format(@"
<Task 
     xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'
     xsi:schemaLocation='Graph Graph.xsd'
     Caption                              ='Заказчики'
     UID                                  ='{0}'
     NeedSaveConfig                       ='False'
     SchemeRadius                         ='240'
     MaxFiltersInRow                      ='2'
     HideFormButtons                      ='tb_period'
     SchemeAdapterName                    ='PM_ENTITIES.ClientsAdapter,PM_ENTITIES' 
>
<Nodes>
    <Node
         Caption                              ='Заказчик'
         UID                                  ='1'
         form                                 ='PM.Forms.FormClients'
         EntityName                           ='SrRClientEntity'
         NameField                            ='NAME_SHORT_SRCL'
         KeyField                             ='ID_SR_R_CLIENT_SRCL'
         EnabledNodeStatuses                  ='ns_master_form'
         PrivilegSuffix                       ='default'
         multi_select                         ='true'
         DefRowNum                            ='1'
         DefColNum                            ='1'
         TableName                            ='PM_WORK_DATA.DBO.SR_R_CLIENT_SRCL'
       >
       <CustomFormButtons>
           <Button 
               Name          ='tb_ordinate_list'
               Title         ='Список координат'
               EnabledInEdit ='false'
               Image         ='list_coord'
               IsSplitter    ='False'
               PrevButton    ='sp_card'
           /> 
           <Button 
               Name          ='tb_ordinate_card'
               Title         ='Карточка координат'
               EnabledInEdit ='false'
               Image         ='Ordinatexyh'
               IsSplitter    ='False'
               PrevButton    ='tb_ordinate_list'
           /> 
       </CustomFormButtons>
    </Node>
    <Node
         Caption                              ='Проект'
         UID                                  ='2'
         EntityName                           ='SrRProjectEntity'
         NameField                            ='NAME_PROJ_SRPJ'
         KeyField                             ='ID_SR_R_PROJECT_SRPJ'
         EnabledNodeStatuses                  ='ns_detail_form'
         EnabledFilterTypes                   ='ft_show_data;ft_comboBox'
         PrivilegSuffix                       ='ALWAYS'
         TableName                            ='PM_WORK_DATA.DBO.SR_R_PROJECT_SRPJ'
       >
       <Masters>
           <Master
             ParentUID                            ='1'
             Condition                            ='SR_R_PROJECT_SRPJ.ID_SR_R_CLIENT_SRPJ in (:ID)'
             ChildKeyField                        ='ID_SR_R_CLIENT_SRPJ'
           /> 
       </Masters>
    </Node>
</Nodes>
</Task>", UID);
    } 
} 
