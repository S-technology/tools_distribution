/********************************************************************************/
/*                                                                              */
/*Copyright (c) 1999,2016   Information & Management Ltd.                       */
/*                                                                              */
/*   Модуль таблицы SR_PHYS_PERSON_SRPP                                         */
/*                                                                              */
/*   NAME  ESrPhysPerson.cs    SCOPE    ....                                    */
/*                                                                              */
/*   DESCRIPTION                                                                */
/*     Физическое лицо                                                          */
/*                                                                              */
/*   AUTHOR                                                                     */
/*     РМБ                                                                      */
/********************************************************************************/
 
/*
    31.03.2016  Automatic  Первоначальная редакция
                                                                               */
 
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using System.Linq;
using S_;
using IM.Hierarchy;
using IM.Functions;
using IM.Maps;
using IM.Maps.Entity;
using IM.Maps.SERVICECLASSES;

namespace PM.Entity
{

    //s_DataObject.Register(typeof(SrPhysPersonData));
    //s_EntityObject.Register(typeof(SrPhysPersonEntity));

    [IMDataClassAttribute(
        TableName = "Default"
      , DefaultEntityClass = typeof(SrPhysPersonEntity)
      , Sequence = "SEQ_SR_PHYS_PERSON_SRPP"
      , LookupKeyColumns = "Default"
      , LookupResultColumn = "DATE_BIRTH_SRPP"
      //, LookupResultAgg = "(select FIO_SREX from " + "SR_R_EXECUTIVE_SREX".ToFullObjectName(s_DatabaseObjectType.Table) + " where ID_SR_R_EXECUTIVE_SRPP = ID_SR_R_EXECUTIVE_SREX)" //
      , DefaultCaption = "Физическое лицо"
      , FormulaName = "СЗ_ФИЗИЧЕСКОЕ_ЛИЦО"
      )]
    [s_DataClassSelection(Name = "Default", IsList = true)]
    [s_DataClassSelection(Name = "UN_ORDINATE_List", IsList = true)]
    [s_DataClassSelection(Name = "UN_ORDINATE_ONE_RECORD", IsList = true)]
    public partial class SrPhysPersonData : GraphDataObject
    {
        #region конструктор
        public SrPhysPersonData(string pSelectionName = "Default")
            : base(pSelectionName)
        {
            if (SelectionName.SameStr("UN_ORDINATE_List") || SelectionName.SameStr("UN_ORDINATE_ONE_RECORD"))
            {
                TUnOrdinatexyhUoxyEntity.SetTitleForCoorFields(this);
            }

            //LookupResultAgg = "(select FIO_SREX from " + "SR_R_EXECUTIVE_SREX".ToFullObjectName(s_DatabaseObjectType.Table) + " where ID_SR_R_EXECUTIVE_SRPP = ID_SR_R_EXECUTIVE_SREX)";
        }
        #endregion

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

        #region актуализация типа ссылки на класс-сущность
        public new SrPhysPersonEntity Entity
        {
            [DebuggerStepThrough]
            get
            {
                return (SrPhysPersonEntity)base.Entity;
            }
        }
        #endregion

