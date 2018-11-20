using IM.Hierarchy; 
using System; 
 
namespace IM.Hierarchy.Forms  
{ 
    /// <summary>
    /// Исполнители
    /// </summary>
    public class Executors : IScheme 
    { 
        /// <summary>
        /// UID
        /// </summary>
        public static string UID = "Executors";
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
     Caption                              ='Исполнители'
     UID                                  ='{0}'
     NeedSaveConfig                       ='False'
     SchemeRadius                         ='240'
     MaxFiltersInRow                      ='2'
     HideFormButtons                      ='tb_period'
     SchemeAdapterName                    ='PM_ENTITIES.ClientsAdapter,PM_ENTITIES'
>
<Nodes>
    <Node
         Caption                              ='Исполнитель'
         UID                                  ='1'
         form                                 ='PM.Forms.FormExecutors'
         EntityName                           ='SrRExecutiveEntity'
         NameField                            ='FIO_SREX'
         KeyField                             ='ID_SR_R_EXECUTIVE_SREX'
         EnabledNodeStatuses                  ='ns_master_form'
         PrivilegSuffix                       ='default'
         multi_select                         ='true'
         DefRowNum                            ='1'
         DefColNum                            ='1'
         TableName                            ='PM_WORK_DATA.DBO.SR_R_CLIENT_SRCL'
       >
       <CustomFormButtons>
           <Button
               Name         ='tb_ordinate_list'
               Title        ='Список координат'
               Image        ='list_coord'
               EnabledInEdit='False'
               IsSplitter   ='False'
               PrevButton   ='sp_card'
           /> 
           <Button
               Name         ='tb_ordinate_card'
               Title        ='Карточка координат'
               Image        ='Ordinatexyh'
               EnabledInEdit='False'
               IsSplitter   ='False'
               PrevButton   ='tb_ordinate_list'
           /> 
       </CustomFormButtons>
    </Node>
</Nodes>
</Task>", UID);
    } 
} 
