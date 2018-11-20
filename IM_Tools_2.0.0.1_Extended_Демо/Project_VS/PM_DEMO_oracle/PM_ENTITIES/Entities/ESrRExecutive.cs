/********************************************************************************/
/*                                                                              */
/*Copyright (c) 1999,2011   Information & Management Ltd.                       */
/*                                                                              */
/*   Модуль таблицы PM_OTLADKA_DATA.DBO.SR_R_EXECUTIVE_SREX                     */
/*                                                                              */
/*   NAME  ESrRExecutive.cs    SCOPE    ....                                    */
/*                                                                              */
/*   DESCRIPTION                                                                */
/*     Исполнитель                                                              */
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
using IM.Functions;
using S_;
using IM.Hierarchy;
using IM.Maps.Entity;
using IM.Maps.SERVICECLASSES;
using IM.Hierarchy.Forms;

namespace PM.Entity
{

    //s_DataObject.Register(typeof(SrRExecutiveData));
    //s_EntityObject.Register(typeof(SrRExecutiveEntity));

    public class SrRExecutiveData : GraphDataObject
    {
        protected override void GetSQL()
        {
            SelectClause.Add("select " + ClassInfo.TableAlias + ".* ");
            FromClause.Add("from " + TableName + " " + ClassInfo.TableAlias);
            if (SelectionName.SameStr("UN_ORDINATE_List") || SelectionName.SameStr("UN_ORDINATE_ONE_RECORD"))
            {
                SelectClause.Add(TUnOrdinatexyhUoxyEntity.CreateSelectTextSELECT(this));
                FromClause.Add(TUnOrdinatexyhUoxyEntity.CreateSelectText(this));
            }
        }

        #region конструкторы
        public SrRExecutiveData() : this("Default") { }
        public SrRExecutiveData(string pSelectionName)
            : base(pSelectionName)
        {
            if (SelectionName.SameStr("UN_ORDINATE_List") || SelectionName.SameStr("UN_ORDINATE_ONE_RECORD"))
            {
                TUnOrdinatexyhUoxyEntity.SetTitleForCoorFields(this);
            }
            Sort = "NUMBER_PP_SREX";
        }
        #endregion

        #region актуализация типа ссылки на класс-сущность
        public new SrRExecutiveEntity Entity
        {
            [DebuggerStepThrough]
            get
            {
                return (SrRExecutiveEntity)base.Entity;
            }
        }
        #endregion

