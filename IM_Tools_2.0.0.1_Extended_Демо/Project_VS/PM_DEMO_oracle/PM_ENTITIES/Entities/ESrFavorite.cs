/********************************************************************************/
/*                                                                              */
/*Copyright (c) 1999,2016   Information & Management Ltd.                       */
/*                                                                              */
/*   ������ ������� PM_WORK_DATA.DBO.SR_FAVORITE_SRFV                           */
/*                                                                              */
/*   NAME  ESrFavorite.cs    SCOPE    ....                                      */
/*                                                                              */
/*   DESCRIPTION                                                                */
/*     ��_��������� ���������                                                   */
/*                                                                              */
/*   AUTHOR                                                                     */
/*     �������                                                                  */
/********************************************************************************/
 
/*
    01.03.2016  Automatic  �������������� ��������
                                                                               */

using System;
using System.Data;
using System.Diagnostics;
using IM.Hierarchy;
using S_;

namespace PM.Entity {

  //s_DataObject.Register(typeof(SrFavoriteData));
  //s_EntityObject.Register(typeof(SrFavoriteEntity));

  public class SrFavoriteData : GraphDataObject {
  #region �����������
    public SrFavoriteData(string pSelectionName = "Default") : base(pSelectionName) {
    }
  #endregion

  protected override void GetSQL() {
    SelectClause.Add("select " + ClassInfo.TableAlias + ".* ");
    FromClause.Add("from " + TableName + " " + ClassInfo.TableAlias);
  }

  #region ������������ ���� ������ �� �����-��������
    public new SrFavoriteEntity Entity {
      [DebuggerStepThrough]get {
        return (SrFavoriteEntity)base.Entity;
      }
    }
  #endregion

    static public string GetXml() {
      return
      @"<Class
             TableName='" + SrFavoriteEntity.TableName + @"'
             UseForRef='TRUE'
             Ancestor=''
             EditLock='true'
             DefaultCaption='��_��������� ���������'
             FormulaName='��_���������_���������'
             Sequence='SEQ_SR_FAVORITE_SRFV'
             DefaultEntityClass='SrFavoriteEntity'
             LookupKeyFields='Default'
             LookupResultField='Default' 
      >
        <Selections>
          <Selection Name='Default'
                        DefaultCaption=''
                        IsList='True'
          />
          <Selection Name='FullList'
                        DefaultCaption=''
                        IsList='True'
          />
          <Selection Name='ById'
                        DefaultCaption=''
                        Params='@IPID_SR_FAVORITE_SRFV'
          >
            <Conditions>
              <Condition>ID_SR_FAVORITE_SRFV=:PID_SR_FAVORITE_SRFV</Condition>
            </Conditions>
          </Selection>
        </Selections>
        <Attributes>
          <Attribute Name='ID_SR_FAVORITE_SRFV'
                   Title='ID_��������� ���������'
                   FormulaName='ID_���������_���������' 
                   ReadOnly='true'
                   DisableUserEdit='true'
          />
          <Attribute Name='ID_SR_REMARK_SRFV'
                   Title='ID_���������'
                   FormulaName='ID_���������' 
          />
          <Attribute Name='ID_SR_R_EXECUTIVE_SRFV'
                   Title='ID_�����������'
                   FormulaName='ID_�����������' 
          />
          <Attribute Name='VVOD_ID_CONTRACTOR_SRFV'
                   Title='����� �����'
                   FormulaName='�����_�����' 
                   DisableUserEdit='true'
          />
          <Attribute Name='CHANGE_ID_CONTRACTOR_SRFV'
                   Title='����� ���������'
                   FormulaName='�����_���������' 
                   DisableUserEdit='true'
          />
          <Attribute Name='DATE_INPUT_SRFV'
                   Title='���� �����'
                   FormulaName='����_�����' 
                   DataType='DateTime'
                   DisableUserEdit='true'
          />
          <Attribute Name='DATE_CHANGE_SRFV'
                   Title='���� ���������'
                   FormulaName='����_���������' 
                   DataType='DateTime'
                   DisableUserEdit='true'
          />
          <Attribute Name='SR_R_EXECUTIVE_SRFV_NAME'
                   Type='Lookup'
                   UseIn='Default;FullList;ById'
                   ClassName='SrRExecutiveData'
                   Title=''
                   KeyFields='ID_SR_R_EXECUTIVE_SRFV'
          />
          <Attribute Name='SR_REMARK_SRFV_NAME'
                   Type='Lookup'
                   UseIn='Default;FullList;ById'
                   ClassName='SrRemarkData'
                   Title=''
                   KeyFields='ID_SR_REMARK_SRFV'
          />
        </Attributes>
        <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20160301' />
        <Comment>..</Comment>
      </Class>"
      ;
    }//GetXML

