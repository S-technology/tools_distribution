/********************************************************************************/
/*                                                                              */
/*Copyright (c) 1999,2011   Information & Management Ltd.                       */
/*                                                                              */
/*   Модуль таблицы PM_OTLADKA_DATA.DBO.SR_REMARK_SRRM                          */
/*                                                                              */
/*   NAME  ESrRemark.cs    SCOPE    ....                                        */
/*                                                                              */
/*   DESCRIPTION                                                                */
/*     Задания                                                                */
/*                                                                              */
/*   AUTHOR                                                                     */
/*                                                                              */
/********************************************************************************/

/*
    17.03.2011  Automatic  Первоначальная редакция
                                                                               */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
//using ClientJabberService.JabberService;
using IM.Functions;
using IM.Hierarchy;
using S_;

/*
 * 01.03.16 Киселев добавлена колонка "В избранном"
   02.03.16 Киселев добавлена рассылка всем тем , кто добавил замечание в избранное*/

namespace PM.Entity
{
    //s_DataObject.Register(typeof(SrRemarkData));
    //s_EntityObject.Register(typeof(SrRemarkEntity));

    public class SrRemarkData : GraphDataObject
    {

        protected override void GetSQL()
        {
            if (SelectionName.SameStr("DistinctColumn"))
            {
                SelectClause.Add("select distinct top(10) " + ClassInfo.TableAlias + "." + (Entity as GraphEntity).distinctColumn + " ");
            }
            else
            {
                SelectClause.Add("select " + ClassInfo.TableAlias + ".* ");
                SelectClause.Add(", case when " + SrFavoriteEntity.ColumnIdSrFavorite + " is null then 'Н' else 'Д' end " + SrRemarkEntity.ColumnIsFavorite);
            }
            FromClause.Add("from " + TableName + " " + ClassInfo.TableAlias);
            FromClause.Add(" left join " + SrFavoriteEntity.TableName + " on " + SrFavoriteEntity.ColumnIdSrRemark + "=" + SrRemarkEntity.ColumnIdSrRemark +
                           "	and " + SrFavoriteEntity.ColumnIdSrRExecutive + "=" + SrRExecutiveEntity.GetIdCurrentUser());
        }

        #region конструкторы

        public SrRemarkData()
            : this("Default")
        {
        }

        public SrRemarkData(string pSelectionName)
            : base(pSelectionName)
        {
            Sort = SrRemarkEntity.ColumnSrRProjectName + ", " + SrRemarkEntity.ColumnDateCreate + " desc, " + SrRemarkEntity.ColumnNumberPp + " desc ";
        }
        #endregion