        public static string GetXml()
        {
            return
            "<Class\r\n" +
            "       TableName='%PROJECTSCHEMA%.SR_R_EXECUTIVE_SREX'\r\n" +
            "       TableAlias='SR_R_EXECUTIVE_SREX'\r\n" +
            "       UseForRef='TRUE'\r\n" +
            "       DefaultCaption='СЗ_С_ИСПОЛНИТЕЛЬ'\r\n" +
            "       FormulaName='СЗ_С_ИСПОЛНИТЕЛЬ'\r\n" +
            "       Sequence='SEQ_SR_R_EXECUTIVE_SREX'\r\n" +
            "       DefaultEntityClass='SrRExecutiveEntity'\r\n" +
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
            "    <Selection Name='UN_ORDINATE_List'\r\n" +
            "                  DefaultCaption=''\r\n" +
            "                  IsList='True'\r\n" +
            "    />\r\n" +
            "    <Selection Name='UN_ORDINATE_ONE_RECORD'\r\n" +
            "                  DefaultCaption=''\r\n" +
            "                  IsList='True'\r\n" +
            "    />\r\n" +
            "    <Selection Name='ById'\r\n" +
            "                  DefaultCaption='По Id'\r\n" +
            "                  Params='@IPID_SR_R_EXECUTIVE_SREX'\r\n" +
            "    >\r\n" +
            "      <Conditions>\r\n" +
            "        <Condition>ID_SR_R_EXECUTIVE_SREX=:PID_SR_R_EXECUTIVE_SREX</Condition>\r\n" +
            "      </Conditions>\r\n" +
            "    </Selection>\r\n" +
            "    <Selection Name='ByLogin'\r\n" +
            "                  DefaultCaption='По Login'\r\n" +
            "                  Params='@SLogin'\r\n" +
            "    >\r\n" +
            "      <Conditions>\r\n" +
            "        <Condition>LOGIN_SREX=:Login</Condition>\r\n" +
            "      </Conditions>\r\n" +
            "    </Selection>\r\n" +
            "  </Selections>\r\n" +
            "  <Attributes>\r\n" +
            "    <Attribute Name='ID_SR_R_EXECUTIVE_SREX'\r\n" +
            "             RusName='ID_Исполнитель'\r\n" +
            "             FormulaName='ID_ИСПОЛНИТЕЛЬ'\r\n" +
            "             ReadOnly='true'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='NUMBER_PP_SREX'\r\n" +
            "             RusName='№ п/п'\r\n" +
            "             FormulaName='№_П_П'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='FIO_SREX'\r\n" +
            "             RusName='ФИО'\r\n" +
            "             FormulaName='ФИО'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='LOGIN_SREX'\r\n" +
            "             RusName='Логин'\r\n" +
            "             FormulaName='ЛОГИН'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='LOGIN_IN_CHAT_SREX'\r\n" +
            "             RusName='Логин в рабочем чате'\r\n" +
            "             FormulaName='ЛОГИН_В_РАБОЧЕМ_ЧАТЕ'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='VVOD_ID_CONTRACTOR_SREX'\r\n" +
            "             RusName='Автор ввода'\r\n" +
            "             FormulaName='АВТОР_ВВОДА'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='CHANGE_ID_CONTRACTOR_SREX'\r\n" +
            "             RusName='Автор изменения'\r\n" +
            "             FormulaName='АВТОР_ИЗМЕНЕНИЯ'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='DATE_INPUT_SREX'\r\n" +
            "             RusName='Дата ввода'\r\n" +
            "             FormulaName='ДАТА_ВВОДА'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "             DataType='DateTime'\r\n" +
            "    />\r\n" +
            "    <Attribute Name='DATE_CHANGE_SREX'\r\n" +
            "             RusName='Дата изменения'\r\n" +
            "             FormulaName='ДАТА_ИЗМЕНЕНИЯ'\r\n" +
            "             DisableUserEdit='true'\r\n" +
            "             DataType='DateTime'\r\n" +
            "    />\r\n" +
            "  </Attributes>\r\n" +
            "  <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20110317' />\r\n" +
            "  <Comment>..</Comment>\r\n" +
            "</Class>"
            ;
        }//GetXML

        #region атрибуты выборки
        //  ( в первоначальной редакции не учтены вычисляемые атрибуты. Их можно добавить вручную)
        private s_DataColumn _attrIdSrRExecutive;
        public s_DataColumn AttrIdSrRExecutive
        {
            get
            {
                if (_attrIdSrRExecutive == null)
                    _attrIdSrRExecutive = Attributes[SrRExecutiveEntity.ColumnIdSrRExecutive];
                return _attrIdSrRExecutive;
            }
        }
        private s_DataColumn _attrNumberPp;
        public s_DataColumn AttrNumberPp
        {
            get
            {
                if (_attrNumberPp == null)
                    _attrNumberPp = Attributes[SrRExecutiveEntity.ColumnNumberPp];
                return _attrNumberPp;
            }
        }
        private s_DataColumn _attrFio;
        public s_DataColumn AttrFio
        {
            get
            {
                if (_attrFio == null)
                    _attrFio = Attributes[SrRExecutiveEntity.ColumnFio];
                return _attrFio;
            }
        }
        private s_DataColumn _attrLogin;
        public s_DataColumn AttrLogin
        {
            get
            {
                if (_attrLogin == null)
                    _attrLogin = Attributes[SrRExecutiveEntity.ColumnLogin];
                return _attrLogin;
            }
        }
        private s_DataColumn _attrVvodIdContractor;
        public s_DataColumn AttrVvodIdContractor
        {
            get
            {
                if (_attrVvodIdContractor == null)
                    _attrVvodIdContractor = Attributes[SrRExecutiveEntity.ColumnVvodIdContractor];
                return _attrVvodIdContractor;
            }
        }
        private s_DataColumn _attrChangeIdContractor;
        public s_DataColumn AttrChangeIdContractor
        {
            get
            {
                if (_attrChangeIdContractor == null)
                    _attrChangeIdContractor = Attributes[SrRExecutiveEntity.ColumnChangeIdContractor];
                return _attrChangeIdContractor;
            }
        }
        private s_DataColumn _attrDateInput;
        public s_DataColumn AttrDateInput
        {
            get
            {
                if (_attrDateInput == null)
                    _attrDateInput = Attributes[SrRExecutiveEntity.ColumnDateInput];
                return _attrDateInput;
            }
        }
        private s_DataColumn _attrDateChange;
        public s_DataColumn AttrDateChange
        {
            get
            {
                if (_attrDateChange == null)
                    _attrDateChange = Attributes[SrRExecutiveEntity.ColumnDateChange];
                return _attrDateChange;
            }
        }
        #endregion