  #region �������� �������
//  ( � �������������� �������� �� ������ ����������� ��������. �� ����� �������� �������)
    private s_DataColumn _attrIdSrFavorite;
//    [Required()] //������� using System.ComponentModel.DataAnnotations;
    public  s_DataColumn AttrIdSrFavorite {
      [DebuggerStepThrough]get { return _attrIdSrFavorite ?? (_attrIdSrFavorite = AttributeByName(SrFavoriteEntity.ColumnIdSrFavorite));}
    }
    private s_DataColumn _attrIdSrRemark;
//    [Required()] //������� using System.ComponentModel.DataAnnotations;
    public  s_DataColumn AttrIdSrRemark {
      [DebuggerStepThrough]get { return _attrIdSrRemark ?? (_attrIdSrRemark = AttributeByName(SrFavoriteEntity.ColumnIdSrRemark));}
    }
    private s_DataColumn _attrIdSrRExecutive;
//    [Required()] //������� using System.ComponentModel.DataAnnotations;
    public  s_DataColumn AttrIdSrRExecutive {
      [DebuggerStepThrough]get { return _attrIdSrRExecutive ?? (_attrIdSrRExecutive = AttributeByName(SrFavoriteEntity.ColumnIdSrRExecutive));}
    }
    private s_DataColumn _attrVvodIdContractor;
//    [Required()] //������� using System.ComponentModel.DataAnnotations;
    public  s_DataColumn AttrVvodIdContractor {
      [DebuggerStepThrough]get { return _attrVvodIdContractor ?? (_attrVvodIdContractor = AttributeByName(SrFavoriteEntity.ColumnVvodIdContractor));}
    }
    private s_DataColumn _attrChangeIdContractor;
    public  s_DataColumn AttrChangeIdContractor {
      [DebuggerStepThrough]get { return _attrChangeIdContractor ?? (_attrChangeIdContractor = AttributeByName(SrFavoriteEntity.ColumnChangeIdContractor));}
    }
    private s_DataColumn _attrDateInput;
//    [Required()] //������� using System.ComponentModel.DataAnnotations;
    public  s_DataColumn AttrDateInput {
      [DebuggerStepThrough]get { return _attrDateInput ?? (_attrDateInput = AttributeByName(SrFavoriteEntity.ColumnDateInput));}
    }
    private s_DataColumn _attrDateChange;
    public  s_DataColumn AttrDateChange {
      [DebuggerStepThrough]get { return _attrDateChange ?? (_attrDateChange = AttributeByName(SrFavoriteEntity.ColumnDateChange));}
    }
    private s_DataColumn _attrSrRExecutiveName;
    public  s_DataColumn AttrSrRExecutiveName {
      [DebuggerStepThrough]get { return _attrSrRExecutiveName ?? (_attrSrRExecutiveName = AttributeByName(SrFavoriteEntity.ColumnSrRExecutiveName));}
    }
    private s_DataColumn _attrSrRemarkName;
    public  s_DataColumn AttrSrRemarkName {
      [DebuggerStepThrough]get { return _attrSrRemarkName ?? (_attrSrRemarkName = AttributeByName(SrFavoriteEntity.ColumnSrRemarkName));}
    }
  #endregion

  #region ��������� ��� ���������� �������
  #endregion


  }

  public class SrFavoriteInstance : s_EntityInstance {
  #region ������������
    public SrFavoriteInstance() : this(null) { }
    public SrFavoriteInstance(DataRow row) : base(row) { }
  #endregion

  #region ������������ ����� ������ �� �����-�������� � ����-�����
    public new SrFavoriteEntity Entity {
      [DebuggerStepThrough]get {
        return (SrFavoriteEntity)base.Entity;
      }
    }

    public new SrFavoriteData Data {
      [DebuggerStepThrough]get {
        return (SrFavoriteData)base.Data;
      }
    }
  #endregion

  #region �������� ��� ������� � ��������� ��������� �������
/*
     � �������������� ��������:
       1. ���������� ��������� ������������ ����������� ����� �������
       2. �� ������:
            - ����������� ��������;
            - include-��������, ���������� � ����� ������� �� ������� �� ��������� lookup-���������.
          �������� ��� ������� � ��� ���� �������� �������.
*/
    private Int32? _idSrFavorite;
    public Int32? IdSrFavorite {
      [DebuggerStepThrough]get {
        if (IsRowValid())
          return Data.AttrIdSrFavorite[Row] as Int32?;
        else
          return _idSrFavorite;
      }
      [DebuggerStepThrough]set {
        if (IsRowValid())
          Data.AttrIdSrFavorite[Row] = value;
        else
          _idSrFavorite = value;
      }
    }