        public static string GetXml()
        {
            string LookupResultAgg = "";
            if (s_DbConnection.Connections[s_DbConnection.CurrentConnectionName] != null)
            {
                if (s_DbConnection.Connections[s_DbConnection.CurrentConnectionName].ServerType == s_ServerType.MSSQL)
                    LookupResultAgg =
                            " LookupResultAgg = '" +
                            " (SELECT     t3.NAME_PROJ_SRPJ from " + "SR_R_PROJECT_SRPJ".ToFullObjectName(s_DatabaseObjectType.Table) + " t3 JOIN " +
                            "                       " + "SR_REMARK_SRRM".ToFullObjectName(s_DatabaseObjectType.Table) + " t4 ON t3.ID_SR_R_PROJECT_SRPJ = t4.ID_SR_R_PROJECT_SRRM " +
                            "           WHERE     t4.ID_SR_REMARK_SRRM = @ID_SR_REMARK_SRRM) " +
                            " + &apos;, &apos; + " +
                            " CONVERT(varchar, @DATE_CREATE_SRRM, 104) " +
                            " + &apos;,  №&apos; + " +
                            " CONVERT(varchar, @NUMBER_PP_SRRM) " +
                            " + &apos;, &apos; + " +
                            " (SELECT     t1.NAME_STATUS_SRST " +
                            " FROM         " + "SR_R_STATUS_SRST".ToFullObjectName(s_DatabaseObjectType.Table) + " t1 JOIN " +
                            "                       " + "SR_REMARK_SRRM".ToFullObjectName(s_DatabaseObjectType.Table) + " t2 ON t1.ID_SR_R_STATUS_SRST = t2.ID_SR_R_STATUS_SRRM " +
                            " WHERE     t2.ID_SR_REMARK_SRRM = @ID_SR_REMARK_SRRM) " +
                            "'";

                else if (s_DbConnection.Connections[s_DbConnection.CurrentConnectionName].ServerType == s_ServerType.ORACLE)
                    LookupResultAgg =
                            " LookupResultAgg = '" +
                            " (SELECT     t3.NAME_PROJ_SRPJ from " + "SR_R_PROJECT_SRPJ".ToFullObjectName(s_DatabaseObjectType.Table) + " t3 JOIN " +
                            "                       " + "SR_REMARK_SRRM".ToFullObjectName(s_DatabaseObjectType.Table) + " t4 ON t3.ID_SR_R_PROJECT_SRPJ = t4.ID_SR_R_PROJECT_SRRM " +
                            "           WHERE     t4.ID_SR_REMARK_SRRM = @ID_SR_REMARK_SRRM) " +
                            " + &apos;, &apos; + " +
                            " TO_CHAR(@DATE_CREATE_SRRM,  &apos;DD-MM-YY&apos;) " +
                            " + &apos;,  №&apos; + " +
                            " TO_CHAR(@NUMBER_PP_SRRM) " +
                            " + &apos;, &apos; + (SELECT     t1.NAME_STATUS_SRST " +
                            " FROM         " + "SR_R_STATUS_SRST".ToFullObjectName(s_DatabaseObjectType.Table) + " t1 JOIN " +
                            "                       " + "SR_REMARK_SRRM".ToFullObjectName(s_DatabaseObjectType.Table) + " t2 ON t1.ID_SR_R_STATUS_SRST = t2.ID_SR_R_STATUS_SRRM " +
                            " WHERE     t2.ID_SR_REMARK_SRRM = @ID_SR_REMARK_SRRM) " +
                            "'";
            }
            return
                "<Class\r\n" +
                "       TableName='%PROJECTSCHEMA%.SR_REMARK_SRRM'\r\n" +
                "       TableAlias='SR_REMARK_SRRM'\r\n" +
                "       UseForRef='TRUE'\r\n" +
                "       DefaultCaption='СЗ_ЗАМЕЧАНИЕ'\r\n" +
                "       FormulaName='СЗ_ЗАМЕЧАНИЕ'\r\n" +
                "       Sequence='SEQ_SR_REMARK_SRRM'\r\n" +
                "       DefaultEntityClass='SrRemarkEntity'\r\n" +
                "       LookupKeyFields='Default'\r\n" +
                LookupResultAgg +

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
                "                  Params='@IPID_SR_REMARK_SRRM'\r\n" +
                "    >\r\n" +
                "      <Conditions>\r\n" +
                "        <Condition>SR_REMARK_SRRM.ID_SR_REMARK_SRRM = :PID_SR_REMARK_SRRM</Condition>\r\n" +
                "      </Conditions>\r\n" +
                "    </Selection>\r\n" +
                "    <Selection Name='ByIdParent'\r\n" +
                "                  DefaultCaption='По Id родительского задания'\r\n" +
                "                  Params='@IPID'\r\n" +
                "                  IsList='True'\r\n" +
                "    >\r\n" +
                "      <Conditions>\r\n" +
                "        <Condition>SR_REMARK_SRRM.PARENT_REMARK_SRRM = :PID</Condition>\r\n" +
                "      </Conditions>\r\n" +
                "    </Selection>\r\n" +
                "    <Selection Name='DistinctColumn'\r\n" +
                "                  DefaultCaption='Одна колонка'\r\n" +
                "                  IsList='True'\r\n" +
                "    >\r\n" +
                "    </Selection>\r\n" +
                "  </Selections>\r\n" +
                "  <Attributes>\r\n" +
                "    <Attribute Name='ID_SR_REMARK_SRRM'\r\n" +
                "             RusName='ID задания'\r\n" +
                "             FormulaName='ID_ЗАМЕЧАНИЕ'\r\n" +
                "             ReadOnly='true'\r\n" +
                "             DisableUserEdit='true'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='ID_SR_R_PROJECT_SRRM'\r\n" +
                "             RusName='ID проекта'\r\n" +
                "             FormulaName='ID_ПРОЕКТА'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='NUMBER_PP_SRRM'\r\n" +
                "             RusName='№ п/п'\r\n" +
                "             FormulaName='№_П_П'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='DATE_CREATE_SRRM'\r\n" +
                "             RusName='Дата создания'\r\n" +
                "             FormulaName='ДАТА_СОЗДАНИЯ'\r\n" +
                "             DataType='Date'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='REMARK_SRRM'\r\n" +
                "             RusName='Текст задания'\r\n" +
                "             FormulaName='ТЕКСТ_ЗАМЕЧАНИЯ'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='ID_SR_R_STATUS_SRRM'\r\n" +
                "             RusName='ID статус'\r\n" +
                "             FormulaName='ID_СТАТУС'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='COMMENT_EXECUT_SRRM'\r\n" +
                "             RusName='Комментарий исполнителя'\r\n" +
                "             FormulaName='КОММЕНТАРИЙ_ИСПОЛНИТЕЛЯ'\r\n" +
                "    />\r\n" +

                "    <Attribute Name='DATE_COMPLETE_SRRM'\r\n" +
                "             RusName='Плановый срок выполнения'\r\n" +
                "             FormulaName='ПЛАНОВЫЙ_СРОК_ВЫПОЛНЕНИЯ'\r\n" +
                "             DataType='Date'\r\n" +
                "    />\r\n" +

                "    <Attribute Name='ID_FROM_WHOM_SRRM'\r\n" +
                "             RusName='От кого'\r\n" +
                "             FormulaName='ОТ_КОГО'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='ID_WHOM_SRRM'\r\n" +
                "             RusName='Кому'\r\n" +
                "             FormulaName='КОМУ'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='ID_SR_R_PROMPTNESS_SRRM'\r\n" +
                "             RusName='ID срочности'\r\n" +
                "             FormulaName='ID_СРОЧНОСТИ'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='NAME_DB_SRRM'\r\n" +
                "             RusName='База данных'\r\n" +
                "             FormulaName='БАЗА_ДАННЫХ'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='PROGRAM_SRRM'\r\n" +
                "             RusName='Программа'\r\n" +
                "             FormulaName='ПРОГРАММА'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='PLACE_ERROR_SRRM'\r\n" +
                "             RusName='Место возникновения ошибки'\r\n" +
                "             FormulaName='МЕСТО_ВОЗНИКНОВЕНИЯ_ОШИБКИ'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='LINK_SRRM'\r\n" +
                "             RusName='Ссылка на документ или скриншот'\r\n" +
                "             FormulaName='ССЫЛКА_НА_ДОКУМЕНТ_ИЛИ_СКРИНШОТ'\r\n" +
                "             is_hyperlink='true'" +
                "    />\r\n" +
                "    <Attribute Name='PARENT_REMARK_SRRM'\r\n" +
                "             RusName='Замечание-родитель'\r\n" +
                "             FormulaName='ЗАМЕЧАНИЕ_РОДИТЕЛЬ'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='DATE_EXECUTE_SRRM'\r\n" +
                "             RusName='Дата выполнения'\r\n" +
                "             FormulaName='ДАТА_ВЫПОЛНЕНИЯ'\r\n" +
                "             DataType='Date'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='DATE_CHECKED_SRRM'\r\n" +
                "             RusName='Дата приемки'\r\n" +
                "             FormulaName='ДАТА_ПРИЕМКИ'\r\n" +
                "             DataType='Date'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='IsFavorite'\r\n" +
                "             RusName='В избранном'\r\n" +
                "             FormulaName='В_ИЗБРАННОМ'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='VVOD_ID_CONTRACTOR_SRRM'\r\n" +
                "             RusName='Автор ввода'\r\n" +
                "             FormulaName='АВТОР_ВВОДА'\r\n" +
                "             DisableUserEdit='true'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='CHANGE_ID_CONTRACTOR_SRRM'\r\n" +
                "             RusName='Автор изменения'\r\n" +
                "             FormulaName='АВТОР_ИЗМЕНЕНИЯ'\r\n" +
                "             DisableUserEdit='true'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='DATE_INPUT_SRRM'\r\n" +
                "             RusName='Дата ввода'\r\n" +
                "             FormulaName='ДАТА_ВВОДА'\r\n" +
                "             DisableUserEdit='true'\r\n" +
                "             DataType='DateTime'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='DATE_CHANGE_SRRM'\r\n" +
                "             RusName='Дата изменения'\r\n" +
                "             FormulaName='ДАТА_ИЗМЕНЕНИЯ'\r\n" +
                "             DisableUserEdit='true'\r\n" +
                "             DataType='DateTime'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='FROM_WHOM_SRRM_NAME'\r\n" +
                "             Type='Lookup'\r\n" +
                "             UseIn='Default;FullList;ById;ByIdParent;DistinctColumn'\r\n" +
                "             ClassName='SrRExecutiveData'\r\n" +
                "             KeyField='ID_FROM_WHOM_SRRM'\r\n" +
                "             RefAlias='ra_FROM_WHOM'\r\n" +
                "             RusName='Автор задания'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='WHOM_SRRM_NAME'\r\n" +
                "             Type='Lookup'\r\n" +
                "             UseIn='Default;FullList;ById;ByIdParent;DistinctColumn'\r\n" +
                "             ClassName='SrRExecutiveData'\r\n" +
                "             KeyField='ID_WHOM_SRRM'\r\n" +
                "             RefAlias='ra_WHOM'\r\n" +
                "             RusName='Исполнитель задания'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='SR_R_PROJECT_SRRM_NAME'\r\n" +
                "             Type='Lookup'\r\n" +
                "             UseIn='Default;FullList;ById;ByIdParent;DistinctColumn'\r\n" +
                "             ClassName='SrRProjectData'\r\n" +
                "             KeyField='ID_SR_R_PROJECT_SRRM'\r\n" +
                "             RusName='Проект'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='SR_R_PROMPTNESS_SRRM_NAME'\r\n" +
                "             Type='Lookup'\r\n" +
                "             UseIn='Default;FullList;ById;ByIdParent;DistinctColumn'\r\n" +
                "             ClassName='SrRPromptnessData'\r\n" +
                "             KeyField='ID_SR_R_PROMPTNESS_SRRM'\r\n" +
                "             RusName='Срочность'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='SR_R_STATUS_SRRM_NAME'\r\n" +
                "             Type='Lookup'\r\n" +
                "             UseIn='Default;FullList;ById;ByIdParent;DistinctColumn'\r\n" +
                "             ClassName='SrRStatusData'\r\n" +
                "             KeyField='ID_SR_R_STATUS_SRRM'\r\n" +
                "             RusName='Статус'\r\n" +
                "    />\r\n" +
                "    <Attribute Name='PARENT_REMARK_SRRM_NAME'\r\n" +
                "             Type='Lookup'\r\n" +
                "             UseIn='Default;FullList;ById;ByIdParent;DistinctColumn'\r\n" +
                "             ClassName='SrRemarkData'\r\n" +
                "             KeyField='PARENT_REMARK_SRRM'\r\n" +
                "             RusName='Задание-родитель'\r\n" +
                "    />\r\n" +
                "  </Attributes>\r\n" +
                "  <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20110317' />\r\n" +
                "  <Comment>..</Comment>\r\n" +
                "</Class>"
                ;
        }

