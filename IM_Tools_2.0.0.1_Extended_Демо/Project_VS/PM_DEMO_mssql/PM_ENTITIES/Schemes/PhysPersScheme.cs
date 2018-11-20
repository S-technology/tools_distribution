using IM.Hierarchy; 
using System; 
 
namespace IM.Hierarchy.Forms  
{ 
    /// <summary>
    /// Контактные лица
    /// </summary>
    public class PhysPers : IScheme 
    { 
        /// <summary>
        /// UID
        /// </summary>
        public static string UID = "PhysPers";
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
     Caption                              ='Физические лица'
     UID                                  ='{0}'
     NeedSaveConfig                       ='False'
     SchemeRadius                         ='240'
     MaxFiltersInRow                      ='2'
     HideFormButtons                      ='tb_period'
>
<Nodes>
    <Node
         Caption                              ='Физическое лицо'
         UID                                  ='1'
         EntityName                           ='SrPhysPersonEntity'
         NameField                            ='ID_SR_PHYS_PERSON_SRPP'
         KeyField                             ='ID_SR_PHYS_PERSON_SRPP'
         EnabledNodeStatuses                  ='ns_master_form'
         PrivilegViewName                     ='VIEW_SRPP'
         PrivilegEditName                     ='CHAN_SRPP'
         PrivilegInsertName                   ='BUILD_SRPP'
         PrivilegDeleteName                   ='DEL_SRPP'
         PrivilegCopyName                     ='COPY_SRPP'
         DefRowNum                            ='1'
         DefColNum                            ='1'
       >
    </Node>
</Nodes>
</Task>", UID);
    } 
} 