        #region DataObject columns
        //Do not modify column names with the code editor
        private s_DataColumn _id_sr_phys_person;
        /// <summary>ID_SR_PHYS_PERSON_SRPP ()</summary>
        [IMDataClassColumnAttribute(DisableUserEdit = true, Title = "ID_Физическое лицо", FormulaName = "ID_ФИЗИЧЕСКОЕ_ЛИЦО")]
        public s_DataColumn ID_SR_PHYS_PERSON
        {
            [DebuggerStepThrough]
            get { return _id_sr_phys_person ?? ColumnByName(SrPhysPersonEntity.ColumnIdSrPhysPerson, out _id_sr_phys_person); }
        }
        private s_DataColumn _id_sr_r_executive;
        /// <summary>ID_SR_R_EXECUTIVE_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "ID_Исполнитель", FormulaName = "ID_ИСПОЛНИТЕЛЬ")]
        public s_DataColumn ID_SR_R_EXECUTIVE
        {
            [DebuggerStepThrough]
            get { return _id_sr_r_executive ?? ColumnByName(SrPhysPersonEntity.ColumnIdSrRExecutive, out _id_sr_r_executive); }
        }
        private s_DataColumn _date_birth;
        /// <summary>DATE_BIRTH_SRPP ()</summary>
        [IMDataClassColumnAttribute(DataType = s_DateType.Date, Title = "Дата рождения", FormulaName = "ДАТА_РОЖДЕНИЯ")]
        public s_DataColumn DATE_BIRTH
        {
            [DebuggerStepThrough]
            get { return _date_birth ?? ColumnByName(SrPhysPersonEntity.ColumnDateBirth, out _date_birth); }
        }
        private s_DataColumn _education;
        /// <summary>EDUCATION_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Образование", FormulaName = "ОБРАЗОВАНИЕ")]
        public s_DataColumn EDUCATION
        {
            [DebuggerStepThrough]
            get { return _education ?? ColumnByName(SrPhysPersonEntity.ColumnEducation, out _education); }
        }
        private s_DataColumn _post;
        /// <summary>POST_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Должность", FormulaName = "ДОЛЖНОСТЬ")]
        public s_DataColumn POST
        {
            [DebuggerStepThrough]
            get { return _post ?? ColumnByName(SrPhysPersonEntity.ColumnPost, out _post); }
        }
        private s_DataColumn _phone;
        /// <summary>PHONE_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Контактный телефон", FormulaName = "КОНТАКТНЫЙ_ТЕЛЕФОН")]
        public s_DataColumn PHONE
        {
            [DebuggerStepThrough]
            get { return _phone ?? ColumnByName(SrPhysPersonEntity.ColumnPhone, out _phone); }
        }
        private s_DataColumn _email;
        /// <summary>EMAIL_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Адрес электронной почты", FormulaName = "АДРЕС_ЭЛЕКТРОННОЙ_ПОЧТЫ")]
        public s_DataColumn EMAIL
        {
            [DebuggerStepThrough]
            get { return _email ?? ColumnByName(SrPhysPersonEntity.ColumnEmail, out _email); }
        }
        private s_DataColumn _skype;
        /// <summary>SKYPE_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Skype", FormulaName = "SKYPE")]
        public s_DataColumn SKYPE
        {
            [DebuggerStepThrough]
            get { return _skype ?? ColumnByName(SrPhysPersonEntity.ColumnSkype, out _skype); }
        }
        private s_DataColumn _icq;
        /// <summary>ICQ_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "ICQ", FormulaName = "ICQ")]
        public s_DataColumn ICQ
        {
            [DebuggerStepThrough]
            get { return _icq ?? ColumnByName(SrPhysPersonEntity.ColumnIcq, out _icq); }
        }
        private s_DataColumn _other_contact;
        /// <summary>OTHER_CONTACT_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Прочие контакты", FormulaName = "ПРОЧИЕ_КОНТАКТЫ")]
        public s_DataColumn OTHER_CONTACT
        {
            [DebuggerStepThrough]
            get { return _other_contact ?? ColumnByName(SrPhysPersonEntity.ColumnOtherContact, out _other_contact); }
        }
        private s_DataColumn _comment;
        /// <summary>COMMENT_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Примечание", FormulaName = "ПРИМЕЧАНИЕ")]
        public s_DataColumn COMMENT
        {
            [DebuggerStepThrough]
            get { return _comment ?? ColumnByName(SrPhysPersonEntity.ColumnComment, out _comment); }
        }
        private s_DataColumn _vvod_id_contractor;
        /// <summary>VVOD_ID_CONTRACTOR_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Автор ввода", DisableUserEdit = true, FormulaName = "АВТОР_ВВОДА")]
        public s_DataColumn VVOD_ID_CONTRACTOR
        {
            [DebuggerStepThrough]
            get { return _vvod_id_contractor ?? ColumnByName(SrPhysPersonEntity.ColumnVvodIdContractor, out _vvod_id_contractor); }
        }
        private s_DataColumn _change_id_contractor;
        /// <summary>CHANGE_ID_CONTRACTOR_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Автор изменения", DisableUserEdit = true, FormulaName = "АВТОР_ИЗМЕНЕНИЯ")]
        public s_DataColumn CHANGE_ID_CONTRACTOR
        {
            [DebuggerStepThrough]
            get { return _change_id_contractor ?? ColumnByName(SrPhysPersonEntity.ColumnChangeIdContractor, out _change_id_contractor); }
        }
        private s_DataColumn _date_input;
        /// <summary>DATE_INPUT_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Дата ввода", DataType = s_DateType.DateTime, DisableUserEdit = true, FormulaName = "ДАТА_ВВОДА")]
        public s_DataColumn DATE_INPUT
        {
            [DebuggerStepThrough]
            get { return _date_input ?? ColumnByName(SrPhysPersonEntity.ColumnDateInput, out _date_input); }
        }
        private s_DataColumn _date_change;
        /// <summary>DATE_CHANGE_SRPP ()</summary>
        [IMDataClassColumnAttribute(Title = "Дата изменения", DataType = s_DateType.DateTime, DisableUserEdit = true, FormulaName = "ДАТА_ИЗМЕНЕНИЯ")]
        public s_DataColumn DATE_CHANGE
        {
            [DebuggerStepThrough]
            get { return _date_change ?? ColumnByName(SrPhysPersonEntity.ColumnDateChange, out _date_change); }
        }
        #region Lookup
        private s_DataColumnString _sr_r_executive_lp;
        /// <summary>SR_R_EXECUTIVE_SRPP_LP (String)</summary>
        [IMDataClassColumnAttribute(Name = "SR_R_EXECUTIVE_SRPP_LP", Type = s_AttributeType.Lookup, RefClassName = "SrRExecutiveData", KeyColumns = "ID_SR_R_EXECUTIVE_SRPP")]
        public s_DataColumnString SR_R_EXECUTIVE_LP
        {
            [DebuggerStepThrough]
            get { return _sr_r_executive_lp ?? ColumnByName(SrPhysPersonEntity.ColumnSrRExecutiveLp, out _sr_r_executive_lp); }
        }
        #endregion
        #endregion

    }