        #region атрибуты выборки

        //  ( в первоначальной редакции не учтены вычисляемые атрибуты. Их можно добавить вручную)
        private s_DataColumn _attrIdSrRemark;

        public s_DataColumn AttrIdSrRemark
        {
            get
            {
                if (_attrIdSrRemark == null)
                    _attrIdSrRemark = Attributes[SrRemarkEntity.ColumnIdSrRemark];
                return _attrIdSrRemark;
            }
        }

        private s_DataColumn _attrIdSrRProject;

        public s_DataColumn AttrIdSrRProject
        {
            get
            {
                if (_attrIdSrRProject == null)
                    _attrIdSrRProject = Attributes[SrRemarkEntity.ColumnIdSrRProject];
                return _attrIdSrRProject;
            }
        }

        private s_DataColumn _attrDateCreate;

        public s_DataColumn AttrDateCreate
        {
            get
            {
                if (_attrDateCreate == null)
                    _attrDateCreate = Attributes[SrRemarkEntity.ColumnDateCreate];
                return _attrDateCreate;
            }
        }

        private s_DataColumn _attrNumberPp;

        public s_DataColumn AttrNumberPp
        {
            get
            {
                if (_attrNumberPp == null)
                    _attrNumberPp = Attributes[SrRemarkEntity.ColumnNumberPp];
                return _attrNumberPp;
            }
        }

        private s_DataColumn _attrIdFromWhom;

        public s_DataColumn AttrIdFromWhom
        {
            get
            {
                if (_attrIdFromWhom == null)
                    _attrIdFromWhom = Attributes[SrRemarkEntity.ColumnIdFromWhom];
                return _attrIdFromWhom;
            }
        }

        private s_DataColumn _attrIdWhom;

        public s_DataColumn AttrIdWhom
        {
            get
            {
                if (_attrIdWhom == null)
                    _attrIdWhom = Attributes[SrRemarkEntity.ColumnIdWhom];
                return _attrIdWhom;
            }
        }

        private s_DataColumn _attrIdSrRPromptness;

        public s_DataColumn AttrIdSrRPromptness
        {
            get
            {
                if (_attrIdSrRPromptness == null)
                    _attrIdSrRPromptness = Attributes[SrRemarkEntity.ColumnIdSrRPromptness];
                return _attrIdSrRPromptness;
            }
        }

        private s_DataColumn _attrNameDb;

        public s_DataColumn AttrNameDb
        {
            get
            {
                if (_attrNameDb == null)
                    _attrNameDb = Attributes[SrRemarkEntity.ColumnNameDb];
                return _attrNameDb;
            }
        }

        private s_DataColumn _attrProgram;

        public s_DataColumn AttrProgram
        {
            get
            {
                if (_attrProgram == null)
                    _attrProgram = Attributes[SrRemarkEntity.ColumnProgram];
                return _attrProgram;
            }
        }

        private s_DataColumn _attrPlaceError;

        public s_DataColumn AttrPlaceError
        {
            get
            {
                if (_attrPlaceError == null)
                    _attrPlaceError = Attributes[SrRemarkEntity.ColumnPlaceError];
                return _attrPlaceError;
            }
        }

        private s_DataColumn _attrRemark;

        public s_DataColumn AttrRemark
        {
            get
            {
                if (_attrRemark == null)
                    _attrRemark = Attributes[SrRemarkEntity.ColumnRemark];
                return _attrRemark;
            }
        }

        private s_DataColumn _attrLink;

        public s_DataColumn AttrLink
        {
            get
            {
                if (_attrLink == null)
                    _attrLink = Attributes[SrRemarkEntity.ColumnLink];
                return _attrLink;
            }
        }

        private s_DataColumn _attrCommentExecut;

        public s_DataColumn AttrCommentExecut
        {
            get
            {
                if (_attrCommentExecut == null)
                    _attrCommentExecut = Attributes[SrRemarkEntity.ColumnCommentExecut];
                return _attrCommentExecut;
            }
        }

        private s_DataColumn _attrDateExecute;

        public s_DataColumn AttrDateExecute
        {
            get
            {
                if (_attrDateExecute == null)
                    _attrDateExecute = Attributes[SrRemarkEntity.ColumnDateExecute];
                return _attrDateExecute;
            }
        }

        private s_DataColumn _attrDateChecked;

        public s_DataColumn AttrDateChecked
        {
            get
            {
                if (_attrDateChecked == null)
                    _attrDateChecked = Attributes[SrRemarkEntity.ColumnDateChecked];
                return _attrDateChecked;
            }
        }

        private s_DataColumn _attrIdSrRStatus;

        public s_DataColumn AttrIdSrRStatus
        {
            get
            {
                if (_attrIdSrRStatus == null)
                    _attrIdSrRStatus = Attributes[SrRemarkEntity.ColumnIdSrRStatus];
                return _attrIdSrRStatus;
            }
        }

        private s_DataColumn _attrVvodIdContractor;

        public s_DataColumn AttrVvodIdContractor
        {
            get
            {
                if (_attrVvodIdContractor == null)
                    _attrVvodIdContractor = Attributes[SrRemarkEntity.ColumnVvodIdContractor];
                return _attrVvodIdContractor;
            }
        }

        private s_DataColumn _attrChangeIdContractor;

        public s_DataColumn AttrChangeIdContractor
        {
            get
            {
                if (_attrChangeIdContractor == null)
                    _attrChangeIdContractor = Attributes[SrRemarkEntity.ColumnChangeIdContractor];
                return _attrChangeIdContractor;
            }
        }

        private s_DataColumn _attrDateInput;

        public s_DataColumn AttrDateInput
        {
            get
            {
                if (_attrDateInput == null)
                    _attrDateInput = Attributes[SrRemarkEntity.ColumnDateInput];
                return _attrDateInput;
            }
        }

        private s_DataColumn _attrDateChange;

        public s_DataColumn AttrDateChange
        {
            get
            {
                if (_attrDateChange == null)
                    _attrDateChange = Attributes[SrRemarkEntity.ColumnDateChange];
                return _attrDateChange;
            }
        }

        private s_DataColumn _attrFromWhomName;

        public s_DataColumn AttrFromWhomName
        {
            get
            {
                if (_attrFromWhomName == null)
                    _attrFromWhomName = Attributes[SrRemarkEntity.ColumnFromWhomName];
                return _attrFromWhomName;
            }
        }

        private s_DataColumn _attrWhomName;

        public s_DataColumn AttrWhomName
        {
            get
            {
                if (_attrWhomName == null)
                    _attrWhomName = Attributes[SrRemarkEntity.ColumnWhomName];
                return _attrWhomName;
            }
        }

