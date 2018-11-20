/********************************************************************************/
/*                                                                              */
/*Copyright (c) 1999,2011   Information & Management Ltd.                       */
/*                                                                              */
/*   Модуль таблицы PM_OTLADKA_DATA.DBO.SR_R_STATUS_SRST                        */
/*                                                                              */
/*   NAME  ESrRStatus.cs    SCOPE    ....                                       */
/*                                                                              */
/*   DESCRIPTION                                                                */
/*     Статус задания                                                         */
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

namespace PM.Entity {

  //s_DataObject.Register(typeof(SrRStatusData));
  //s_EntityObject.Register(typeof(SrRStatusEntity));

  public class SrRStatusData : GraphDataObject {
      protected override void GetSQL()
      {
          SelectClause.Add("select " + ClassInfo.TableAlias + ".* ");
          FromClause.Add("from " + TableName + " " + ClassInfo.TableAlias);
      }

      #region конструкторы
    public SrRStatusData() : this("Default") { }
    public SrRStatusData(string pSelectionName) : base(pSelectionName) {
      //SelectClause.Add("select " + ClassInfo.TableAlias + ".* ");
      //FromClause.Add("from " + TableName + " " + ClassInfo.TableAlias);
        Sort = "NUMBER_PP_SRST";
    }
  #endregion

    #region актуализация типа ссылки на класс-сущность
    public new SrRStatusEntity Entity
    {
        [DebuggerStepThrough]
        get
        {
            return (SrRStatusEntity)base.Entity;
        }
    }
    #endregion

