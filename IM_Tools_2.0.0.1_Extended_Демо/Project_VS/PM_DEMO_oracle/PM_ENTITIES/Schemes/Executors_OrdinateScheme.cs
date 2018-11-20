using IM.Hierarchy; 
using System;

/*
 * 20.04.2016 ConstN fix 14281 У Node 'Исполнители' требуется карман. Добавлено MultiSelect ='true'
*/

namespace PM  
{ 
    /// <summary>
    /// Координаты физлиц
    /// </summary>
    public class ExecutorsOrdinate : IScheme 
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
     Caption                              ='Координаты исполнителей'
     UID                                  ='{0}'
     NeedSaveConfig                       ='False'
     MaxFiltersInRow                      ='2'
     HideFormButtons                      ='tb_period;tb_start_edit;tb_select_null;tb_commit;tb_rollback'
     SchemeAdapterName                    ='PM_ENTITIES.ClientsCoordAdapter,PM_ENTITIES'
>
<Nodes>
    <Node
         Caption                              ='Вид координат'
         UID                                  ='0'
         Value                                ='(COOR_PROEKT_FACT is null or COOR_PROEKT_FACT = &apos;Фактические&apos; or COOR_PROEKT_FACT = &apos;Проектные&apos;)'
         NameField                            ='Name_Field'
         KeyField                             ='ID_Field'
         EnabledFilterTypes                   ='ft_comboBox'
         DefRowNum                            ='2'
         DefColNum                            ='1'
       >
       <CustomTableColumns>
           <Column
             Name                                 ='ID_Field'
             RusName                              ='Код'
             Visible                              ='False'
             ReadOnly                             ='True'
             DefaultWidth                         ='30'
             NppInResult                          ='0'
           /> 
           <Column
             Name                                 ='Name_Field'
             RusName                              ='Условие/значение'
             ReadOnly                             ='True'
             DefaultWidth                         ='400'
             NppInResult                          ='0'
           /> 

       </CustomTableColumns>
       <CustomTableRows>
           <Row
               cell_0         ='(COOR_PROEKT_FACT is null or COOR_PROEKT_FACT = &apos;Фактические&apos; or COOR_PROEKT_FACT = &apos;Проектные&apos;)'
               cell_1         ='Все'
           /> 
           <Row
               cell_0         ='(COOR_PROEKT_FACT = &apos;Фактические&apos; or COOR_PROEKT_FACT_F = &apos;Фактические&apos;)'
               cell_1         ='Фактические'
           /> 
           <Row
               cell_0         ='(COOR_PROEKT_FACT = &apos;Проектные&apos;)'
               cell_1         ='Проектные'
           /> 
       </CustomTableRows>
    </Node>
    <Node
         Caption                              ='Исполнители'
         UID                                  ='1'
         FormName                             ='IM.Maps.Forms.fm_UnOrdinatexyhList,IM.Maps'
         EntityName                           ='SrRExecutiveEntity'
         NameField                            ='FIO_SREX'
         KeyField                             ='ID_SR_R_EXECUTIVE_SREX'
         EnabledNodeStatuses                  ='ns_master_form'
         PrivilegViewName                     ='VIEW_SREX_OXYH'
         PrivilegEditName                     ='CHAN_SREX_OXYH'
         PrivilegInsertName                   ='BUILD_SREX_OXYH'
         PrivilegDeleteName                   ='DEL_SREX_OXYH'
         PrivilegCopyName                     ='COPY_SREX_OXYH'
         MultiSelect                          ='true'
         DefRowNum                            ='1'
         DefColNum                            ='1'
         HideFormButtons                      ='tb_period;tb_card;tb_copy;tb_delete;tb_clear;tb_undo;tb_add;tb_add_by_card;tb_commit;tb_rollback'
         SelectionName                        ='UN_ORDINATE_List'
       >
       <Masters>
           <Master
             ParentUID                            ='0'
             Condition                            =':ID'
           /> 
           <Master
             ParentUID                            ='system_coord'
             ColumnsToShow                        ='CNV_NAME;CNV_X;CNV_Y;CNV_X_F;CNV_Y_F'
           /> 
       </Masters>
    </Node>
    <Node
         Caption                              ='Система координат расчетная'
         UID                                  ='system_coord'
         EntityName                           ='TinuCoordinateStmcEntity'
         NameField                            ='NAME_FULL_STMC'
         KeyField                             ='ID_COORDINATE_STMC'
         EnabledFilterTypes                   ='ft_show_data;ft_comboBox'
         PrivilegSuffix                       ='always'
         PrivilegViewName                     ='VIEW_always'
         PrivilegEditName                     ='CHAN_always'
         PrivilegInsertName                   ='BUILD_always'
         PrivilegDeleteName                   ='DEL_always'
         PrivilegCopyName                     ='COPY_always'
         DefRowNum                            ='2'
         DefColNum                            ='2'
         TableName                            ='PM_WORK_DATA.DBO.COORDINATE_STMC'
       >
    </Node>
</Nodes>
</Task>", UID);
    } 
} 