        private s_DataColumn _attrSrRProjectName;

        public s_DataColumn AttrSrRProjectName
        {
            get
            {
                if (_attrSrRProjectName == null)
                    _attrSrRProjectName = Attributes[SrRemarkEntity.ColumnSrRProjectName];
                return _attrSrRProjectName;
            }
        }

        private s_DataColumn _attrSrRPromptnessName;

        public s_DataColumn AttrSrRPromptnessName
        {
            get
            {
                if (_attrSrRPromptnessName == null)
                    _attrSrRPromptnessName = Attributes[SrRemarkEntity.ColumnSrRPromptnessName];
                return _attrSrRPromptnessName;
            }
        }

        private s_DataColumn _attrSrRStatusName;

        public s_DataColumn AttrSrRStatusName
        {
            get
            {
                if (_attrSrRStatusName == null)
                    _attrSrRStatusName = Attributes[SrRemarkEntity.ColumnSrRStatusName];
                return _attrSrRStatusName;
            }
        }

        private s_DataColumn _attrParentRemarkSrrm;

        public s_DataColumn AttrParentRemarkSrrm
        {
            get
            {
                if (_attrParentRemarkSrrm == null)
                    _attrParentRemarkSrrm = Attributes[SrRemarkEntity.ColumnParentRemarkSrrm];
                return _attrParentRemarkSrrm;
            }
        }

        private s_DataColumn _attrParentRemarkSrrmName;

        public s_DataColumn AttrParentRemarkSrrmName
        {
            get
            {
                if (_attrParentRemarkSrrmName == null)
                    _attrParentRemarkSrrmName = Attributes[SrRemarkEntity.ColumnParentRemarkSrrmName];
                return _attrParentRemarkSrrmName;
            }
        }

        #endregion

        protected override void OnLookupShowing(s_LookupShowingEventArgs e)
        {
            if (e.LookupName.SameStr(SrRemarkEntity.ColumnParentRemarkSrrmName))
            {
                string currID = AttrIdSrRemark[e.Row].ObjToStr();
                string cond = SrRemarkEntity.ColumnIdSrRemark + " <> " + currID;
                if (!ClassInfo.TableAlias.IsEmpty())
                {
                    cond = ClassInfo.TableAlias + "." + cond;
                }

                GraphEntity ent = e.RefData.Entity as GraphEntity;
                if (ent != null)
                {
                    int self_Proj = AttrIdSrRProject[e.Row].ObjToID();
                    if (self_Proj > 0)
                    {
                        ent.ShowDataParams[Const.par_node_value + "0"] = self_Proj;

                        //string cond_same_Proj = SrRemarkEntity.ColumnIdSrRProject + " = " + self_Proj.ToString();
                        //if (!ClassInfo.TableAlias.is_empty())
                        //    cond_same_Proj = ClassInfo.TableAlias + "." + cond_same_Proj;
                        //e.RefData.Add_Condition("same_project", cond_same_Proj);
                    }

                    string parID = AttrParentRemarkSrrm[e.Row].ObjToStr();
                    if (!parID.IsEmpty())
                    {
                        ent.ShowDataParams[Const.par_node_value + "11"] = parID;
                    }
                }

                e.RefData.AddCondition("not_same", cond);
            }
            base.OnLookupShowing(e);
        }

        #region методы для взаимодействия с ObjectDataSource (WebForms)

        public void InsertInstance(SrRemarkEntityInstance instance)
        {
        }

        public void DeleteInstance(SrRemarkEntityInstance instance)
        {
        }

        public void UpdateInstance(SrRemarkEntityInstance instance)
        {
        }

        #endregion

    }

    public class SrRemarkEntityInstance : s_EntityInstance
    {
        #region конструкторы

        public SrRemarkEntityInstance()
            : this(null)
        {
        }

        public SrRemarkEntityInstance(DataRow row)
            : base(row)
        {
        }

        #endregion

        #region актуализация типов ссылок на класс-сущность и дата-класс

        public new SrRemarkEntity Entity
        {
            [DebuggerStepThrough]
            get { return (SrRemarkEntity)base.Entity; }
        }

        public new SrRemarkData Data
        {
            [DebuggerStepThrough]
            get { return (SrRemarkData)base.Data; }
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

        public Int32? ID_SR_REMARK_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return IdSrRemark; }
            [DebuggerStepThrough]
            set { IdSrRemark = value; }
        }

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