    public static string GetXml() {
      return
      "<Class\r\n" + 
      "       TableName='%PROJECTSCHEMA%.SR_R_STATUS_SRST'\r\n" +
      "       TableAlias='SR_R_STATUS_SRST'\r\n" +
      "       UseForRef='TRUE'\r\n" +
      "       DefaultCaption='СЗ_С_СТАТУС'\r\n" +
      "       FormulaName='СЗ_С_СТАТУС'\r\n" +
      "       Sequence='SEQ_SR_R_STATUS_SRST'\r\n" +
      "       DefaultEntityClass='SrRStatusEntity'\r\n" +
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
      "                  Params='@IPID_SR_R_STATUS_SRST'\r\n" +
      "    >\r\n" +
      "      <Conditions>\r\n" +
      "        <Condition>ID_SR_R_STATUS_SRST=:PID_SR_R_STATUS_SRST</Condition>\r\n" +
      "      </Conditions>\r\n" +
      "    </Selection>\r\n" +
      "    <Selection Name='ByNPP'\r\n" +
      "                  DefaultCaption='По NPP'\r\n" +
      "                  Params='@INPP'\r\n" +
      "    >\r\n" +
      "      <Conditions>\r\n" +
      "        <Condition>NUMBER_PP_SRST=:NPP</Condition>\r\n" +
      "      </Conditions>\r\n" +
      "    </Selection>\r\n" +
      "  </Selections>\r\n" +
      "  <Attributes>\r\n" +
      "    <Attribute Name='ID_SR_R_STATUS_SRST'\r\n" +
      "             RusName='ID_Статус'\r\n" +
      "             FormulaName='ID_СТАТУС'\r\n" +
      "             ReadOnly='true'\r\n" +
      "             DisableUserEdit='true'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='NUMBER_PP_SRST'\r\n" +
      "             RusName='№ п/п'\r\n" +
      "             FormulaName='№_П_П'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='NAME_STATUS_SRST'\r\n"  +
      "             RusName='Наименование статуса'\r\n" +
      "             FormulaName='НАИМЕНОВАНИЕ_СТАТУСА'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='COMMENT_SRST'\r\n" +
      "             RusName='Примечание'\r\n" +
      "             FormulaName='ПРИМЕЧАНИЕ'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='VVOD_ID_CONTRACTOR_SRST'\r\n" +
      "             RusName='Автор ввода'\r\n" +
      "             FormulaName='АВТОР_ВВОДА'\r\n" +
      "             DisableUserEdit='true'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='CHANGE_ID_CONTRACTOR_SRST'\r\n" +
      "             RusName='Автор изменения'\r\n" +
      "             FormulaName='АВТОР_ИЗМЕНЕНИЯ'\r\n" +
      "             DisableUserEdit='true'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='DATE_INPUT_SRST'\r\n" +
      "             RusName='Дата ввода'\r\n" +
      "             FormulaName='ДАТА_ВВОДА'\r\n" +
      "             DisableUserEdit='true'\r\n" +
      "             DataType='DateTime'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='DATE_CHANGE_SRST'\r\n" +
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
    private s_DataColumn _attrIdSrRStatus;
    public s_DataColumn AttrIdSrRStatus
    {
        get
        {
            if (_attrIdSrRStatus == null)
                _attrIdSrRStatus = Attributes[SrRStatusEntity.ColumnIdSrRStatus];
            return _attrIdSrRStatus;
        }
    }
    private s_DataColumn _attrNumberPp;
    public s_DataColumn AttrNumberPp
    {
        get
        {
            if (_attrNumberPp == null)
                _attrNumberPp = Attributes[SrRStatusEntity.ColumnNumberPp];
            return _attrNumberPp;
        }
    }
    private s_DataColumn _attrNameStatus;
    public s_DataColumn AttrNameStatus
    {
        get
        {
            if (_attrNameStatus == null)
                _attrNameStatus = Attributes[SrRStatusEntity.ColumnNameStatus];
            return _attrNameStatus;
        }
    }
    private s_DataColumn _attrComment;
    public s_DataColumn AttrComment
    {
        get
        {
            if (_attrComment == null)
                _attrComment = Attributes[SrRStatusEntity.ColumnComment];
            return _attrComment;
        }
    }
    private s_DataColumn _attrVvodIdContractor;
    public s_DataColumn AttrVvodIdContractor
    {
        get
        {
            if (_attrVvodIdContractor == null)
                _attrVvodIdContractor = Attributes[SrRStatusEntity.ColumnVvodIdContractor];
            return _attrVvodIdContractor;
        }
    }
    private s_DataColumn _attrChangeIdContractor;
    public s_DataColumn AttrChangeIdContractor
    {
        get
        {
            if (_attrChangeIdContractor == null)
                _attrChangeIdContractor = Attributes[SrRStatusEntity.ColumnChangeIdContractor];
            return _attrChangeIdContractor;
        }
    }
    private s_DataColumn _attrDateInput;
    public s_DataColumn AttrDateInput
    {
        get
        {
            if (_attrDateInput == null)
                _attrDateInput = Attributes[SrRStatusEntity.ColumnDateInput];
            return _attrDateInput;
        }
    }
    private s_DataColumn _attrDateChange;
    public s_DataColumn AttrDateChange
    {
        get
        {
            if (_attrDateChange == null)
                _attrDateChange = Attributes[SrRStatusEntity.ColumnDateChange];
            return _attrDateChange;
        }
    }
    #endregion

    #region методы для взаимодействия с ObjectDataSource (WebForms)
    public void InsertInstance(SrRStatusEntityInstance instance)
    {
    }
    public void DeleteInstance(SrRStatusEntityInstance instance)
    {
    }
    public void UpdateInstance(SrRStatusEntityInstance instance)
    {
    }
    #endregion

  }

  public class SrRStatusEntityInstance : s_EntityInstance {
      #region конструкторы
      public SrRStatusEntityInstance() : this(null) { }
      public SrRStatusEntityInstance(DataRow row) : base(row) { }
      #endregion

      #region актуализация типов ссылок на класс-сущность и дата-класс
      public new SrRStatusEntity Entity
      {
          [DebuggerStepThrough]
          get
          {
              return (SrRStatusEntity)base.Entity;
          }
      }

