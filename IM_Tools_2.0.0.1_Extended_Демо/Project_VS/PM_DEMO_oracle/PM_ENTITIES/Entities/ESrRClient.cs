/********************************************************************************/
/*                                                                              */
/*Copyright (c) 1999,2016   Information & Management Ltd.                       */
/*                                                                              */
/*   Модуль таблицы SR_R_CLIENT_SRCL                                            */
/*                                                                              */
/*   NAME  ESrRClient.cs    SCOPE    ....                                       */
/*                                                                              */
/*   DESCRIPTION                                                                */
/*     Заказчик                                                                 */
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
using IM.Hierarchy.Forms;

namespace PM.Entity
{

    //s_DataObject.Register(typeof(SrRClientData));
    //s_EntityObject.Register(typeof(SrRClientEntity));

    [IMDataClassAttribute(
        TableName = "Default"
      , DefaultEntityClass = typeof(SrRClientEntity)
      , Sequence = "SEQ_SR_R_CLIENT_SRCL"
      , LookupKeyColumns = "Default"
      , LookupResultColumn = "Default"
      , DefaultCaption = "СЗ_С_ЗАКАЗЧИК"
      , FormulaName = "СЗ_С_ЗАКАЗЧИК"
      )]
    [s_DataClassSelection(Name = "Default", IsList = true)]
    [s_DataClassSelection(Name = "UN_ORDINATE_List", IsList = true)]
    [s_DataClassSelection(Name = "UN_ORDINATE_ONE_RECORD", IsList = true)]
    public partial class SrRClientData : GraphDataObject
    {
        #region конструктор
        public SrRClientData(string pSelectionName = "Default")
            : base(pSelectionName)
        {
            if (SelectionName.SameStr("UN_ORDINATE_List") || SelectionName.SameStr("UN_ORDINATE_ONE_RECORD"))
            {
                TUnOrdinatexyhUoxyEntity.SetTitleForCoorFields(this);
            }
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
        public new SrRClientEntity Entity
        {
            [DebuggerStepThrough]
            get
            {
                return (SrRClientEntity)base.Entity;
            }
        }
        #endregion

        #region DataObject columns
        //Do not modify column names with the code editor
        private s_DataColumn _id_sr_r_client;
        /// <summary>ID_SR_R_CLIENT_SRCL ()</summary>
        [IMDataClassColumnAttribute(DisableUserEdit = true, Title = "ID_Заказчик", FormulaName = "ID_ЗАКАЗЧИК")]
        public s_DataColumn ID_SR_R_CLIENT
        {
            [DebuggerStepThrough]
            get { return _id_sr_r_client ?? ColumnByName(SrRClientEntity.ColumnIdSrRClient, out _id_sr_r_client); }
        }
        private s_DataColumn _name_client;
        /// <summary>NAME_CLIENT_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Наименование полное", FormulaName = "НАИМЕНОВАНИЕ_ПОЛНОЕ")]
        public s_DataColumn NAME_CLIENT
        {
            [DebuggerStepThrough]
            get { return _name_client ?? ColumnByName(SrRClientEntity.ColumnNameClient, out _name_client); }
        }
        private s_DataColumn _name_short;
        /// <summary>NAME_SHORT_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Наименование краткое", FormulaName = "НАИМЕНОВАНИЕ_КРАТКОЕ")]
        public s_DataColumn NAME_SHORT
        {
            [DebuggerStepThrough]
            get { return _name_short ?? ColumnByName(SrRClientEntity.ColumnNameShort, out _name_short); }
        }
        private s_DataColumn _address;
        /// <summary>ADDRESS_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Юридический адрес", FormulaName = "ЮРИДИЧЕСКИЙ_АДРЕС")]
        public s_DataColumn ADDRESS
        {
            [DebuggerStepThrough]
            get { return _address ?? ColumnByName(SrRClientEntity.ColumnAddress, out _address); }
        }
        private s_DataColumn _address_fact;
        /// <summary>ADDRESS_FACT_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Фактический адрес", FormulaName = "ФАКТИЧЕСКИЙ_АДРЕС")]
        public s_DataColumn ADDRESS_FACT
        {
            [DebuggerStepThrough]
            get { return _address_fact ?? ColumnByName(SrRClientEntity.ColumnAddressFact, out _address_fact); }
        }
        private s_DataColumn _phone;
        /// <summary>PHONE_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Телефон", FormulaName = "ТЕЛЕФОН")]
        public s_DataColumn PHONE
        {
            [DebuggerStepThrough]
            get { return _phone ?? ColumnByName(SrRClientEntity.ColumnPhone, out _phone); }
        }
        private s_DataColumn _fax;
        /// <summary>FAX_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Факс", FormulaName = "ФАКС")]
        public s_DataColumn FAX
        {
            [DebuggerStepThrough]
            get { return _fax ?? ColumnByName(SrRClientEntity.ColumnFax, out _fax); }
        }
        private s_DataColumn _email;
        /// <summary>EMAIL_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Адрес электронной почты", FormulaName = "АДРЕС_ЭЛЕКТРОННОЙ_ПОЧТЫ")]
        public s_DataColumn EMAIL
        {
            [DebuggerStepThrough]
            get { return _email ?? ColumnByName(SrRClientEntity.ColumnEmail, out _email); }
        }
        private s_DataColumnString _comment;
        /// <summary>COMMENT_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Примечание", FormulaName = "ПРИМЕЧАНИЕ")]
        public s_DataColumn COMMENT
        {
            [DebuggerStepThrough]
            get { return _comment ?? ColumnByName(SrRClientEntity.ColumnComment, out _comment); }
        }
        private s_DataColumn _vvod_id_contractor;
        /// <summary>VVOD_ID_CONTRACTOR_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Автор ввода", DisableUserEdit = true, FormulaName = "АВТОР_ВВОДА")]
        public s_DataColumn VVOD_ID_CONTRACTOR
        {
            [DebuggerStepThrough]
            get { return _vvod_id_contractor ?? ColumnByName(SrRClientEntity.ColumnVvodIdContractor, out _vvod_id_contractor); }
        }
        private s_DataColumn _change_id_contractor;
        /// <summary>CHANGE_ID_CONTRACTOR_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Автор изменения", DisableUserEdit = true, FormulaName = "АВТОР_ИЗМЕНЕНИЯ")]
        public s_DataColumn CHANGE_ID_CONTRACTOR
        {
            [DebuggerStepThrough]
            get { return _change_id_contractor ?? ColumnByName(SrRClientEntity.ColumnChangeIdContractor, out _change_id_contractor); }
        }
        private s_DataColumn _date_input;
        /// <summary>DATE_INPUT_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Дата ввода", DataType = s_DateType.DateTime, DisableUserEdit = true, FormulaName = "ДАТА_ВВОДА")]
        public s_DataColumn DATE_INPUT
        {
            [DebuggerStepThrough]
            get { return _date_input ?? ColumnByName(SrRClientEntity.ColumnDateInput, out _date_input); }
        }
        private s_DataColumn _date_change;
        /// <summary>DATE_CHANGE_SRCL ()</summary>
        [IMDataClassColumnAttribute(Title = "Дата изменения", DataType = s_DateType.DateTime, DisableUserEdit = true, FormulaName = "ДАТА_ИЗМЕНЕНИЯ")]
        public s_DataColumn DATE_CHANGE
        {
            [DebuggerStepThrough]
            get { return _date_change ?? ColumnByName(SrRClientEntity.ColumnDateChange, out _date_change); }
        }
        #endregion

    }