    private Int32? _idSrRemark;
    public Int32? IdSrRemark {
      [DebuggerStepThrough]get {
        if (IsRowValid())
          return Data.AttrIdSrRemark[Row] as Int32?;
        else
          return _idSrRemark;
      }
      [DebuggerStepThrough]set {
        if (IsRowValid())
          Data.AttrIdSrRemark[Row] = value;
        else
          _idSrRemark = value;
      }
    }

    private Int32? _idSrRExecutive;
    public Int32? IdSrRExecutive {
      [DebuggerStepThrough]get {
        if (IsRowValid())
          return Data.AttrIdSrRExecutive[Row] as Int32?;
        else
          return _idSrRExecutive;
      }
      [DebuggerStepThrough]set {
        if (IsRowValid())
          Data.AttrIdSrRExecutive[Row] = value;
        else
          _idSrRExecutive = value;
      }
    }

    private String _vvodIdContractor;
    public String VvodIdContractor {
      [DebuggerStepThrough]get {
        if (IsRowValid())
          return Data.AttrVvodIdContractor[Row] as String;
        else
          return _vvodIdContractor;
      }
      [DebuggerStepThrough]set {
        if (IsRowValid())
          Data.AttrVvodIdContractor[Row] = value;
        else
          _vvodIdContractor = value;
      }
    }

    private String _changeIdContractor;
    public String ChangeIdContractor {
      [DebuggerStepThrough]get {
        if (IsRowValid())
          return Data.AttrChangeIdContractor[Row] as String;
        else
          return _changeIdContractor;
      }
      [DebuggerStepThrough]set {
        if (IsRowValid())
          Data.AttrChangeIdContractor[Row] = value;
        else
          _changeIdContractor = value;
      }
    }

    private DateTime? _dateInput;
    public DateTime? DateInput {
      [DebuggerStepThrough]get {
        if (IsRowValid())
          return Data.AttrDateInput[Row] as DateTime?;
        else
          return _dateInput;
      }
      [DebuggerStepThrough]set {
        if (IsRowValid())
          Data.AttrDateInput[Row] = value;
        else
          _dateInput = value;
      }
    }

    private DateTime? _dateChange;
    public DateTime? DateChange {
      [DebuggerStepThrough]get {
        if (IsRowValid())
          return Data.AttrDateChange[Row] as DateTime?;
        else
          return _dateChange;
      }
      [DebuggerStepThrough]set {
        if (IsRowValid())
          Data.AttrDateChange[Row] = value;
        else
          _dateChange = value;
      }
    }

//     ������ ��� ���������� �������� �������:
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
/**/
    private string _srRExecutiveName;
    public string SrRExecutiveName{
      [DebuggerStepThrough]get {
        if (Row != null)
          return Data.AttrSrRExecutiveName[Row] as string;
        else
          return _srRExecutiveName;
      }
      [DebuggerStepThrough]set {
        if (Row != null)
          Data.AttrSrRExecutiveName[Row] = value;
        else
          _srRExecutiveName = value;
      }
    }

    private string _srRemarkName;
    public string SrRemarkName{
      [DebuggerStepThrough]get {
        if (Row != null)
          return Data.AttrSrRemarkName[Row] as string;
        else
          return _srRemarkName;
      }
      [DebuggerStepThrough]set {
        if (Row != null)
          Data.AttrSrRemarkName[Row] = value;
        else
          _srRemarkName = value;
      }
    }


  #endregion

  }

  public class SrFavoriteEntity : GraphEntity {

  #region ��������� ��������
    private SrFavoriteInstance _entityInstance;
    /// <summary>���������� ������-���������</summary>
    public SrFavoriteInstance Instance {
      [DebuggerStepThrough]get { return _entityInstance ?? (_entityInstance = new SrFavoriteInstance());}
    }
    private s_EntityInstanceList<SrFavoriteInstance> _instanceList;
    /// <summary>������ ����������� �������� �������</summary>
    public s_EntityInstanceList<SrFavoriteInstance> InstanceList {
      [DebuggerStepThrough]get { return _instanceList ?? (_instanceList = new s_EntityInstanceList<SrFavoriteInstance>(this)); }
    }
  #endregion

  #region ������������
    public SrFavoriteEntity(string pConnectionName = "") : base(pConnectionName) { }
  #endregion