      public new SrRStatusData Data
      {
          [DebuggerStepThrough]
          get
          {
              return (SrRStatusData)base.Data;
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
      private Int32? _idSrRStatus;
      public Int32? IdSrRStatus
      {
          [DebuggerStepThrough]
          get
          {
              if (Row != null)
                  return Data.AttrIdSrRStatus[Row] as Int32?;
              else
                  return _idSrRStatus;
          }
          [DebuggerStepThrough]
          set
          {
              if (Row != null)
                  Data.AttrIdSrRStatus[Row] = value;
              else
                  _idSrRStatus = value;
          }
      }
      public Int32? ID_SR_R_STATUS_SRST
      { //Web-доступ
          [DebuggerStepThrough]
          get { return IdSrRStatus; }
          [DebuggerStepThrough]
          set { IdSrRStatus = value; }
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
      public Int32? NUMBER_PP_SRST
      { //Web-доступ
          [DebuggerStepThrough]
          get { return NumberPp; }
          [DebuggerStepThrough]
          set { NumberPp = value; }
      }

      private String _nameStatus;
      public String NameStatus
      {
          [DebuggerStepThrough]
          get
          {
              if (Row != null)
                  return Data.AttrNameStatus[Row] as String;
              else
                  return _nameStatus;
          }
          [DebuggerStepThrough]
          set
          {
              if (Row != null)
                  Data.AttrNameStatus[Row] = value;
              else
                  _nameStatus = value;
          }
      }
      public String NAME_STATUS_SRST
      { //Web-доступ
          [DebuggerStepThrough]
          get { return NameStatus; }
          [DebuggerStepThrough]
          set { NameStatus = value; }
      }

      private String _comment;
      public String Comment
      {
          [DebuggerStepThrough]
          get
          {
              if (Row != null)
                  return Data.AttrComment[Row] as String;
              else
                  return _comment;
          }
          [DebuggerStepThrough]
          set
          {
              if (Row != null)
                  Data.AttrComment[Row] = value;
              else
                  _comment = value;
          }
      }
      public String COMMENT_SRST
      { //Web-доступ
          [DebuggerStepThrough]
          get { return Comment; }
          [DebuggerStepThrough]
          set { Comment = value; }
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
      public String VVOD_ID_CONTRACTOR_SRST
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
      public String CHANGE_ID_CONTRACTOR_SRST
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
      public DateTime? DATE_INPUT_SRST
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
      public DateTime? DATE_CHANGE_SRST
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

  public class SrRStatusEntity : GraphEntity,  IEnumerable<SrRStatusEntityInstance> {

  #region проход по строкам выборки дата-класса
    public IEnumerator<SrRStatusEntityInstance> GetEnumerator() {
      if (Data.Active) {
        SrRStatusEntityInstance el;
        DataRowCollection __rows = Data.Table.Rows;
        foreach (DataRow row in __rows) {
          el = new SrRStatusEntityInstance(row);
          yield return el;
        }
      }
    }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
  #endregion

  #region конструкторы
    public SrRStatusEntity() : this(s_DbConnection.CurrentConnectionName) { }
    public SrRStatusEntity(string pConnectionName) : base(pConnectionName) { }
  #endregion

  #region xml-схема класса
    public static string GetXml() {
      return
      "<Class\r\n" +
      "       DefaultCaption='СЗ_С_СТАТУС'\r\n" +
      "       DefaultDataClass='SrRStatusData'\r\n" +
      "       InstanceClass='SrRStatusEntityInstance'\r\n" +
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

  #region встроенный объект SrRStatusEntityInstance
      //Создается при первом обращении
    private SrRStatusEntityInstance _entityInstance;
    public SrRStatusEntityInstance Instance {
      get {
        if (_entityInstance == null)
          _entityInstance = new SrRStatusEntityInstance();
        return _entityInstance;
      }
    }
  #endregion

    #region константы
    static readonly public string TableName = "SR_R_STATUS_SRST".ToFullObjectName(s_DatabaseObjectType.Table);
    // Имена атрибутов (колонок выборки)
    //  (в первоначальной редакции не учтены вычисляемые атрибуты. Их можно добавить вручную)
    static readonly public string ColumnIdSrRStatus = "ID_SR_R_STATUS_SRST";
    static readonly public string ColumnNumberPp = "NUMBER_PP_SRST";
    static readonly public string ColumnNameStatus = "NAME_STATUS_SRST";
    static readonly public string ColumnComment = "COMMENT_SRST";
    static readonly public string ColumnVvodIdContractor = "VVOD_ID_CONTRACTOR_SRST";
    static readonly public string ColumnChangeIdContractor = "CHANGE_ID_CONTRACTOR_SRST";
    static readonly public string ColumnDateInput = "DATE_INPUT_SRST";
    static readonly public string ColumnDateChange = "DATE_CHANGE_SRST";
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
  ColumnIdSrRStatus
+ ";" + ColumnNumberPp
+ ";" + ColumnNameStatus
+ ";" + ColumnVvodIdContractor
+ ";" + ColumnChangeIdContractor
+ ";" + ColumnDateInput
+ ";" + ColumnDateChang
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

    public bool ByNPP(Int64 NPP, s_EntityAction actionType)
    {
        SelectionName = "ByNPP";
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
                result = Data.Find(new s_NamedObjects(PARAM_NAME, new object[] { NPP }));
            else
                Data.SetParameter(PARAM_NAME, NPP);
        }
        return result;
    }
       
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
#endregion

  }
}