        #region методы для взаимодействия с ObjectDataSource (WebForms)
        public void InsertInstance(SrRExecutiveEntityInstance instance)
        {
        }
        public void DeleteInstance(SrRExecutiveEntityInstance instance)
        {
        }
        public void UpdateInstance(SrRExecutiveEntityInstance instance)
        {
        }
        #endregion

    }

    public class SrRExecutiveEntityInstance : s_EntityInstance
    {
        #region конструкторы
        public SrRExecutiveEntityInstance() : this(null) { }
        public SrRExecutiveEntityInstance(DataRow row) : base(row) { }
        #endregion

        #region актуализация типов ссылок на класс-сущность и дата-класс
        public new SrRExecutiveEntity Entity
        {
            [DebuggerStepThrough]
            get
            {
                return (SrRExecutiveEntity)base.Entity;
            }
        }

        public new SrRExecutiveData Data
        {
            [DebuggerStepThrough]
            get
            {
                return (SrRExecutiveData)base.Data;
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
        private Int32? _idSrRExecutive;
        public Int32? IdSrRExecutive
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrIdSrRExecutive[Row] as Int32?;
                else
                    return _idSrRExecutive;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrIdSrRExecutive[Row] = value;
                else
                    _idSrRExecutive = value;
            }
        }
        public Int32? ID_SR_R_EXECUTIVE_SREX
        { //Web-доступ
            [DebuggerStepThrough]
            get { return IdSrRExecutive; }
            [DebuggerStepThrough]
            set { IdSrRExecutive = value; }
        }

