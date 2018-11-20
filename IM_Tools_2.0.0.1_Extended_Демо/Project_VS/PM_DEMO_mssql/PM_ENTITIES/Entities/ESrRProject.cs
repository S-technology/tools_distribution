/********************************************************************************/
/*                                                                              */
/*Copyright (c) 1999,2011   Information & Management Ltd.                       */
/*                                                                              */
/*   Модуль таблицы PM_OTLADKA_DATA.DBO.SR_R_PROJECT_SRPJ                       */
/*                                                                              */
/*   NAME  ESrRProject.cs    SCOPE    ....                                      */
/*                                                                              */
/*   DESCRIPTION                                                                */
/*     Проект                                                                   */
/*                                                                              */
/*   AUTHOR                                                                     */
/*                                                                              */
/********************************************************************************/

/*
    17.03.2011  Automatic  Первоначальная редакция
                                                                               */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using S_;
using IM.Hierarchy;
using IM.Functions;
using System.Reflection;

namespace PM.Entity
{

    //s_DataObject.Register(typeof(SrRProjectData));
    //s_EntityObject.Register(typeof(SrRProjectEntity));

    public class SrRProjectData : GraphDataObject
    {
        protected override void GetSQL()
        {
            SelectClause.Add("select " + ClassInfo.TableAlias + ".* ");

            SelectClause.Add(", (select FIO_SREX from " + "SR_R_EXECUTIVE_SREX".ToFullObjectName(s_DatabaseObjectType.Table) + " where ID_SR_R_EXECUTIVE_SREX = ");
            SelectClause.Add(" (select ID_SR_R_EXECUTIVE_SRPP from " + "SR_PHYS_PERSON_SRPP".ToFullObjectName(s_DatabaseObjectType.Table) + " where ID_SR_PHYS_PERSON_SRPP = " + ClassInfo.TableAlias + ".ID_SR_PHYS_PERSON_SRPJ)) as ID_SR_PHYS_PERSON_FIO");
            //
            FromClause.Add("from " + TableName + " " + ClassInfo.TableAlias);
            //OrderByClause.Add(" " + ClassInfo.TableAlias + ".ID_SR_R_PROJECT_SRPJ ");
        }

        #region конструкторы
        public SrRProjectData() : this("Default") { }
        public SrRProjectData(string pSelectionName)
            : base(pSelectionName)
        {
            Sort = "NAME_PROJ_SRPJ";
            //UserOrderByClause = "NAME_PROJ_SRPJ";
        }
        #endregion

        #region актуализация типа ссылки на класс-сущность
        public new SrRProjectEntity Entity
        {
            [DebuggerStepThrough]
            get
            {
                return (SrRProjectEntity)base.Entity;
            }
        }
        #endregion

