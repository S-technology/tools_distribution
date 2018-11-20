/********************************************************************************/
/*                                                                              */
/*Copyright (c) 1999,2011   Information & Management Ltd.                       */
/*                                                                              */
/*   Модуль таблицы PM_OTLADKA_DATA.DBO.SR_DETAIL_REMARK_SRDR                   */
/*                                                                              */
/*   NAME  ESrDetailRemark.cs    SCOPE    ....                                  */
/*                                                                              */
/*   DESCRIPTION                                                                */
/*     Детализация задания                                                    */
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

  //s_DataObject.Register(typeof(SrDetailRemarkData));
  //s_EntityObject.Register(typeof(SrDetailRemarkEntity));

  public class SrDetailRemarkData : GraphDataObject {

      protected override void GetSQL()
      {
          SelectClause.Add("select " + ClassInfo.TableAlias + ".* ");
          FromClause.Add("from " + TableName + " " + ClassInfo.TableAlias);
          //OrderByClause.Add(" " + ClassInfo.TableAlias + ".ID_SR_DETAIL_REMARK_SRDR ");//order by 
      }

  #region конструкторы
    public SrDetailRemarkData() : this("Default") { }
    public SrDetailRemarkData(string pSelectionName) : base(pSelectionName) {
      //SelectClause.Add("select " + ClassInfo.TableAlias + ".* ");
      //FromClause.Add("from " + TableName + " " + ClassInfo.TableAlias);

        Sort = "ID_SR_REMARK_SRDR, NUMBER_PP_SRDR";
    }
  #endregion

    #region актуализация типа ссылки на класс-сущность
    public new SrDetailRemarkEntity Entity
    {
        [DebuggerStepThrough]
        get
        {
            return (SrDetailRemarkEntity)base.Entity;
        }
    }
    #endregion

    public static string GetXml()
    {
      return
      "<Class\r\n" + 
      "       TableName='%PROJECTSCHEMA%.SR_DETAIL_REMARK_SRDR'\r\n" +
      "       TableAlias='SR_DETAIL_REMARK_SRDR'\r\n" +
      "       UseForRef='TRUE'\r\n" +
      "       DefaultCaption='СЗ_ДЕТАЛИЗАЦИЯ ЗАМЕЧАНИЯ'\r\n" +
      "       FormulaName='СЗ_ДЕТАЛИЗАЦИЯ_ЗАМЕЧАНИЯ'\r\n" +
      "       Sequence='SEQ_SR_DETAIL_REMARK_SRDR'\r\n" +
      "       DefaultEntityClass='SrDetailRemarkEntity'\r\n" +
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
      "                  Params='@IPID_SR_DETAIL_REMARK_SRDR'\r\n" +
      "    >\r\n" +
      "      <Conditions>\r\n" +
      "        <Condition>ID_SR_DETAIL_REMARK_SRDR=:PID_SR_DETAIL_REMARK_SRDR</Condition>\r\n" +
      "      </Conditions>\r\n" +
      "    </Selection>\r\n" +
      "  </Selections>\r\n" +
      "  <Attributes>\r\n" +
      "    <Attribute Name='ID_SR_DETAIL_REMARK_SRDR'\r\n" +
      "             RusName='ID_Детализация'\r\n" +
      "             FormulaName='ID_ДЕТАЛИЗАЦИЯ'\r\n" +
      "             ReadOnly='true'\r\n" +
      "             DisableUserEdit='true'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='ID_SR_REMARK_SRDR'\r\n" +
      "             RusName='ID_Замечание'\r\n" +
      "             FormulaName='ID_ЗАМЕЧАНИЕ'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='NUMBER_PP_SRDR'\r\n" +
      "             RusName='№ п/п'\r\n" +
      "             FormulaName='№_П_П'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='DESCRIPTION_ACTION_SRDR'\r\n" +
      "             RusName='Описание последовательности действий'\r\n" +
      "             FormulaName='ОПИСАНИЕ_ПОСЛЕДОВАТЕЛЬНОСТИ_ДЕЙСТВИЙ'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='LINK_SRDR'\r\n" +
      "             RusName='Ссылка на документ или скриншот'\r\n" +
      "             FormulaName='ССЫЛКА_НА_ДОКУМЕНТ_ИЛИ_СКРИНШОТ'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='VVOD_ID_CONTRACTOR_SRDR'\r\n" +
      "             RusName='Автор ввода'\r\n" +
      "             FormulaName='АВТОР_ВВОДА'\r\n" +
      "             DisableUserEdit='true'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='CHANGE_ID_CONTRACTOR_SRDR'\r\n" +
      "             RusName='Автор изменения'\r\n" +
      "             FormulaName='АВТОР_ИЗМЕНЕНИЯ'\r\n" +
      "             DisableUserEdit='true'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='DATE_INPUT_SRDR'\r\n" +
      "             RusName='Дата ввода'\r\n" +
      "             FormulaName='ДАТА_ВВОДА'\r\n" +
      "             DisableUserEdit='true'\r\n" +
      "             DataType='DateTime'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='DATE_CHANGE_SRDR'\r\n" +
      "             RusName='Дата изменения'\r\n" +
      "             FormulaName='ДАТА_ИЗМЕНЕНИЯ'\r\n" +
      "             DisableUserEdit='true'\r\n" +
      "             DataType='DateTime'\r\n" +
      "    />\r\n" +
      "    <Attribute Name='SR_REMARK_SRDR_NAME'\r\n" +
      "             Type='Lookup'\r\n" +
      "             UseIn='Default;FullList;ById'\r\n" +
      "             ClassName='SrRemarkData'\r\n" +
      "             KeyField='ID_SR_REMARK_SRDR'\r\n" +
      "             RusName='Замечание'\r\n" +
      "    />\r\n" +
      "  </Attributes>\r\n" +
      "  <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20110317' />\r\n" +
      "  <Comment>..</Comment>\r\n" +
      "</Class>"
      ;
    }//GetXML

    #region атрибуты выборки
    //  ( в первоначальной редакции не учтены вычисляемые атрибуты. Их можно добавить вручную)
    private s_DataColumn _attrIdSrDetailRemark;
    public s_DataColumn AttrIdSrDetailRemark
    {
        get
        {
            if (_attrIdSrDetailRemark == null)
                _attrIdSrDetailRemark = Attributes[SrDetailRemarkEntity.ColumnIdSrDetailRemark];
            return _attrIdSrDetailRemark;
        }
    }
    private s_DataColumn _attrIdSrRemark;
    public s_DataColumn AttrIdSrRemark
    {
        get
        {
            if (_attrIdSrRemark == null)
                _attrIdSrRemark = Attributes[SrDetailRemarkEntity.ColumnIdSrRemark];
            return _attrIdSrRemark;
        }
    }
    private s_DataColumn _attrNumberPp;
    public s_DataColumn AttrNumberPp
    {
        get
        {
            if (_attrNumberPp == null)
                _attrNumberPp = Attributes[SrDetailRemarkEntity.ColumnNumberPp];
            return _attrNumberPp;
        }
    }
    private s_DataColumn _attrDescriptionAction;
    public s_DataColumn AttrDescriptionAction
    {
        get
        {
            if (_attrDescriptionAction == null)
                _attrDescriptionAction = Attributes[SrDetailRemarkEntity.ColumnDescriptionAction];
            return _attrDescriptionAction;
        }
    }
    private s_DataColumn _attrLink;
    public s_DataColumn AttrLink
    {
        get
        {
            if (_attrLink == null)
                _attrLink = Attributes[SrDetailRemarkEntity.ColumnLink];
            return _attrLink;
        }
    }
    private s_DataColumn _attrVvodIdContractor;
    public s_DataColumn AttrVvodIdContractor
    {
        get
        {
            if (_attrVvodIdContractor == null)
                _attrVvodIdContractor = Attributes[SrDetailRemarkEntity.ColumnVvodIdContractor];
            return _attrVvodIdContractor;
        }
    }
    private s_DataColumn _attrChangeIdContractor;
    public s_DataColumn AttrChangeIdContractor
    {
        get
        {
            if (_attrChangeIdContractor == null)
                _attrChangeIdContractor = Attributes[SrDetailRemarkEntity.ColumnChangeIdContractor];
            return _attrChangeIdContractor;
        }
    }
    private s_DataColumn _attrDateInput;
    public s_DataColumn AttrDateInput
    {
        get
        {
            if (_attrDateInput == null)
                _attrDateInput = Attributes[SrDetailRemarkEntity.ColumnDateInput];
            return _attrDateInput;
        }
    }
    private s_DataColumn _attrDateChange;
    public s_DataColumn AttrDateChange
    {
        get
        {
            if (_attrDateChange == null)
                _attrDateChange = Attributes[SrDetailRemarkEntity.ColumnDateChange];
            return _attrDateChange;
        }
    }
    private s_DataColumn _attrSrRemarkName;
    public s_DataColumn AttrSrRemarkName
    {
        get
        {
            if (_attrSrRemarkName == null)
                _attrSrRemarkName = Attributes[SrDetailRemarkEntity.ColumnSrRemarkName];
            return _attrSrRemarkName;
        }
    }
    #endregion

    #region методы для взаимодействия с ObjectDataSource (WebForms)
    public void InsertInstance(SrDetailRemarkEntityInstance instance)
    {
    }
    public void DeleteInstance(SrDetailRemarkEntityInstance instance)
    {
    }
    public void UpdateInstance(SrDetailRemarkEntityInstance instance)
    {
    }
    #endregion

  }

  public class SrDetailRemarkEntityInstance : s_EntityInstance {
      #region конструкторы
      public SrDetailRemarkEntityInstance() : this(null) { }
      public SrDetailRemarkEntityInstance(DataRow row) : base(row) { }
      #endregion

      #region актуализация типов ссылок на класс-сущность и дата-класс
      public new SrDetailRemarkEntity Entity
      {
          [DebuggerStepThrough]
          get
          {
              return (SrDetailRemarkEntity)base.Entity;
          }
      }

      public new SrDetailRemarkData Data
      {
          [DebuggerStepThrough]
          get
          {
              return (SrDetailRemarkData)base.Data;
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
      private Int32? _idSrDetailRemark;
      public Int32? IdSrDetailRemark
      {
          [DebuggerStepThrough]
          get
          {
              if (Row != null)
                  return Data.AttrIdSrDetailRemark[Row] as Int32?;
              else
                  return _idSrDetailRemark;
          }
          [DebuggerStepThrough]
          set
          {
              if (Row != null)
                  Data.AttrIdSrDetailRemark[Row] = value;
              else
                  _idSrDetailRemark = value;
          }
      }
      public Int32? ID_SR_DETAIL_REMARK_SRDR
      { //Web-доступ
          [DebuggerStepThrough]
          get { return IdSrDetailRemark; }
          [DebuggerStepThrough]
          set { IdSrDetailRemark = value; }
      }

      private Int32? _idSrRemark;
      public Int32? IdSrRemark
      {
          [DebuggerStepThrough]
          get
          {
              if (Row != null)
                  return Data.AttrIdSrRemark[Row] as Int32?;
              else
                  return _idSrRemark;
          }
          [DebuggerStepThrough]
          set
          {
              if (Row != null)
                  Data.AttrIdSrRemark[Row] = value;
              else
                  _idSrRemark = value;
          }
      }
      public Int32? ID_SR_REMARK_SRDR
      { //Web-доступ
          [DebuggerStepThrough]
          get { return IdSrRemark; }
          [DebuggerStepThrough]
          set { IdSrRemark = value; }
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
      public Int32? NUMBER_PP_SRDR
      { //Web-доступ
          [DebuggerStepThrough]
          get { return NumberPp; }
          [DebuggerStepThrough]
          set { NumberPp = value; }
      }

      private String _descriptionAction;
      public String DescriptionAction
      {
          [DebuggerStepThrough]
          get
          {
              if (Row != null)
                  return Data.AttrDescriptionAction[Row] as String;
              else
                  return _descriptionAction;
          }
          [DebuggerStepThrough]
          set
          {
              if (Row != null)
                  Data.AttrDescriptionAction[Row] = value;
              else
                  _descriptionAction = value;
          }
      }
      public String DESCRIPTION_ACTION_SRDR
      { //Web-доступ
          [DebuggerStepThrough]
          get { return DescriptionAction; }
          [DebuggerStepThrough]
          set { DescriptionAction = value; }
      }

      private String _link;
      public String Link
      {
          [DebuggerStepThrough]
          get
          {
              if (Row != null)
                  return Data.AttrLink[Row] as String;
              else
                  return _link;
          }
          [DebuggerStepThrough]
          set
          {
              if (Row != null)
                  Data.AttrLink[Row] = value;
              else
                  _link = value;
          }
      }
      public String LINK_SRDR
      { //Web-доступ
          [DebuggerStepThrough]
          get { return Link; }
          [DebuggerStepThrough]
          set { Link = value; }
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
      public String VVOD_ID_CONTRACTOR_SRDR
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
      public String CHANGE_ID_CONTRACTOR_SRDR
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
      public DateTime? DATE_INPUT_SRDR
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
      public DateTime? DATE_CHANGE_SRDR
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
      private string _srRemarkName;
      public string SrRemarkName
      {
          [DebuggerStepThrough]
          get
          {
              if (Row != null)
                  return Data.AttrSrRemarkName[Row] as string;
              else
                  return _srRemarkName;
          }
          [DebuggerStepThrough]
          set
          {
              if (Row != null)
                  Data.AttrSrRemarkName[Row] = value;
              else
                  _srRemarkName = value;
          }
      }
      public string SR_REMARK_SRDR_NAME
      { //Web-доступ
          [DebuggerStepThrough]
          get { return SrRemarkName; }
          [DebuggerStepThrough]
          set { SrRemarkName = value; }
      }


      #endregion
  }

  public class SrDetailRemarkEntity : GraphEntity,  IEnumerable<SrDetailRemarkEntityInstance> {

  #region проход по строкам выборки дата-класса
    public IEnumerator<SrDetailRemarkEntityInstance> GetEnumerator() {
      if (Data.Active) {
        SrDetailRemarkEntityInstance el;
        DataRowCollection __rows = Data.Table.Rows;
        foreach (DataRow row in __rows) {
          el = new SrDetailRemarkEntityInstance(row);
          yield return el;
        }
      }
    }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
  #endregion

  #region конструкторы
    public SrDetailRemarkEntity() : this(s_DbConnection.CurrentConnectionName) { }
    public SrDetailRemarkEntity(string pConnectionName) : base(pConnectionName) 
    {
        SimpleNumerator sm = new SimpleNumerator();
        sm.PrepareNumerator(this, "NUMBER_PP_SRDR", "ID_SR_REMARK_SRDR"); 
    }
  #endregion

  #region xml-схема класса
    public static string GetXml() {
      return
      "<Class\r\n" +
      "       DefaultCaption='СЗ_ДЕТАЛИЗАЦИЯ ЗАМЕЧАНИЯ'\r\n" +
      "       DefaultDataClass='SrDetailRemarkData'\r\n" +
      "       InstanceClass='SrDetailRemarkEntityInstance'\r\n" +
          //      "       ReadOnly='true'\r\n" +
      //"       PrivilegeRead='Default'\r\n" +
      //"       PrivilegeWrite='Default'\r\n" +
      ">\r\n" +

      "  <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20110317' />\r\n" +
      "  <Comment>. . .</Comment>\r\n" +
      "</Class>"
    ;
    }//GetXML
  #endregion

  #region встроенный объект SrDetailRemarkEntityInstance
      //Создается при первом обращении
    private SrDetailRemarkEntityInstance _entityInstance;
    public SrDetailRemarkEntityInstance Instance {
      get {
        if (_entityInstance == null)
          _entityInstance = new SrDetailRemarkEntityInstance();
        return _entityInstance;
      }
    }
  #endregion

    #region константы
    static readonly public string TableName = "SR_DETAIL_REMARK_SRDR".ToFullObjectName(s_DatabaseObjectType.Table);
    // Имена атрибутов (колонок выборки)
    //  (в первоначальной редакции не учтены вычисляемые атрибуты. Их можно добавить вручную)
    static readonly public string ColumnIdSrDetailRemark = "ID_SR_DETAIL_REMARK_SRDR";
    static readonly public string ColumnIdSrRemark = "ID_SR_REMARK_SRDR";
    static readonly public string ColumnNumberPp = "NUMBER_PP_SRDR";
    static readonly public string ColumnDescriptionAction = "DESCRIPTION_ACTION_SRDR";
    static readonly public string ColumnLink = "LINK_SRDR";
    static readonly public string ColumnVvodIdContractor = "VVOD_ID_CONTRACTOR_SRDR";
    static readonly public string ColumnChangeIdContractor = "CHANGE_ID_CONTRACTOR_SRDR";
    static readonly public string ColumnDateInput = "DATE_INPUT_SRDR";
    static readonly public string ColumnDateChange = "DATE_CHANGE_SRDR";
    static readonly public string ColumnSrRemarkName = "SR_REMARK_SRDR_NAME";
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
  ColumnIdSrDetailRemark
+ ";" + ColumnIdSrRemark
+ ";" + ColumnNumberPp
+ ";" + ColumnProgram
+ ";" + ColumnNameDb
+ ";" + ColumnPlaceError
+ ";" + ColumnDescriptionAction
+ ";" + ColumnLink
+ ";" + ColumnVvodIdContractor
+ ";" + ColumnChangeIdContractor
+ ";" + ColumnDateInput
+ ";" + ColumnDateChange
+ ";" + ColumnSrRemarkName
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
#endregion

  }
}