        private Int32? _numberPp;
        public Int32? NumberPp
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrNumberPp[Row] as Int32?;
                else
                    return _numberPp;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrNumberPp[Row] = value;
                else
                    _numberPp = value;
            }
        }
        public Int32? NUMBER_PP_SREX
        { //Web-доступ
            [DebuggerStepThrough]
            get { return NumberPp; }
            [DebuggerStepThrough]
            set { NumberPp = value; }
        }

        private String _fio;
        public String Fio
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrFio[Row] as String;
                else
                    return _fio;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrFio[Row] = value;
                else
                    _fio = value;
            }
        }
        public String FIO_SREX
        { //Web-доступ
            [DebuggerStepThrough]
            get { return Fio; }
            [DebuggerStepThrough]
            set { Fio = value; }
        }

        private String _login;
        public String Login
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrLogin[Row] as String;
                else
                    return _login;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrLogin[Row] = value;
                else
                    _login = value;
            }
        }
        public String LOGIN_SREX
        { //Web-доступ
            [DebuggerStepThrough]
            get { return Login; }
            [DebuggerStepThrough]
            set { Login = value; }
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
        public String VVOD_ID_CONTRACTOR_SREX
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
        public String CHANGE_ID_CONTRACTOR_SREX
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
        public DateTime? DATE_INPUT_SREX
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
        public DateTime? DATE_CHANGE_SREX
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

    public class SrRExecutiveEntity : GraphEntity, IEnumerable<SrRExecutiveEntityInstance>
    {

        #region проход по строкам выборки дата-класса
        public IEnumerator<SrRExecutiveEntityInstance> GetEnumerator()
        {
            if (Data.Active)
            {
                SrRExecutiveEntityInstance el;
                DataRowCollection __rows = Data.Table.Rows;
                foreach (DataRow row in __rows)
                {
                    el = new SrRExecutiveEntityInstance(row);
                    yield return el;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        #endregion

        #region конструкторы
        public SrRExecutiveEntity() : this(s_DbConnection.CurrentConnectionName) { }
        public SrRExecutiveEntity(string pConnectionName) : base(pConnectionName) { }
        #endregion

        #region xml-схема класса
        public static string GetXml()
        {
            return
            "<Class\r\n" +
            "       DefaultCaption='СЗ_С_ИСПОЛНИТЕЛЬ'\r\n" +
            "       DefaultDataClass='SrRExecutiveData'\r\n" +
            "       InstanceClass='SrRExecutiveEntityInstance'\r\n" +
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

        #region встроенный объект SrRExecutiveEntityInstance
        //Создается при первом обращении
        private SrRExecutiveEntityInstance _entityInstance;
        public SrRExecutiveEntityInstance Instance
        {
            get
            {
                if (_entityInstance == null)
                    _entityInstance = new SrRExecutiveEntityInstance();
                return _entityInstance;
            }
        }
        #endregion

        #region константы
        static public string TableName
        {
            get
            {
                return "SR_R_EXECUTIVE_SREX".ToFullObjectName(s_DatabaseObjectType.Table); //PM_DEMO_DATA.DBO.
            }
        }
        // Имена атрибутов (колонок выборки)
        //  (в первоначальной редакции не учтены вычисляемые атрибуты. Их можно добавить вручную)
        static readonly public string ColumnIdSrRExecutive = "ID_SR_R_EXECUTIVE_SREX";
        static readonly public string ColumnNumberPp = "NUMBER_PP_SREX";
        static readonly public string ColumnFio = "FIO_SREX";
        static readonly public string ColumnLogin = "LOGIN_SREX";
        static readonly public string ColumnLoginInChat = "LOGIN_IN_CHAT_SREX";
        static readonly public string ColumnVvodIdContractor = "VVOD_ID_CONTRACTOR_SREX";
        static readonly public string ColumnChangeIdContractor = "CHANGE_ID_CONTRACTOR_SREX";
        static readonly public string ColumnDateInput = "DATE_INPUT_SREX";
        static readonly public string ColumnDateChange = "DATE_CHANGE_SREX";
        #endregion

        #region заготовки для перекрытия методов
        /*----------------------------------------------------------*/
        /*
            public override void Calculate(DataRow row) {
              if (row == null)
                return;
              if ((row.RowState == DataRowState.Detached) || (row.RowState == DataRowState.Deleted))
                return;
              base.Calculate(row);
              //Data.Attributes["CalcInt32"][row] = row[<atr_name>];
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override void DefineCalculate(s_DataObject data) {
              base.DefineCalculate(data);
              //data.AddInt32Calculate("CalcInt32", "Тест-Calc-Int32");
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnInstanceCreating(s_EntityInstanceCreatingEventArgs e) {
              base.OnInstanceCreating(e);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnInstanceDeleting(s_EntityInstanceDeleteEventArgs e) {
              base.OnDeleting(e);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnInstanceDeleted(s_EntityInstanceDeleteEventArgs e) {
              base.OnInstanceDeleted(e);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnSelectionSaving(CancelEventArgs e) {
              base.OnSelectionSaving(e);
              if (e.Cancel) return;
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnSelectionSaved(EventArgs e) {
              base.OnSelectionSaved(e);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnSelectionUnSaving(CancelEventArgs e) {
              base.OnSelectionUnSaving(e);
              if (e.Cancel) return;
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnSelectionUnSaved(EventArgs e) {
              base.OnSelectionUnSaved(e);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnAttributeChanging(s_DataColumn atr, s_AttributeChangingEventArgs e) {
              base.OnAttributeChanging(atr, e);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnColumnChanged(s_DataColumn atr, s_ColumnChangedEventArgs e) {
              base.OnColumnChanged(atr, e);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnAttributeValidating(s_DataColumn atr, s_AttributeValidatingEventArgs e) {
              base.OnAttributeValidating(atr, e);
              if (e.Cancel) return;
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnShowing(CancelEventArgs e) {
              base.OnShowing(e);
              if (e.Cancel) return;
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnShowned(EventArgs e) {
              base.OnShowned(e);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            protected override void OnInstanceValidating(s_EntityInstanceValidatingEventArgs e) {
              base.OnInstanceValidating(e);
              if (e.Cancel) return;
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override void BeforeInsertTrigger(string tableName, DataRow row, ref s_BeforeTriggerActionType actionType) {
              base.BeforeInsertTrigger(tableName, row, actionType);
              if (actionType != s_BeforeTriggerActionType.Continue)
                return
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override void AfterInsertTrigger(DataRow row) {
              base.AfterInsertTrigger(tableName, row);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override void BeforeDeleteTrigger(string tableName, DataRow row, ref s_BeforeTriggerActionType actionType) {
              base.BeforeDeleteTrigger(tableName, row, actionType);
              if (actionType != s_BeforeTriggerActionType.Continue)
                return
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override void AfterDeleteTrigger(DataRow row) {
              base.AfterDeleteTrigger(tableName, row);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override void BeforeUpdateTrigger(string tableName, DataRow row, ref s_BeforeTriggerActionType actionType) {
              base.BeforeUpdateTrigger(tableName, row, actionType);
              if (actionType != s_BeforeTriggerActionType.Continue)
                return
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override void AfterUpdateTrigger(DataRow row) {
              base.AfterUpdateTrigger(row);
              //. . .
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override string GetQueryText(string queryName) {
              string result = base.GetQueryText(queryName);
              if (!String.IsNullOrEmpty(result))
                return result;
              //. . .
              return result;
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override void ShowData(s_NamedObjects showParameters) {
              CancelEventArgs __e = new CancelEventArgs();
              OnShowing(__e);
              if (__e.Cancel)
                return;
              //. . .
              OnShowned(new EventArgs());
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override string GetGridColumns() {
              string result = base.GetGridColumns();
              //. . .
              return result;
            }
        /**/
        /*----------------------------------------------------------*/
        /*
            public override string GetReadOnlyColumns() {
              string result = base.GetReadOnlyColumns();
              //. . .
              return result;
            }
        /**/
        /*Для использования в списках методов GetReadOnlyColumns, GetGridColumns:
          ColumnIdSrRExecutive
        + ";" + ColumnNumberPp
        + ";" + ColumnFio
        + ";" + ColumnLogin
        + ";" + ColumnVvodIdContractor
        + ";" + ColumnChangeIdContractor
        + ";" + ColumnDateInput
        + ";" + ColumnDateChange
        */
        #endregion

        #region заготовки типовых методов
        /*----------------------------------------------------------*/
        /*
        public bool FullList(s_EntityAction actionType) {
          SelectionName = "FullList";
          bool result = true;
          if (actionType == s_EntityAction.Open) result = Data.Open();
          return result;
        }
        /**/
        /*----------------------------------------------------------*/
        /*
        public bool ById(Int64 id, s_EntityAction actionType) {
          SelectionName = "ById";
          s_SelectionInfo sel_inf = Data.ClassInfo.Selections[SelectionName];
          if (sel_inf == null) return false;
          string PARAM_NAME = sel_inf.ListParams.SubstringBefore(";");
          if (String.IsNullOrEmpty(PARAM_NAME)) return false;
          if (PARAM_NAME.StartsWith("@"))
            PARAM_NAME = PARAM_NAME.Substring(2);
          bool result = Data.Parameters.Contains(PARAM_NAME);
          if (result) {
            if (actionType == s_EntityAction.Open)
              result = Data.Find(new s_NamedObjects(PARAM_NAME, new object[] {id}));
            else 
              Data.SetParameter(PARAM_NAME, id);
          }
          return result;
        }
        /**/
        //шаблон для выборки с двумя параметрами
        /*----------------------------------------------------------*/
        /*
        public bool By[Par1andPar2](object par1Value, par2Value, s_EntityAction actionType) {
          string PARAM_NAMES = "P..;P..";
          object[] v = new object[] {par1Value, par2Value} ;
          SelectionName = "By...";
          if (actionType == s_EntityAction.Open)
            result = Data.Find(new s_NamedObjects(PARAM_NAMES, v));
          else
            result = Data.SetParameters(PARAM_NAMES, v);
        }
        /**/

        public bool ByLogin(string Login, s_EntityAction actionType)
        {
            SelectionName = "ByLogin";
            s_SelectionInfo sel_inf = Data.ClassInfo.Selections[SelectionName];
            if (sel_inf == null) return false;
            string PARAM_NAME = sel_inf.ListParams.SubstringBefore(";");
            if (String.IsNullOrEmpty(PARAM_NAME)) return false;
            if (PARAM_NAME.StartsWith("@"))
                PARAM_NAME = PARAM_NAME.Substring(2);
            bool result = Data.Parameters.Contains(PARAM_NAME);
            if (result)
            {
                if (actionType == s_EntityAction.Open)
                    result = Data.Find(new s_NamedObjects(PARAM_NAME, new object[] { Login }));
                else
                    Data.SetParameter(PARAM_NAME, Login);
            }
            return result;
        }
        #endregion

        public override string GetGridColumns()
        {
            string res = base.GetGridColumns();

            if (SelectionName.SameStr("UN_ORDINATE_List") || SelectionName.SameStr("UN_ORDINATE_ONE_RECORD"))
            {
                res += TUnOrdinatexyhUoxyEntity.ListForGetGridColumns(this.Data);
            }

            return res;
        }

        /// <summary>
        /// Получить ID текущего пользователя в справочнике исполнителей
        /// </summary>
        /// <returns></returns>
        public static int GetIdCurrentUser()
        {
            int id = -1;
            SrRExecutiveEntity E_SREX = new SrRExecutiveEntity();
            E_SREX.ByLogin(s_UserEntity.Login, s_EntityAction.Open);
            if (E_SREX.Data.Rows.Count > 0)
            {
                E_SREX.Instance.Row = E_SREX.Data.Rows[0];
                id = E_SREX.Instance.IdSrRExecutive.ObjToID();
            }
            E_SREX.Data.Close();
            E_SREX.Dispose();

            return id;
        }

        /// <summary>
        /// Окрытие класса совместно с таблицей UN_ORDINATEXYH_UOXY
        /// </summary>
        /// <param name="actionType"></param>
        /// <returns></returns>
        public bool UN_ORDINATE_List(s_EntityAction actionType)
        {
            SelectionName = "UN_ORDINATE_List";
            bool result = true;
            if (actionType == s_EntityAction.Open)
                result = Data.Open();
            return result;
        }
        /// <summary>
        /// Окрытие класса совместно с таблицей UN_ORDINATEXYH_UOXY - Режим одной записи
        /// </summary>
        /// <param name="actionType"></param>
        /// <returns></returns>
        public bool UN_ORDINATE_ONE_RECORD(s_EntityAction actionType)
        {
            SelectionName = "UN_ORDINATE_ONE_RECORD";
            bool result = true;
            if (actionType == s_EntityAction.Open)
                result = Data.Open();
            return result;
        }

        protected override void DefineCalculate(s_DataObject pData)
        {
            base.DefineCalculate(pData);
            if (SelectionName.SameStr("UN_ORDINATE_List") || SelectionName.SameStr("UN_ORDINATE_ONE_RECORD"))
            {
                CConverter = new CoordConverter();
                CoordEntity = new TUnOrdinatexyhUoxyEntity();
                pData.AddStringCalculate("CNV_NAME", 100, "Расчетная система координат");
                //29.01.2016 ConstN fix 13801 
                if (SelectionName.SameText("UN_ORDINATE_List"))
                {
                    pData.AddDoubleCalculate("CNV_X", "Расчетная координата X");
                    pData.AddDoubleCalculate("CNV_Y", "Расчетная координата Y");
                }
                else
                {
                    pData.AddDoubleCalculate("CNV_X", "Расчетная координата X. Проектная");
                    pData.AddDoubleCalculate("CNV_Y", "Расчетная координата Y. Проектная");
                    pData.AddDoubleCalculate("CNV_X_F", "Расчетная координата X. Фактическая");
                    pData.AddDoubleCalculate("CNV_Y_F", "Расчетная координата Y. Фактическая");
                }
            }
        }

        private CoordConverter CConverter;
        int f_CoordinateSystemIdForConvert = -1;
        /// <summary>
        /// ID системы координат, в которую производится пересчет расчетных координат
        /// </summary>
        public int CoordinateSystemIdForConvert
        {
            get
            {
                return f_CoordinateSystemIdForConvert;
            }
            set
            {
                if (value == -1)
                {
                    CoordinateSystemIdForConvertName = "";
                }
                else
                {
                    s_DbCommand dbc = new s_DbCommand();
                    dbc.CommandText = " select NAME_FULL_STMC " +
                        " from " + "COORDINATE_STMC".ToFullTableName() + " " +
                        " where ID_COORDINATE_STMC = :ID " +
                        "";
                    dbc.ParamByName("ID").Value = value;
                    if (dbc.Open() && dbc.HasRows && dbc.Read())
                    {
                        CoordinateSystemIdForConvertName = dbc.GetValue("NAME_FULL_STMC").ObjToStr();
                    }
                    dbc.Close();
                    dbc.Dispose();
                }

                f_CoordinateSystemIdForConvert = value;
            }
        }

        string CoordinateSystemIdForConvertName = "";
        private TUnOrdinatexyhUoxyEntity CoordEntity;
        protected override void Calculate(DataRow row)
        {
            if ((row.RowState == DataRowState.Detached) || (row.RowState == DataRowState.Deleted)) return;
            base.Calculate(row);

            //Надо. 
            //1) Рассчитать координаты по полям "COOR_SH_DEC_GRAD" и т.п. пр. и заполнить поля CNV_X и CNV_Y. Они будут всегда. 
            //2) Проверить - если у нас режим UN_ORDINATE_ONE_RECORD (одна запись для Проектная/Фактическая), рассчитать координаты по полям "COOR_SH_DEC_GRAD_F" и т.п. пр.
            //   и заполнить поля CNV_X_F и CNV_Y_F
            if (SelectionName.SameText("UN_ORDINATE_List") || SelectionName.SameText("UN_ORDINATE_ONE_RECORD"))
            {
                //1) координаты по полям "COOR_SH_DEC_GRAD" и пр.
                double sx, sy, dx, dy;
                sx = Func.DBDouble(Data["COOR_SH_DEC_GRAD", row]);
                sy = Func.DBDouble(Data["COOR_VD_DEC_GRAD", row]);
                int ID_STMC = Func.DBInt(Data["COOR_ID_COORDINATE", row]);
                CoordinateSystemType tp = CoordinateSystemType.cstUndefined;
                if (CoordEntity.CoordinateSystemTypes.TryGetValue(ID_STMC, out tp) && tp == CoordinateSystemType.cstRectangular)
                {
                    sx -= 10000;
                    sy -= 20000;
                }
                if (CoordinateSystemIdForConvert > 0)
                {
                    if (!CConverter.Convert(ID_STMC, CoordinateSystemIdForConvert, sx, sy, out dx, out dy))
                    {
                        dx = 0;
                        dy = 0;
                    }
                }
                else
                {
                    dx = 0;
                    dy = 0;
                }
                Data["CNV_NAME", row] = CoordinateSystemIdForConvertName;
                if (dx != 0 || dy != 0)
                {
                    Data["CNV_X", row] = dx;
                    Data["CNV_Y", row] = dy;
                }
                else
                {
                    Data["CNV_X", row] = null;
                    Data["CNV_Y", row] = null;
                }
                //2) координаты по полям "COOR_SH_DEC_GRAD_F" и пр.
                if (SelectionName.SameText("UN_ORDINATE_ONE_RECORD"))
                {
                    double sxf, syf, dxf, dyf;
                    sxf = Func.DBDouble(Data["COOR_SH_DEC_GRAD_F", row]);
                    syf = Func.DBDouble(Data["COOR_VD_DEC_GRAD_F", row]);
                    int ID_STMC_F = Func.DBInt(Data["COOR_ID_COORDINATE_F", row]);
                    CoordinateSystemType tpf = CoordinateSystemType.cstUndefined;
                    if (CoordEntity.CoordinateSystemTypes.TryGetValue(ID_STMC_F, out tpf) && tpf == CoordinateSystemType.cstRectangular)
                    {
                        sxf -= 10000;
                        syf -= 20000;
                    }
                    if (CoordinateSystemIdForConvert > 0)
                    {
                        if (!CConverter.Convert(ID_STMC_F, CoordinateSystemIdForConvert, sxf, syf, out dxf, out dyf))
                        {
                            dxf = 0;
                            dyf = 0;
                        }
                    }
                    else
                    {
                        dxf = 0;
                        dyf = 0;
                    }
                    if (dxf != 0 || dyf != 0)
                    {
                        Data["CNV_X_F", row] = dxf;
                        Data["CNV_Y_F", row] = dyf;
                    }
                    else
                    {
                        Data["CNV_X_F", row] = null;
                        Data["CNV_Y_F", row] = null;
                    }
                }
            }
        }
        /// <summary>
        /// Удаление объекта пересчета координат
        /// </summary>
        /// <param name="manualDisposing"></param>
        protected override void Dispose(bool manualDisposing)
        {
            if (CConverter != null)
            {
                CConverter.Dispose();
                CConverter = null;
            }
            base.Dispose(manualDisposing);
        }

        public override void ShowData(object options)
        {
            s_EntityShowingEventArgs __e = new s_EntityShowingEventArgs();
            OnShowing(__e);
            if (__e.Cancel) return;
            s_NamedObjects lParams = GetShowDataParams(options);
            ShowGraph("0", Executors.SchemeText, lParams);
            OnShowned(EventArgs.Empty);
        }
    }
}