        public static string GetXml()
        {
            return
            "<Class\r\n" +
            "       TableName='%PROJECTSCHEMA%.SR_R_PROJECT_SRPJ'\r\n" +
            "       TableAlias='SR_R_PROJECT_SRPJ'\r\n" +
            "       UseForRef='TRUE'\r\n" +
            "       DefaultCaption='СЗ_С_ПРОЕКТ'\r\n" +
            "       FormulaName='СЗ_С_ПРОЕКТ'\r\n" +
            "       Sequence='SEQ_SR_R_PROJECT_SRPJ'\r\n" +
            "       DefaultEntityClass='SrRProjectEntity'\r\n" +
            "       LookupKeyFields='Default'\r\n" +
            "       LookupResultField='Default' \r\n" +
            ">\r\n" +

            "  <Selections>\r\n" +
            "    <Selection Name='Default'\r\n" +
            "                  DefaultCaption=''\r\n" +
            "                  IsList='True'\r\n" +
            "    />\r\n" +
            "    <Selection Name='FullList'\r\n" +
            "                  DefaultCaption=''\r\n" +
            "                  IsList='True'\r\n" +
            "    />\r\n" +
            "    <Selection Name='ById'\r\n" +
            "                  DefaultCaption='По Id'\r\n" +
            "                  Params='@IPID_SR_R_PROJECT_SRPJ'\r\n" +
            "    >\r\n" +
            "      <Conditions>\r\n" +
            "        <Condition>ID_SR_R_PROJECT_SRPJ=:PID_SR_R_PROJECT_SRPJ</Condition>\r\n" +
            "      </Conditions>\r\n" +
            "    </Selection>\r\n" +
            "  </Selections>\r\n" +
            "  <Attributes>\r\n" +
            "    <Attribute Name='ID_SR_R_PROJECT_SRPJ'\r\n" +
            "             RusName='ID_Проект'\r\n" +
            "             FormulaName='ID_ПРОЕКТ'\r\n" +
            "             ReadOnly='true'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='NAME_PROJ_SRPJ'\r\n" +
            "             RusName='Наименование проекта'\r\n" +
            "             FormulaName='НАИМЕНОВАНИЕ_ПРОЕКТА'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='DESCRIPTION_SRPJ'\r\n" +
            "             RusName='Описание проекта'\r\n" +
            "             FormulaName='ОПИСАНИЕ_ПРОЕКТА'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='ID_SR_R_CLIENT_SRPJ'\r\n" +
            "             RusName='ID Заказчик проекта'\r\n" +
            "             FormulaName='ID_ЗАКАЗЧИК_ПРОЕКТА'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='ID_SR_PHYS_PERSON_SRPJ'\r\n" +
            "             RusName='ID Контактное лицо'\r\n" +
            "             FormulaName='ID_КОНТАКТНОЕ_ЛИЦО'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='ID_SR_PHYS_PERSON_FIO'\r\n" +
            "             RusName='Контактное лицо ФИО'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='VVOD_ID_CONTRACTOR_SRPJ'\r\n" +
            "             RusName='Автор ввода'\r\n" +
            "             FormulaName='АВТОР_ВВОДА'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='CHANGE_ID_CONTRACTOR_SRPJ'\r\n" +
            "             RusName='Автор изменения'\r\n" +
            "             FormulaName='АВТОР_ИЗМЕНЕНИЯ'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='DATE_INPUT_SRPJ'\r\n" +
            "             RusName='Дата ввода'\r\n" +
            "             FormulaName='ДАТА_ВВОДА'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "             DataType='DateTime'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='DATE_CHANGE_SRPJ'\r\n" +
            "             RusName='Дата изменения'\r\n" +
            "             FormulaName='ДАТА_ИЗМЕНЕНИЯ'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "             DataType='DateTime'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='ID_SR_R_CLIENT_NAME'\r\n" +
            "             Type='Lookup'\r\n" +
            "             UseIn='Default;FullList;ById'\r\n" +
            "             ClassName='SrRClientData'\r\n" +
            "             KeyField='ID_SR_R_CLIENT_SRPJ'\r\n" +
            "             RusName='Заказчик'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='ID_SR_PHYS_PERSON_NAME'\r\n" +
            "             Type='Lookup'\r\n" +
            "             UseIn='Default;FullList;ById'\r\n" +
            "             ClassName='SrPhysPersonData'\r\n" +
            "             KeyField='ID_SR_PHYS_PERSON_SRPJ'\r\n" +
            "             RusName='Контактное лицо'\r\n" +
            "    />\r\n" +
            //"    <Attribute Name='ID_SR_PHYS_PERSON_FIO'\r\n" +
            //"             Type='Lookup'\r\n" +
            //"             Far='True'\r\n" +
            //"             UseIn='Default;FullList;ById'\r\n" +
            //"             ClassName='SrRExecutiveData'\r\n" +
            //"             KeyField='ID_SR_PHYS_PERSON_SRPJ'\r\n" +
            //"             RusName='Контактное лицо ФИО'\r\n" +
            //"    />\r\n" +
            "  </Attributes>\r\n" +
            "  <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20110317' />\r\n" +
            "  <Comment>..</Comment>\r\n" +
            "</Class>"
            ;
        }//GetXML