    [s_EntityClass(
        DefaultDataClass = typeof(SrRClientData)
      , PrivilegeRead = "Default"
      , PrivilegeWrite = "Default"
      )]
    public partial class SrRClientEntity : GraphEntity
    {

        #region конструкторы
        public SrRClientEntity(string pConnectionName = "") : base(pConnectionName) { }
        #endregion

        #region актуализация типа ссылки на дата-класс
        public new SrRClientData Data
        {
            [DebuggerStepThrough]
            get
            {
                return (SrRClientData)base.Data;
            }
        }
        #endregion

        #region константы
        /// <summary>SR_R_CLIENT_SRCL</summary>
        static public string TableName { get { return "SR_R_CLIENT_SRCL".ToFullObjectName(s_DatabaseObjectType.Table); } }
        // Имена колонок выборки
        /// <summary>ID_SR_R_CLIENT_SRCL</summary>
        static readonly public string ColumnIdSrRClient = "ID_SR_R_CLIENT_SRCL";
        /// <summary>NAME_CLIENT_SRCL</summary>
        static readonly public string ColumnNameClient = "NAME_CLIENT_SRCL";
        /// <summary>NAME_SHORT_SRCL</summary>
        static readonly public string ColumnNameShort = "NAME_SHORT_SRCL";
        /// <summary>ADDRESS_SRCL</summary>
        static readonly public string ColumnAddress = "ADDRESS_SRCL";
        /// <summary>ADDRESS_FACT_SRCL</summary>
        static readonly public string ColumnAddressFact = "ADDRESS_FACT_SRCL";
        /// <summary>PHONE_SRCL</summary>
        static readonly public string ColumnPhone = "PHONE_SRCL";
        /// <summary>FAX_SRCL</summary>
        static readonly public string ColumnFax = "FAX_SRCL";
        /// <summary>EMAIL_SRCL</summary>
        static readonly public string ColumnEmail = "EMAIL_SRCL";
        /// <summary>COMMENT_SRCL</summary>
        static readonly public string ColumnComment = "COMMENT_SRCL";
        /// <summary>VVOD_ID_CONTRACTOR_SRCL</summary>
        static readonly public string ColumnVvodIdContractor = "VVOD_ID_CONTRACTOR_SRCL";
        /// <summary>CHANGE_ID_CONTRACTOR_SRCL</summary>
        static readonly public string ColumnChangeIdContractor = "CHANGE_ID_CONTRACTOR_SRCL";
        /// <summary>DATE_INPUT_SRCL</summary>
        static readonly public string ColumnDateInput = "DATE_INPUT_SRCL";
        /// <summary>DATE_CHANGE_SRCL</summary>
        static readonly public string ColumnDateChange = "DATE_CHANGE_SRCL";
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

        public override void ShowData(object options)
        {
            s_EntityShowingEventArgs __e = new s_EntityShowingEventArgs();
            OnShowing(__e);
            if (__e.Cancel) return;
            s_NamedObjects lParams = GetShowDataParams(options);
            ShowGraph("1", ClientsScheme.SchemeText, lParams);
            OnShowned(EventArgs.Empty);
        }
    }
}