  #region ������������ ���� ������ �� ����-�����
    public new SrFavoriteData Data {
      [DebuggerStepThrough]get {
        return (SrFavoriteData)base.Data;
      }
    }
  #endregion

  #region xml-����� ������
    static public string GetXml() {
      return
      @"<Class
             DefaultCaption='��_��������� ���������'
             DefaultDataClass='SrFavoriteData'
             InstanceClass='SrFavoriteInstance'
             PrivilegeRead='Default'
             PrivilegeWrite='Default'
      >

        <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20160301' />
        <Comment>. . .</Comment>
      </Class>"
    ;
    }//GetXML
  #endregion

  #region ���������
    /// <summary>SR_FAVORITE_SRFV</summary>
    static public string TableName { get { return "SR_FAVORITE_SRFV".ToFullObjectName(s_DatabaseObjectType.Table); } }
      // ����� ��������� (������� �������)
      //  (� �������������� �������� �� ������ ����������� ��������. �� ����� �������� �������)
    /// <summary>ID_SR_FAVORITE_SRFV</summary>
    static readonly public string ColumnIdSrFavorite = "ID_SR_FAVORITE_SRFV";
    /// <summary>ID_SR_REMARK_SRFV</summary>
    static readonly public string ColumnIdSrRemark = "ID_SR_REMARK_SRFV";
    /// <summary>ID_SR_R_EXECUTIVE_SRFV</summary>
    static readonly public string ColumnIdSrRExecutive = "ID_SR_R_EXECUTIVE_SRFV";
    /// <summary>VVOD_ID_CONTRACTOR_SRFV</summary>
    static readonly public string ColumnVvodIdContractor = "VVOD_ID_CONTRACTOR_SRFV";
    /// <summary>CHANGE_ID_CONTRACTOR_SRFV</summary>
    static readonly public string ColumnChangeIdContractor = "CHANGE_ID_CONTRACTOR_SRFV";
    /// <summary>DATE_INPUT_SRFV</summary>
    static readonly public string ColumnDateInput = "DATE_INPUT_SRFV";
    /// <summary>DATE_CHANGE_SRFV</summary>
    static readonly public string ColumnDateChange = "DATE_CHANGE_SRFV";
    /// <summary>SR_R_EXECUTIVE_SRFV_NAME</summary>
    static readonly public string ColumnSrRExecutiveName = "SR_R_EXECUTIVE_SRFV_NAME";
    /// <summary>SR_REMARK_SRFV_NAME</summary>
    static readonly public string ColumnSrRemarkName = "SR_REMARK_SRFV_NAME";
  #endregion

  #region ��������� ��� ���������� �������
/*
    public override string GetGridColumns() {
      string result = base.GetGridColumns();
      if (!String.IsNullOrEmpty(result) && !result.EndsWith(";"))
        result += ";";
      result +=
        ColumnIdSrFavorite
          + ";" + ColumnIdSrRemark
          + ";" + ColumnIdSrRExecutive
          + ";" + ColumnVvodIdContractor
          + ";" + ColumnChangeIdContractor
          + ";" + ColumnDateInput
          + ";" + ColumnDateChange
          + ";" + ColumnSrRExecutiveName
          + ";" + ColumnSrRemarkName
          ;
      return result;
    }
/**/
/*
    public override string GetReadOnlyColumns() {
      string result = base.GetReadOnlyColumns();
      if (!String.IsNullOrEmpty(result) && !result.EndsWith(";"))
        result += ";";
      result +=
        ColumnIdSrFavorite
          + ";" + ColumnIdSrRemark
          + ";" + ColumnIdSrRExecutive
          + ";" + ColumnVvodIdContractor
          + ";" + ColumnChangeIdContractor
          + ";" + ColumnDateInput
          + ";" + ColumnDateChange
          ;
      return result;
    }
/**/
#endregion

  #region ��������� ������� �������
/*
public bool FullList(s_EntityAction actionType) {
  SelectionName = "FullList";
  bool result = true;
  if (actionType == s_EntityAction.Open) result = Data.Open();
  return result;
}
/**/
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
//������ ��� ������� � ����� �����������
/*
public bool By[Par1andPar2](object par1Value, par2Value, s_EntityAction actionType) {
  string PARAM_NAMES = "P..;P..";
  object[] v = new object[] {par1Value, par2Value} ;
  SelectionName = "By...";
  bool result = true;
  if (actionType == s_EntityAction.Open)
    result = Data.Find(new s_NamedObjects(PARAM_NAMES, v));
  else 
    Data.SetParameters(PARAM_NAMES, v);
  return result;
}
/**/
#endregion

  }
}