    [s_EntityClass(
        DefaultDataClass = typeof(SrPhysPersonData)
      , PrivilegeRead = "Default"
      , PrivilegeWrite = "Default"
      , DefaultCaption = "Физическое лицо"
      )]
    public partial class SrPhysPersonEntity : GraphEntity
    {

        #region конструкторы
        public SrPhysPersonEntity(string pConnectionName = "") : base(pConnectionName) { }
        #endregion

        #region актуализация типа ссылки на дата-класс
        public new SrPhysPersonData Data
        {
            [DebuggerStepThrough]
            get
            {
                return (SrPhysPersonData)base.Data;
            }
        }
        #endregion

        #region константы
        /// <summary>SR_PHYS_PERSON_SRPP</summary>
        static public string TableName { get { return "SR_PHYS_PERSON_SRPP".ToFullObjectName(s_DatabaseObjectType.Table); } }
        // Имена колонок выборки
        /// <summary>ID_SR_PHYS_PERSON_SRPP</summary>
        static readonly public string ColumnIdSrPhysPerson = "ID_SR_PHYS_PERSON_SRPP";
        /// <summary>ID_SR_R_EXECUTIVE_SRPP</summary>
        static readonly public string ColumnIdSrRExecutive = "ID_SR_R_EXECUTIVE_SRPP";
        /// <summary>DATE_BIRTH_SRPP</summary>
        static readonly public string ColumnDateBirth = "DATE_BIRTH_SRPP";
        /// <summary>EDUCATION_SRPP</summary>
        static readonly public string ColumnEducation = "EDUCATION_SRPP";
        /// <summary>POST_SRPP</summary>
        static readonly public string ColumnPost = "POST_SRPP";
        /// <summary>PHONE_SRPP</summary>
        static readonly public string ColumnPhone = "PHONE_SRPP";
        /// <summary>EMAIL_SRPP</summary>
        static readonly public string ColumnEmail = "EMAIL_SRPP";
        /// <summary>SKYPE_SRPP</summary>
        static readonly public string ColumnSkype = "SKYPE_SRPP";
        /// <summary>ICQ_SRPP</summary>
        static readonly public string ColumnIcq = "ICQ_SRPP";
        /// <summary>OTHER_CONTACT_SRPP</summary>
        static readonly public string ColumnOtherContact = "OTHER_CONTACT_SRPP";
        /// <summary>COMMENT_SRPP</summary>
        static readonly public string ColumnComment = "COMMENT_SRPP";
        /// <summary>VVOD_ID_CONTRACTOR_SRPP</summary>
        static readonly public string ColumnVvodIdContractor = "VVOD_ID_CONTRACTOR_SRPP";
        /// <summary>CHANGE_ID_CONTRACTOR_SRPP</summary>
        static readonly public string ColumnChangeIdContractor = "CHANGE_ID_CONTRACTOR_SRPP";
        /// <summary>DATE_INPUT_SRPP</summary>
        static readonly public string ColumnDateInput = "DATE_INPUT_SRPP";
        /// <summary>DATE_CHANGE_SRPP</summary>
        static readonly public string ColumnDateChange = "DATE_CHANGE_SRPP";
        /// <summary>SR_R_EXECUTIVE_SRPP_LP</summary>
        static readonly public string ColumnSrRExecutiveLp = "SR_R_EXECUTIVE_SRPP_LP";
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
                    s_DbCommand dbc = new s_DbCommand(ConnectionName);
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
    }
}