        public Int32? ID_SR_R_PROJECT_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return IdSrRProject; }
            [DebuggerStepThrough]
            set { IdSrRProject = value; }
        }

        private DateTime? _dateCreate;

        public DateTime? DateCreate
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrDateCreate[Row] as DateTime?;
                else
                    return _dateCreate;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrDateCreate[Row] = value;
                else
                    _dateCreate = value;
            }
        }

        public DateTime? DATE_CREATE_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return DateCreate; }
            [DebuggerStepThrough]
            set { DateCreate = value; }
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

        public Int32? NUMBER_PP_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return NumberPp; }
            [DebuggerStepThrough]
            set { NumberPp = value; }
        }

        private Int32? _idFromWhom;

        public Int32? IdFromWhom
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrIdFromWhom[Row] as Int32?;
                else
                    return _idFromWhom;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrIdFromWhom[Row] = value;
                else
                    _idFromWhom = value;
            }
        }

        public Int32? ID_FROM_WHOM_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return IdFromWhom; }
            [DebuggerStepThrough]
            set { IdFromWhom = value; }
        }

        private Int32? _idWhom;

        public Int32? IdWhom
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrIdWhom[Row] as Int32?;
                else
                    return _idWhom;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrIdWhom[Row] = value;
                else
                    _idWhom = value;
            }
        }

        public Int32? ID_WHOM_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return IdWhom; }
            [DebuggerStepThrough]
            set { IdWhom = value; }
        }

        private Int32? _idSrRPromptness;

        public Int32? IdSrRPromptness
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrIdSrRPromptness[Row] as Int32?;
                else
                    return _idSrRPromptness;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrIdSrRPromptness[Row] = value;
                else
                    _idSrRPromptness = value;
            }
        }

        public Int32? ID_SR_R_PROMPTNESS_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return IdSrRPromptness; }
            [DebuggerStepThrough]
            set { IdSrRPromptness = value; }
        }

        private String _nameDb;

        public String NameDb
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrNameDb[Row] as String;
                else
                    return _nameDb;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrNameDb[Row] = value;
                else
                    _nameDb = value;
            }
        }

        public String NAME_DB_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return NameDb; }
            [DebuggerStepThrough]
            set { NameDb = value; }
        }

        private String _program;

        public String Program
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrProgram[Row] as String;
                else
                    return _program;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrProgram[Row] = value;
                else
                    _program = value;
            }
        }

        public String PROGRAM_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return Program; }
            [DebuggerStepThrough]
            set { Program = value; }
        }

        private String _placeError;

        public String PlaceError
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrPlaceError[Row] as String;
                else
                    return _placeError;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrPlaceError[Row] = value;
                else
                    _placeError = value;
            }
        }

        public String PLACE_ERROR_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return PlaceError; }
            [DebuggerStepThrough]
            set { PlaceError = value; }
        }

        private String _remark;

        public String Remark
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrRemark[Row] as String;
                else
                    return _remark;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrRemark[Row] = value;
                else
                    _remark = value;
            }
        }

        public String REMARK_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return Remark; }
            [DebuggerStepThrough]
            set { Remark = value; }
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

        public String LINK_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return Link; }
            [DebuggerStepThrough]
            set { Link = value; }
        }

        private String _commentExecut;

        public String CommentExecut
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrCommentExecut[Row] as String;
                else
                    return _commentExecut;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrCommentExecut[Row] = value;
                else
                    _commentExecut = value;
            }
        }

        public String COMMENT_EXECUT_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return CommentExecut; }
            [DebuggerStepThrough]
            set { CommentExecut = value; }
        }

        private DateTime? _dateExecute;

        public DateTime? DateExecute
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrDateExecute[Row] as DateTime?;
                else
                    return _dateExecute;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrDateExecute[Row] = value;
                else
                    _dateExecute = value;
            }
        }

        public DateTime? DATE_EXECUTE_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return DateExecute; }
            [DebuggerStepThrough]
            set { DateExecute = value; }
        }

        private DateTime? _dateChecked;

        public DateTime? DateChecked
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrDateChecked[Row] as DateTime?;
                else
                    return _dateChecked;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrDateChecked[Row] = value;
                else
                    _dateChecked = value;
            }
        }

        public DateTime? DATE_CHECKED_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return DateChecked; }
            [DebuggerStepThrough]
            set { DateChecked = value; }
        }

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

        public Int32? ID_SR_R_STATUS_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return IdSrRStatus; }
            [DebuggerStepThrough]
            set { IdSrRStatus = value; }
        }

        private Int32? _parentRemark;

        public Int32? ParentRemark
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrParentRemarkSrrm[Row] as Int32?;
                else
                    return _parentRemark;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrParentRemarkSrrm[Row] = value;
                else
                    _parentRemark = value;
            }
        }

        public Int32? PARENT_REMARK_SRRM
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return ParentRemark; }
            [DebuggerStepThrough]
            set { ParentRemark = value; }
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

        public String VVOD_ID_CONTRACTOR_SRRM
        {
            //Web-доступ
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

        public String CHANGE_ID_CONTRACTOR_SRRM
        {
            //Web-доступ
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

        public DateTime? DATE_INPUT_SRRM
        {
            //Web-доступ
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

        public DateTime? DATE_CHANGE_SRRM
        {
            //Web-доступ
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
        private string _fromWhomName;

        public string FromWhomName
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrFromWhomName[Row] as string;
                else
                    return _fromWhomName;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrFromWhomName[Row] = value;
                else
                    _fromWhomName = value;
            }
        }

        public string FROM_WHOM_SRRM_NAME
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return FromWhomName; }
            [DebuggerStepThrough]
            set { FromWhomName = value; }
        }

        private string _whomName;

        public string WhomName
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrWhomName[Row] as string;
                else
                    return _whomName;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrWhomName[Row] = value;
                else
                    _whomName = value;
            }
        }

        public string WHOM_SRRM_NAME
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return WhomName; }
            [DebuggerStepThrough]
            set { WhomName = value; }
        }

        private string _srRProjectName;

        public string SrRProjectName
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrSrRProjectName[Row] as string;
                else
                    return _srRProjectName;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrSrRProjectName[Row] = value;
                else
                    _srRProjectName = value;
            }
        }

        public string SR_R_PROJECT_SRRM_NAME
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return SrRProjectName; }
            [DebuggerStepThrough]
            set { SrRProjectName = value; }
        }

        private string _srRPromptnessName;

        public string SrRPromptnessName
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrSrRPromptnessName[Row] as string;
                else
                    return _srRPromptnessName;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrSrRPromptnessName[Row] = value;
                else
                    _srRPromptnessName = value;
            }
        }

        public string SR_R_PROMPTNESS_SRRM_NAME
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return SrRPromptnessName; }
            [DebuggerStepThrough]
            set { SrRPromptnessName = value; }
        }

        private string _srRStatusName;

        public string SrRStatusName
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrSrRStatusName[Row] as string;
                else
                    return _srRStatusName;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrSrRStatusName[Row] = value;
                else
                    _srRStatusName = value;
            }
        }

        public string SR_R_STATUS_SRRM_NAME
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return SrRStatusName; }
            [DebuggerStepThrough]
            set { SrRStatusName = value; }
        }

        private string _parentRemarkName;

        public string ParentRemarkName
        {
            [DebuggerStepThrough]
            get
            {
                if (Row != null)
                    return Data.AttrParentRemarkSrrmName[Row] as string;
                else
                    return _parentRemarkName;
            }
            [DebuggerStepThrough]
            set
            {
                if (Row != null)
                    Data.AttrParentRemarkSrrmName[Row] = value;
                else
                    _parentRemarkName = value;
            }
        }

        public string PARENT_REMARK_SRRM_NAME
        {
            //Web-доступ
            [DebuggerStepThrough]
            get { return ParentRemarkName; }
            [DebuggerStepThrough]
            set { ParentRemarkName = value; }
        }

        #endregion
    }

    public class SrRemarkEntity : GraphEntity, IEnumerable<SrRemarkEntityInstance>
    {

        #region проход по строкам выборки дата-класса

        public IEnumerator<SrRemarkEntityInstance> GetEnumerator()
        {
            if (Data.Active)
            {
                SrRemarkEntityInstance el;
                DataRowCollection __rows = Data.Table.Rows;
                foreach (DataRow row in __rows)
                {
                    el = new SrRemarkEntityInstance(row);
                    yield return el;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region конструкторы

        public SrRemarkEntity()
            : this(s_DbConnection.CurrentConnectionName)
        {
        }

        public SrRemarkEntity(string pConnectionName)
            : base(pConnectionName)
        {
            SimpleNumerator sm = new SimpleNumerator();
            sm.PrepareNumerator(this, "NUMBER_PP_SRRM", "ID_SR_R_PROJECT_SRRM;DATE_CREATE_SRRM");

            WriteToLog = true;
        }

        #endregion

        #region xml-схема класса

        public static string GetXml()
        {
            return
                "<Class\r\n" +
                "       DefaultCaption='СЗ_ЗАМЕЧАНИЕ'\r\n" +
                "       DefaultDataClass='SrRemarkData'\r\n" +
                "       InstanceClass='SrRemarkEntityInstance'\r\n" +
                ">\r\n" +

                "  <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20110317' />\r\n" +
                "  <Comment>. . .</Comment>\r\n" +
                "</Class>"
                ;
        }
        #endregion

        #region встроенный объект SrRemarkEntityInstance

        //Создается при первом обращении
        private SrRemarkEntityInstance _entityInstance;

        public SrRemarkEntityInstance Instance
        {
            get
            {
                if (_entityInstance == null)
                    _entityInstance = new SrRemarkEntityInstance();
                return _entityInstance;
            }
        }

        #endregion

        #region константы

        public static string TableName
        {
            get
            {
                return "SR_REMARK_SRRM".ToFullObjectName(s_DatabaseObjectType.Table);
            }
        }

        // Имена атрибутов (колонок выборки)
        //  (в первоначальной редакции не учтены вычисляемые атрибуты. Их можно добавить вручную)
        public static readonly string ColumnIdSrRemark = "ID_SR_REMARK_SRRM";
        public static readonly string ColumnIdSrRProject = "ID_SR_R_PROJECT_SRRM";
        public static readonly string ColumnDateCreate = "DATE_CREATE_SRRM";
        public static readonly string ColumnNumberPp = "NUMBER_PP_SRRM";
        public static readonly string ColumnIdFromWhom = "ID_FROM_WHOM_SRRM";
        public static readonly string ColumnIdWhom = "ID_WHOM_SRRM";
        public static readonly string ColumnIdSrRPromptness = "ID_SR_R_PROMPTNESS_SRRM";
        public static readonly string ColumnNameDb = "NAME_DB_SRRM";
        public static readonly string ColumnProgram = "PROGRAM_SRRM";
        public static readonly string ColumnPlaceError = "PLACE_ERROR_SRRM";
        public static readonly string ColumnRemark = "REMARK_SRRM";
        public static readonly string ColumnLink = "LINK_SRRM";
        public static readonly string ColumnCommentExecut = "COMMENT_EXECUT_SRRM";
        public static readonly string ColumnDateExecute = "DATE_EXECUTE_SRRM";
        public static readonly string ColumnDateChecked = "DATE_CHECKED_SRRM";
        public static readonly string ColumnIdSrRStatus = "ID_SR_R_STATUS_SRRM";
        public static readonly string ColumnVvodIdContractor = "VVOD_ID_CONTRACTOR_SRRM";
        public static readonly string ColumnChangeIdContractor = "CHANGE_ID_CONTRACTOR_SRRM";
        public static readonly string ColumnDateInput = "DATE_INPUT_SRRM";
        public static readonly string ColumnDateChange = "DATE_CHANGE_SRRM";
        public static readonly string ColumnFromWhomName = "FROM_WHOM_SRRM_NAME";
        public static readonly string ColumnWhomName = "WHOM_SRRM_NAME";
        public static readonly string ColumnSrRProjectName = "SR_R_PROJECT_SRRM_NAME";
        public static readonly string ColumnSrRPromptnessName = "SR_R_PROMPTNESS_SRRM_NAME";
        public static readonly string ColumnSrRStatusName = "SR_R_STATUS_SRRM_NAME";
        public static readonly string ColumnParentRemarkSrrm = "PARENT_REMARK_SRRM";
        public static readonly string ColumnParentRemarkSrrmName = "PARENT_REMARK_SRRM_NAME";
        public static readonly string ColumnDateComplete = "DATE_COMPLETE_SRRM";
        public static readonly string ColumnIsFavorite = "IsFavorite";

        #endregion

        #region заготовки для перекрытия методов

        protected override void OnInstanceCreating(s_EntityInstanceCreatingEventArgs e)
        {
            base.OnInstanceCreating(e);

            int? ID_logined_executor = -1;
            string executor_name = "";

            SrRExecutiveEntity E_SREX = new SrRExecutiveEntity();
            E_SREX.ByLogin(s_UserEntity.Login, s_EntityAction.Open);
            if (E_SREX.Data.Rows.Count > 0)
            {
                E_SREX.Instance.Row = E_SREX.Data.Rows[0];
                ID_logined_executor = E_SREX.Instance.IdSrRExecutive;
                executor_name = E_SREX.Instance.Fio;
            }
            E_SREX.Data.Close();
            E_SREX.Dispose();

            this.Instance.Row = e.Row;

            if (ID_logined_executor > 0)
            {
                this.Instance.IdFromWhom = ID_logined_executor;
                this.Instance.FromWhomName = executor_name;
            }

            if (Instance.IdSrRStatus.ObjToID() <= 0 && ID_of_Vydano_status > 0)
            {
                this.Instance.IdSrRStatus = ID_of_Vydano_status;
            }

            if (ID_of_Default_promptness > 0)
            {
                this.Instance.IdSrRPromptness = ID_of_Default_promptness;
            }

            this.Instance.DateCreate = s_DbConnection.Connections[s_DbConnection.CurrentConnectionName].GetServerTime().ToShortDateString().ObjToDateTime();//DateTime.Now;

            e.Row[ColumnIsFavorite] = "Н";
            Func.RefreshJoins(Data, e.Row, true);
        }

        protected override void OnColumnChanged(s_ColumnChangedEventArgs e)
        {
            base.OnColumnChanged(e);

            if (e.Attribute.Name.SameStr(ColumnIdSrRStatus))
            {
                Instance.Row = e.Row;
                int? curr_ID_status = Instance.IdSrRStatus;

                if (curr_ID_status == ID_of_Vypolneno_status
                    && Instance.DateExecute == null)
                {
                    Instance.DateExecute = DateTime.Now;
                }

                if (curr_ID_status == ID_of_Prinato_status
                    && Instance.DateChecked == null)
                {
                    Instance.DateChecked = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// ИД выполнено
        /// </summary>
        private int ID_of_Vypolneno_status
        {
            get
            {
                int result = -1;
                SrRStatusEntity E_SRST = new SrRStatusEntity();
                E_SRST.ByNPP(3, s_EntityAction.Open);
                if (E_SRST.Data.Rows.Count > 0)
                {
                    E_SRST.Instance.Row = E_SRST.Data.Rows[0];
                    result = E_SRST.Instance.IdSrRStatus.ObjToID();
                }
                E_SRST.Data.Close();
                E_SRST.Dispose();

                return result;
            }
        }

        /// <summary>
        /// ИД принято
        /// </summary>
        private int ID_of_Prinato_status
        {
            get
            {
                int result = -1;
                SrRStatusEntity E_SRST = new SrRStatusEntity();
                E_SRST.ByNPP(5, s_EntityAction.Open);
                if (E_SRST.Data.Rows.Count > 0)
                {
                    E_SRST.Instance.Row = E_SRST.Data.Rows[0];
                    result = E_SRST.Instance.IdSrRStatus.ObjToID();
                }
                E_SRST.Data.Close();
                E_SRST.Dispose();

                return result;
            }
        }

        /// <summary>
        /// ИД выдано
        /// </summary>
        private int ID_of_Vydano_status
        {
            get
            {
                int result = -1;
                SrRStatusEntity E_SRST = new SrRStatusEntity();
                E_SRST.ByNPP(1, s_EntityAction.Open);
                if (E_SRST.Data.Rows.Count > 0)
                {
                    E_SRST.Instance.Row = E_SRST.Data.Rows[0];
                    result = E_SRST.Instance.IdSrRStatus.ObjToID();
                }
                E_SRST.Data.Close();
                E_SRST.Dispose();

                return result;
            }
        }

        /// <summary>
        /// ID срочности по умолчанию (Оч.3)
        /// </summary>
        private int ID_of_Default_promptness
        {
            get
            {
                SrRPromptnessEntity E_SRPR = new SrRPromptnessEntity();
                if (E_SRPR == null) return -1;

                int result = -1;
                E_SRPR.ByNPP(4, s_EntityAction.Open);
                if (E_SRPR.Data.Rows.Count > 0)
                {
                    E_SRPR.Instance.Row = E_SRPR.Data.Rows[0];
                    result = E_SRPR.Instance.IdSrRPromptness.ObjToID();
                }
                E_SRPR.Data.Close();
                E_SRPR.Dispose();

                return result;
            }
        }

        MethodInfo miSendMessage = null;
        Type _typeJabberClient = null;
        Type typeJabberClient
        {
            get
            {
                if (_typeJabberClient == null)
                {
                    _typeJabberClient = Type.GetType("ClientJabberService.JabberService.JabberClient, ClientJabberService", false, true);
                    if (_typeJabberClient != null)
                    {
                        miSendMessage = _typeJabberClient.GetMethod("SendMessage", new[] { typeof(String), typeof(String) });
                    }
                }
                return _typeJabberClient;
            }
        }

        //private JabberClient _jabberClient;
        private object _jabberClient;

        //public JabberClient JabberClient
        /// <summary>
        /// JabberClient, отвечающий за рассылку в чат компании сообщений об выполненых/узмененных заданиях
        /// </summary>
        public object JabberClient
        {
            get
            {
                try
                {
                    if (typeJabberClient == null) return null;

                    if (_jabberClient == null)
                    {
                        _jabberClient = Activator.CreateInstance(typeJabberClient);
                        //_jabberClient = new JabberClient();
                    }

                    PropertyInfo piInnerChannel = typeJabberClient.GetProperty("InnerChannel");
                    System.ServiceModel.IClientChannel InnerChannel = piInnerChannel.GetValue(_jabberClient, null) as System.ServiceModel.IClientChannel;
                    PropertyInfo piState = typeJabberClient.GetProperty("State");

                    ClientJabberService.JabberService.JabberClient cl = new ClientJabberService.JabberService.JabberClient();

                    CommunicationState State = (CommunicationState)piState.GetValue(_jabberClient, null);
                    CommunicationState InnerChannelState = InnerChannel.State;

                    //if (_jabberClient.InnerChannel.State == CommunicationState.Faulted
                    //    || (_jabberClient.State != CommunicationState.Opened
                    //        && _jabberClient.State != CommunicationState.Created))
                    if (InnerChannelState == CommunicationState.Faulted || State != CommunicationState.Opened && State != CommunicationState.Created)
                    {
                        _jabberClient = Activator.CreateInstance(typeJabberClient);
                        //_jabberClient = new JabberClient();
                    }
                    return _jabberClient;
                }
                catch
                {
                    _jabberClient = null;
                }
                return null;
            }

        }

        // Важный момент, теперь e.Row может вообще не принадлежать выборке (Data), 
        // т.о. нельзя делать Instance.Row = e.Row; 
        protected override void OnInstanceValidating(s_EntityInstanceValidatingEventArgs e)
        {
            base.OnInstanceValidating(e);
            if (e.Cancel) return;

            int curr_status_NPP = -1;
            int curr_status_ID = e.Row[ColumnIdSrRStatus].ObjToID();
            string curr_status_name = e.Row[ColumnSrRStatusName].ObjToStr();

            if (curr_status_ID <= 0) return;

            int currId = e.Row[ColumnIdSrRemark].ObjToID();
            int parId = e.Row[ColumnParentRemarkSrrm].ObjToID();

            s_DbCommand dbc = new s_DbCommand();
            dbc.CommandText = "select PARENT_REMARK_SRRM " +
                " from " + "SR_REMARK_SRRM".ToFullObjectName(s_DatabaseObjectType.Table) +
                " where ID_SR_REMARK_SRRM = :id";

            while (parId > 0)
            {
                if (parId == currId)
                {
                    s_MessageBox.Show("Для текущего задания не может быть указано выбранное родительское задание, т.к. это приводит к возникновению зацикливания!");
                    dbc.Dispose();
                    e.Cancel = true;
                    return;
                }

                dbc.ParamByName("id").Value = parId;
                parId = dbc.ExecuteScalarSilent().ObjToID();
            }

            dbc.Dispose();

            SrRStatusEntity E_SRST = new SrRStatusEntity();
            E_SRST.ById(curr_status_ID, s_EntityAction.Open);
            if (E_SRST.Data.Rows.Count > 0)
            {
                E_SRST.Instance.Row = E_SRST.Data.Rows[0];
                curr_status_NPP = E_SRST.Instance.NumberPp.ObjToID();
            }
            E_SRST.Data.Close();
            E_SRST.Dispose();

            if (curr_status_NPP <= 0) return;

            if (!e.Row[ColumnDateExecute].ObjToStr().IsEmpty()
                && curr_status_NPP != 3
                && curr_status_NPP != 5
                && curr_status_NPP != 7)
            {
                s_MessageBox.Show("Для статуса \"" + curr_status_name + "\" не может быть заполнена \"Дата выполнения\"!");
                e.Cancel = true;
                return;
            }
            if (!e.Row[ColumnDateChecked].ObjToStr().IsEmpty()
                && curr_status_NPP != 5
                && curr_status_NPP != 7)
            {
                s_MessageBox.Show("Для статуса \"" + curr_status_name + "\" не может быть заполнена \"Дата принятия\"!");
                e.Cancel = true;
                return;
            }

            if (e.Row.RowState == DataRowState.Added && Instance.IdSrRPromptness == null && ID_of_Default_promptness > 0)
            {
                e.Row[ColumnIdSrRPromptness] = ID_of_Default_promptness;
            }

            if (e.Row.RowState == DataRowState.Added)
            {
                long idExecutive = e.Row[ColumnIdWhom].ObjToLong();

                SendMessage(idExecutive, string.Format("У вас новое задание. Проект {0}. Срочность {1}. Автор {2}. ID {3}. Текст: {4}",
                    e.Row[ColumnSrRProjectName].ObjToStr(),
                    e.Row[ColumnSrRPromptnessName].ObjToStr(),
                    e.Row[ColumnFromWhomName].ObjToStr(),
                    e.Row[ColumnIdSrRemark].ObjToStr(),
                    e.Row[ColumnRemark].ObjToStr()));
            }
            else
            {
                if (e.Row.RowState == DataRowState.Modified)
                {
                    long idAuthor = e.Row[ColumnIdFromWhom].ObjToLong();
                    long idExecutive = e.Row[ColumnIdWhom].ObjToLong();
                    long ID_logined = -1;

                    SrRExecutiveEntity E_SREX = new SrRExecutiveEntity();
                    E_SREX.ByLogin(s_UserEntity.Login, s_EntityAction.Open);
                    if (E_SREX.Data.Rows.Count > 0)
                    {
                        E_SREX.Instance.Row = E_SREX.Data.Rows[0];
                        ID_logined = E_SREX.Instance.IdSrRExecutive.ObjToLong();
                    }
                    E_SREX.Data.Close();
                    E_SREX.Dispose();

                    long ID_destination = idAuthor;
                    if (ID_logined == idAuthor)
                    {
                        ID_destination = ID_logined;
                    }

                    int numStatus = GetNumStatus(e.Row[ColumnIdSrRStatus].ObjToID());
                    string comm = e.Row[ColumnCommentExecut].ObjToStr();
                    if (!comm.IsEmpty())
                    {
                        comm = string.Format("Комментарий исполнителя: {0}", comm);
                    }
                    // выполнено, или выполняется
                    // if (numStatus == 3 || numStatus == 2)
                    if (_authorStatuses.Contains(numStatus))
                    {
                        SendMessage(ID_destination,
                            string.Format("Задание {6}. Исполнитель:{5}. Проект: {0}. Срочность: {1} ID {3}.  {4}",
                            e.Row[ColumnSrRProjectName].ObjToStr(),
                            e.Row[ColumnSrRPromptnessName].ObjToStr(),
                            e.Row[ColumnRemark].ObjToStr(),
                            e.Row[ColumnIdSrRemark].ObjToStr(),
                            comm,
                            e.Row[ColumnWhomName].ObjToStr(),
                            e.Row[ColumnSrRStatusName].ObjToStr().ToUpper()));
                    }
                    else
                    {
                        SendMessage(ID_destination,
                            string.Format("Изменения в задании. Текущий статус {6}. Исполнитель:{5}. Проект: {0}. Срочность: {1} ID {3}. Текст: {2} {4}",
                            e.Row[ColumnSrRProjectName].ObjToStr(),
                            e.Row[ColumnSrRPromptnessName].ObjToStr(),
                            e.Row[ColumnRemark].ObjToStr(),
                            e.Row[ColumnIdSrRemark].ObjToStr(),
                            comm,
                            e.Row[ColumnWhomName].ObjToStr(),
                            e.Row[ColumnSrRStatusName].ObjToStr().ToUpper()));
                    }
                    // отправляем оповещения всем подписанным
                    using (SrFavoriteEntity ent = new SrFavoriteEntity())
                    {
                        ent.Data.AddCondition("ByIdRemark", SrFavoriteEntity.ColumnIdSrRemark + "=" + e.Row[ColumnIdSrRemark]);

                        if (ent.Data.Open() && ent.Data.Rows.Count > 0)
                        {
                            for (int i = 0; i < ent.Data.Rows.Count; i++)
                            {
                                DataRow row = ent.Data.Rows[i];

                                SendMessage(row[SrFavoriteEntity.ColumnIdSrRExecutive].ObjToID(),
                                    string.Format("Изменения в задании. Текущий статус {6}. Исполнитель:{5}. Проект: {0}. Срочность: {1} ID {3}. Текст: {2} {4}",
                                    e.Row[ColumnSrRProjectName].ObjToStr(),
                                    e.Row[ColumnSrRPromptnessName].ObjToStr(),
                                    e.Row[ColumnRemark].ObjToStr(),
                                    e.Row[ColumnIdSrRemark].ObjToStr(),
                                    comm,
                                    e.Row[ColumnWhomName].ObjToStr(),
                                    e.Row[ColumnSrRStatusName].ObjToStr().ToUpper()));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Статусы по которым нужно оправлять оповещение автору замечания
        /// </summary>
        private readonly int[] _authorStatuses = { 2, 3 };

        private int GetNumStatus(int idStatus)
        {
            int result = -1;
            if (idStatus != -1)
            {
                s_DbCommand com = new s_DbCommand
                    {
                        CommandText = "SELECT " + SrRStatusEntity.ColumnNumberPp +
                                      " FROM " + SrRStatusEntity.TableName +
                                      " WHERE " + SrRStatusEntity.ColumnIdSrRStatus + "=" + idStatus,
                        ConnectionName = ConnectionName
                    };
                result = com.ExecuteScalar().ObjToID();
                com.Dispose();
            }
            return result;
        }

        /// <summary>
        /// не использовать рассылку сообщений
        /// </summary>
        public static bool no_jabber = false;

        private void SendMessage(long idExecutive, string msg)
        {
            if (no_jabber || JabberClient == null) return;

            // получаем логин в чате по исполнителю 
            var com = new s_DbCommand(ConnectionName);
            string login = "";
            com.CommandText = " select " + SrRExecutiveEntity.ColumnLoginInChat +
                              "," + SrRExecutiveEntity.ColumnLogin +
                              " from " + SrRExecutiveEntity.TableName +
                              " where " + SrRExecutiveEntity.ColumnIdSrRExecutive + "=" + idExecutive;
            try
            {
                if (com.Open() && com.Read())
                {
                    login = com[0].ObjToStr().GetFirstItem(";");

                    if (login.IsEmpty())
                    {
                        login = com[1].ObjToStr();
                    }
                }
            }
            finally
            {
                com.Close();
                com.Dispose();
            }

            try
            {
                Thread thread = new Thread(
                    delegate()
                    {
                        if (idExecutive != -1 && JabberClient != null)
                        {
                            if (!login.IsEmpty())
                                try
                                {
                                    if (miSendMessage != null)
                                    {
                                        miSendMessage.Invoke(JabberClient, new object[] { login, msg });
                                    }
                                    //JabberClient.SendMessage(login, msg);
                                }
                                catch
                                {
                                    _jabberClient = null;
                                }
                        }
                    }
                    );
                thread.Start();
            }
            catch (Exception ex)
            {
                s_MessageBox.Show("Не удалось отправить сообщение получателю: " + ex);
            }
            finally
            { }
        }

        public override string GetGridColumns()
        {
            string result = base.GetGridColumns();

            result += ";" + ColumnIdSrRemark;

            return result;
        }

        #endregion

        #region заготовки типовых методов

        public bool ByIdParent(Int64 id, s_EntityAction actionType)
        {
            SelectionName = "ByIdParent";
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
                    result = Data.Find(new s_NamedObjects(PARAM_NAME, new object[] { id }));
                else
                    Data.SetParameter(PARAM_NAME, id);
            }
            return result;
        }

        #endregion

        public override void ShowData(object parameters)
        {
            s_EntityShowingEventArgs __e = new s_EntityShowingEventArgs();
            OnShowing(__e);
            if (__e.Cancel) return;
            string curr_Value = "";
            bool selecting = false;
            s_NamedObjects gp = null;
            s_NamedObjects loc_list = null;
            s_ViewOption opt = s_ViewOption.None;
            if (parameters != null)
            {
                opt = GetSViewOption(parameters, out loc_list);

                if (loc_list != null)
                {
                    curr_Value = loc_list[ColumnIdSrRemark].ObjToStr();
                }

                selecting = opt.ContainsOption(s_ViewOption.Select) || opt.ContainsOption(s_ViewOption.MultiSelect);
            }
            if (ShowDataParams != null)
            {
                if (ShowDataParams.ContainsKey(Const.par_graph_params))
                {
                    gp = (s_NamedObjects)ShowDataParams[Const.par_graph_params];
                }
                else
                {
                    gp = new s_NamedObjects();
                    ShowDataParams[Const.par_graph_params] = gp;
                }

                foreach (KeyValuePair<string, object> kvp in ShowDataParams)
                {
                    if (kvp.Key.StartsWith(Const.par_node_value))
                    {
                        gp[kvp.Key] = kvp.Value;
                    }
                }

                int self_Proj = -1;

                if (loc_list != null)
                {
                    self_Proj = loc_list[ColumnIdSrRProject].ObjToID();
                }

                if (self_Proj <= 0)
                {
                    self_Proj = ShowDataParams[Const.par_node_value + "0"].ObjToID();

                    if (!curr_Value.IsEmpty())
                    {
                        int ref_Proj_ID = FuncDB.GetFieldById(TableName, ColumnIdSrRemark, curr_Value, ColumnIdSrRProject).ObjToID();
                        if (self_Proj != ref_Proj_ID)
                        {
                            self_Proj = -1;
                        }
                    }
                }

                gp[Const.par_view_option] = parameters;

                gp[Const.par_node_value + "0"] = self_Proj;

                Type type = Type.GetType("S_.WindowsForms.s_ShowDataOptionsWinForm, S_.WF", false, true);
                if (type != null)
                {
                    FieldInfo fi = type.GetField("OwnerForm", Func.bf);
                    if (fi != null)
                    {
                        gp[Const.par_owner_form] = fi.GetValue(parameters);
                    }
                }
            }

            ShowGraph("05", curr_Value, Remarks_scheme.scheme_text, selecting, gp);

            OnShowned(EventArgs.Empty);
        }
        protected override void Dispose(bool manualDisposing)
        {
            base.Dispose(manualDisposing);
        }
    }
}