        #region атрибуты выборки
        //  ( в первоначальной редакции не учтены вычисляемые атрибуты. Их можно добавить вручную)
        private s_DataColumn _attrIdSrRProject;
        public s_DataColumn AttrIdSrRProject
        {
            get
            {
                if (_attrIdSrRProject == null)
                    _attrIdSrRProject = Attributes[SrRProjectEntity.ColumnIdSrRProject];
                return _attrIdSrRProject;
            }
        }
        private s_DataColumn _attrNameProj;
        public s_DataColumn AttrNameProj
        {
            get
            {
                if (_attrNameProj == null)
                    _attrNameProj = Attributes[SrRProjectEntity.ColumnNameProj];
                return _attrNameProj;
            }
        }
        private s_DataColumn _attrDescription;
        public s_DataColumn AttrDescription
        {
            get
            {
                if (_attrDescription == null)
                    _attrDescription = Attributes[SrRProjectEntity.ColumnDescription];
                return _attrDescription;
            }
        }
        private s_DataColumn _attrVvodIdContractor;
        public s_DataColumn AttrVvodIdContractor
        {
            get
            {
                if (_attrVvodIdContractor == null)
                    _attrVvodIdContractor = Attributes[SrRProjectEntity.ColumnVvodIdContractor];
                return _attrVvodIdContractor;
            }
        }
        private s_DataColumn _attrChangeIdContractor;
        public s_DataColumn AttrChangeIdContractor
        {
            get
            {
                if (_attrChangeIdContractor == null)
                    _attrChangeIdContractor = Attributes[SrRProjectEntity.ColumnChangeIdContractor];
                return _attrChangeIdContractor;
            }
        }
        private s_DataColumn _attrDateInput;
        public s_DataColumn AttrDateInput
        {
            get
            {
                if (_attrDateInput == null)
                    _attrDateInput = Attributes[SrRProjectEntity.ColumnDateInput];
                return _attrDateInput;
            }
        }
        private s_DataColumn _attrDateChange;
        public s_DataColumn AttrDateChange
        {
            get
            {
                if (_attrDateChange == null)
                    _attrDateChange = Attributes[SrRProjectEntity.ColumnDateChange];
                return _attrDateChange;
            }
        }
        #endregion

        #region методы для взаимодействия с ObjectDataSource (WebForms)
        public void InsertInstance(SrRProjectEntityInstance instance)
        {
        }
        public void DeleteInstance(SrRProjectEntityInstance instance)
        {
        }
        public void UpdateInstance(SrRProjectEntityInstance instance)
        {
        }
        #endregion

    }

    public class SrRProjectEntityInstance : s_EntityInstance
    {
        #region конструкторы
        public SrRProjectEntityInstance() : this(null) { }
        public SrRProjectEntityInstance(DataRow row) : base(row) { }
        #endregion

        #region актуализация типов ссылок на класс-сущность и дата-класс
        public new SrRProjectEntity Entity
        {
            [DebuggerStepThrough]
            get
            {
                return (SrRProjectEntity)base.Entity;
            }
        }

        public new SrRProjectData Data
        {
            [DebuggerStepThrough]
            get
            {
                return (SrRProjectData)base.Data;
            }
        }
        #endregion

        #region свойства для доступа к значениям атрибутов выборки
        /*
     В первоначальной редакции:
       1. Необходимо проверить корректность определения типов свойств
       2. Не учтены:
            - вычисляемые атрибуты;
            - include-атрибуты, включаемые в текст запроса на выборку по описаниям lookup-атрибутов.
          Свойства для доступа к ним надо добавить вручную.

     Ссылка на атрибут возможна через любое из двух свойств:  
       1. Свойство c форматом имени в виде <AttributeName> обычно используется для доступа к атрибуту в программном коде.
       2. Свойство c форматом имени в виде <ATTRIBUTE_NAME> используется объектом класса ObjectdataSource при Web-доступе.
     Эти ссылки эквивалентны
*/
        private Int32? _idSrRProject;
        public Int32? IdSrRProject
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrIdSrRProject[Row] as Int32?;
                else
                    return _idSrRProject;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrIdSrRProject[Row] = value;
                else
                    _idSrRProject = value;
            }
        }
        public Int32? ID_SR_R_PROJECT_SRPJ
        { //Web-доступ
            [DebuggerStepThrough]
            get { return IdSrRProject; }
            [DebuggerStepThrough]
            set { IdSrRProject = value; }
        }

        private String _nameProj;
        public String NameProj
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrNameProj[Row] as String;
                else
                    return _nameProj;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrNameProj[Row] = value;
                else
                    _nameProj = value;
            }
        }
        public String NAME_PROJ_SRPJ
        { //Web-доступ
            [DebuggerStepThrough]
            get { return NameProj; }
            [DebuggerStepThrough]
            set { NameProj = value; }
        }

        private String _description;
        public String Description
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrDescription[Row] as String;
                else
                    return _description;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrDescription[Row] = value;
                else
                    _description = value;
            }
        }
        public String DESCRIPTION_SRPJ
        { //Web-доступ
            [DebuggerStepThrough]
            get { return Description; }
            [DebuggerStepThrough]
            set { Description = value; }
        }

        private String _vvodIdContractor;
        public String VvodIdContractor
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrVvodIdContractor[Row] as String;
                else
                    return _vvodIdContractor;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrVvodIdContractor[Row] = value;
                else
                    _vvodIdContractor = value;
            }
        }
        public String VVOD_ID_CONTRACTOR_SRPJ
        { //Web-доступ
            [DebuggerStepThrough]
            get { return VvodIdContractor; }
            [DebuggerStepThrough]
            set { VvodIdContractor = value; }
        }

        private String _changeIdContractor;
        public String ChangeIdContractor
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrChangeIdContractor[Row] as String;
                else
                    return _changeIdContractor;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrChangeIdContractor[Row] = value;
                else
                    _changeIdContractor = value;
            }
        }
        public String CHANGE_ID_CONTRACTOR_SRPJ
        { //Web-доступ
            [DebuggerStepThrough]
            get { return ChangeIdContractor; }
            [DebuggerStepThrough]
            set { ChangeIdContractor = value; }
        }

        private DateTime? _dateInput;
        public DateTime? DateInput
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrDateInput[Row] as DateTime?;
                else
                    return _dateInput;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrDateInput[Row] = value;
                else
                    _dateInput = value;
            }
        }
        public DateTime? DATE_INPUT_SRPJ
        { //Web-доступ
            [DebuggerStepThrough]
            get { return DateInput; }
            [DebuggerStepThrough]
            set { DateInput = value; }
        }

        private DateTime? _dateChange;
        public DateTime? DateChange
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrDateChange[Row] as DateTime?;
                else
                    return _dateChange;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrDateChange[Row] = value;
                else
                    _dateChange = value;
            }
        }
        public DateTime? DATE_CHANGE_SRPJ
        { //Web-доступ
            [DebuggerStepThrough]
            get { return DateChange; }
            [DebuggerStepThrough]
            set { DateChange = value; }
        }

        //     Шаблон для добавления свойства вручную:
        /*
            private <type> _propertyName;
            public  <type> PropertyName {
              [DebuggerStepThrough]get {
                if (Row != null)
                  return Data.AttrPropertyName[Row] as <type>;
                else
                  return _propertyName;
              }
              [DebuggerStepThrough]set {
                if (Row != null)
                  Data.AttrPropertyName[Row] = value;
                else
                  _propertyName = value;
              }
            }
            public <type> ATTRIBUTE_NAME { //Web-доступ
              [DebuggerStepThrough]get { return PropertyName;}
              [DebuggerStepThrough]set { PropertyName = value;}
            }
        /**/

        #endregion
    }

    public class SrRProjectEntity : GraphEntity, IEnumerable<SrRProjectEntityInstance>
    {

        #region проход по строкам выборки дата-класса
        public IEnumerator<SrRProjectEntityInstance> GetEnumerator()
        {
            if (Data.Active)
            {
                SrRProjectEntityInstance el;
                DataRowCollection __rows = Data.Table.Rows;
                foreach (DataRow row in __rows)
                {
                    el = new SrRProjectEntityInstance(row);
                    yield return el;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        #endregion

        #region конструкторы
        public SrRProjectEntity() : this(s_DbConnection.CurrentConnectionName) { }
        public SrRProjectEntity(string pConnectionName) : base(pConnectionName) { }
        #endregion

        #region xml-схема класса
        public static string GetXml()
        {
            return
            "<Class\r\n" +
            "       DefaultCaption='СЗ_С_ПРОЕКТ'\r\n" +
            "       DefaultDataClass='SrRProjectData'\r\n" +
            "       InstanceClass='SrRProjectEntityInstance'\r\n" +
                //      "       ReadOnly='true'\r\n" +
            "       PrivilegeRead='Default'\r\n" +
            "       PrivilegeWrite='Default'\r\n" +
            ">\r\n" +

            "  <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20110317' />\r\n" +
            "  <Comment>. . .</Comment>\r\n" +
            "</Class>"
          ;
        }//GetXML
        #endregion

        #region встроенный объект SrRProjectEntityInstance
        //Создается при первом обращении
        private SrRProjectEntityInstance _entityInstance;
        public SrRProjectEntityInstance Instance
        {
            get
            {
                if (_entityInstance == null)
                    _entityInstance = new SrRProjectEntityInstance();
                return _entityInstance;
            }
        }
        #endregion

        #region константы
        static readonly public string TableName = "SR_R_PROJECT_SRPJ".ToFullObjectName(s_DatabaseObjectType.Table);
        // Имена атрибутов (колонок выборки)
        //  (в первоначальной редакции не учтены вычисляемые атрибуты. Их можно добавить вручную)
        static readonly public string ColumnIdSrRProject = "ID_SR_R_PROJECT_SRPJ";
        static readonly public string ColumnNameProj = "NAME_PROJ_SRPJ";
        static readonly public string ColumnDescription = "DESCRIPTION_SRPJ";
        static readonly public string ColumnVvodIdContractor = "VVOD_ID_CONTRACTOR_SRPJ";
        static readonly public string ColumnChangeIdContractor = "CHANGE_ID_CONTRACTOR_SRPJ";
        static readonly public string ColumnDateInput = "DATE_INPUT_SRPJ";
        static readonly public string ColumnDateChange = "DATE_CHANGE_SRPJ";

        static readonly public string ColumnID_SR_R_CLIENT_SRPJ = "ID_SR_R_CLIENT_SRPJ";
        static readonly public string ColumnID_SR_PHYS_PERSON_SRPJ = "ID_SR_PHYS_PERSON_SRPJ";
        static readonly public string ColumnID_SR_R_CLIENT_NAME = "ID_SR_R_CLIENT_NAME";
        static readonly public string ColumnID_SR_PHYS_PERSON_NAME = "ID_SR_PHYS_PERSON_NAME";
        static readonly public string ColumnID_SR_PHYS_PERSON_FIO = "ID_SR_PHYS_PERSON_FIO";

        #endregion

        #region заготовки для перекрытия методов
        /*Для использования в списках методов GetReadOnlyColumns, GetGridColumns:
          ColumnIdSrRProject
        + ";" + ColumnNameProj
        + ";" + ColumnDescription
        + ";" + ColumnVvodIdContractor
        + ";" + ColumnChangeIdContractor
        + ";" + ColumnDateInput
        + ";" + ColumnDateChange
        */
        #endregion

        public override void ShowData(object options)
        {
            s_EntityShowingEventArgs __e = new s_EntityShowingEventArgs();
            __e.Options = options;
            OnShowing(__e);
            if (__e.Cancel) return;

            s_NamedObjects locList;
            s_ShowDataOptions sOpt = options as s_ShowDataOptions;
            s_ViewOption opt = sOpt != null ? ((s_ViewOption)(sOpt.ViewOptions)) : s_ViewOption.None;
            locList = sOpt != null ? sOpt.Locate : null;

            ChangeShowDataViewOption(ref opt);

            s_NamedObjects pars = null;
            S_.WindowsForms.s_ShowDataOptionsWinForm s_wf_opt = sOpt as S_.WindowsForms.s_ShowDataOptionsWinForm;
            if (s_wf_opt != null && s_wf_opt.UserParam is s_NamedObjects)
            {
                pars = (s_NamedObjects)s_wf_opt.UserParam;
            }
            else
            {
                pars = new s_NamedObjects();
            }

            for (int i = 0; i < ShowDataParams.Count; i++)
            {
                pars[ShowDataParams.Names[i]] = ShowDataParams[i];
            }

            bool selecting = false;
            if (opt != s_ViewOption.None)
            {
                if (opt.ContainsOption(s_ViewOption.Select))
                {
                    pars[Const.par_type_select] = TypeOfSelection.One;
                    selecting = true;
                }
                if (opt.ContainsOption(s_ViewOption.MultiSelect))
                {
                    pars[Const.par_type_select] = TypeOfSelection.Multi;
                    selecting = true;
                }
            }

            if (!Data.SelectionName.SameStr("Default"))
            {
                Data.Caption = Data.ClassInfo.Selections[Data.SelectionName].DefaultCaption;
            }

            pars[Const.par_outer_entity] = this;

            object frm = null;
            Type type = null;

            if (type == null)
            {
                type = Type.GetType("IM.Hierarchy.Forms.FormLow, IM.HierarchyForms", false, true);
            }

            // по типу создает экземпляр объекта
            if (type != null)
            {
                frm = Activator.CreateInstance(type);
            }

            if (frm != null)
            {
                MethodInfo mi = type.GetMethod("Execute", new[] { typeof(Object) });
                if (mi != null)
                {
                    pars[Const.par_form_ClassName] = "PM.Forms.FormProjects,PM";
                    pars[Const.par_caption] = "Проекты";

                    string hidingButtons = "";
                    // наверное, нужно обработать ViewOptions(которые правятся чуть выше), но пока в лоб
                    if (_disableOptions)
                    {
                        hidingButtons += "tb_card;tb_add_by_card;tb_start_edit;tb_add;tb_delete;tb_insert;tb_force_delete;tb_copy_by_card";
                    }
                    else
                    {
                    }

                    if (!hidingButtons.IsEmpty())
                    {
                        pars[Const.par_hide_buttons] = hidingButtons;
                    }

                    object selID;
                    if (pars.TryGetValue(Const.par_current_selection, out selID) && !selID.ObjToStr().IsEmpty())
                    {
                        //string val = sel_ID.obj_to_str();
                    }
                    else if (locList != null && locList.Count > 0 && Data.PrimaryKey.Count > 0 && !Data.PrimaryKey[0].IsEmpty())
                    {
                        string idRec = "";
                        string currVal;
                        for (int i = 0; i < Data.PrimaryKey.Count; i++)
                        {
                            currVal = locList[Data.PrimaryKey[i]].ObjToStr();
                            idRec += currVal + ";";
                        }
                        Func.CutLastItem(ref idRec, 1);

                        if (!idRec.IsEmpty())
                        {
                            pars[Const.par_current_selection] = idRec;
                        }
                    }

                    if (selecting)
                    {
                        ClearWFSelectionList();
                        GraphSelectionListInternal.SelectionDone = false;
                    }

                    mi.Invoke(null, new object[] { pars });
                }
            }
            OnShowned(EventArgs.Empty);
        }
    }
}