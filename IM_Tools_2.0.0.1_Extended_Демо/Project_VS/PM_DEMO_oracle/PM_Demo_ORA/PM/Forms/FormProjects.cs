using System;
using System.Windows.Forms;
using S_;
using S_.WindowsForms;
using IM.Hierarchy;
using IM.Hierarchy.Forms;
using PM.Entity;
using System.Collections.Generic;

namespace PM.Forms
{
    /// <summary>
    /// Форма 'Заказчики'
    /// </summary>
    public partial class FormProjects : FormPM
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormProjects()
        {
            InitializeComponent();
        }

        private SrRProjectEntity _currentEntity;
        /// <summary>
        /// Назначает сущность формы
        /// </summary>
        /// <returns>сущность формы</returns>
        public override s_EntityObject CreateEntity()
        {
            _currentEntity = new SrRProjectEntity();

            return _currentEntity;
        }

        /// <summary>
        /// Готовит форму к работе
        /// </summary>
        /// <returns>подготовлено успешно</returns>
        protected override bool s_Prepare()
        {
            if (!base.s_Prepare()) return false;

            View.DataView.CellImageClick += DataView_CellImageClick; ;
            View.DataView.Initialization += DataView_Initialization; ;
            View.DataView.CellImageGet += DataView_CellImageGet; 

            if (View == null || !View.Prepare()) return false;

            View.Columns[SrRProjectEntity.ColumnID_SR_PHYS_PERSON_NAME].Visible = false;

            return true;
        }

        protected override void s_UnPrepare()
        {
            View.DataView.CellImageClick -= DataView_CellImageClick; ;
            View.DataView.Initialization -= DataView_Initialization; ;
            View.DataView.CellImageGet -= DataView_CellImageGet;

            base.s_UnPrepare();
        }

        void DataView_CellImageGet(object sender, s_ViewCellImageGetEventArgs e)
        {
            if (e.ViewColumn.Name.SameText(SrRProjectEntity.ColumnID_SR_PHYS_PERSON_FIO))
            {
                e.Image = s_Application.Image16List.Images["s_Definit2"];
            }
        }

        void DataView_Initialization(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, s_ViewColumn> kvp in View.Attributes)
            {
                if (kvp.Key.Contains(SrRProjectEntity.ColumnID_SR_PHYS_PERSON_FIO))
                {
                    kvp.Value.IsImaging = true;
                    kvp.Value.Image = s_Application.Image16List.Images["s_Blank"];
                }
            }
        }

        void DataView_CellImageClick(object sender, s_ViewCellImageClickEventArgs e)
        {
            if (e.ViewColumn.Name.SameText(SrRProjectEntity.ColumnID_SR_PHYS_PERSON_FIO))
            {
                SrPhysPersonEntity ent = new SrPhysPersonEntity();
                s_NamedObjects no = new s_NamedObjects();
                no[Const.par_outer_entity] = ent;
                //no[Const.par_form_ClassName] = "PM.Forms.FormExecutors,PM";
                no[Const.par_current_selection] = View_(SrRProjectEntity.ColumnID_SR_PHYS_PERSON_SRPJ);
                bool select = s_Status == s_FormStatus.Edit || s_Status == s_FormStatus.Insert;
                if (select)
                {
                    no[Const.par_type_select] = TypeOfSelection.One;
                }

                FormLow.Execute(no);

                if (select && s_Application.SelectionDone && s_Application.SelectionList.Count > 0)
                {
                    View.Data[SrRProjectEntity.ColumnID_SR_PHYS_PERSON_SRPJ, View.CurrentDataRow] = s_Application.SelectionList[0][SrPhysPersonEntity.ColumnIdSrPhysPerson];
                    View.Data[SrRProjectEntity.ColumnID_SR_PHYS_PERSON_FIO, View.CurrentDataRow] = s_Application.SelectionList[0][SrPhysPersonEntity.ColumnSrRExecutiveLp];
                    //View.Data.Save();
                    s_Application.SelectionList.Clear();
                    s_Application.SelectionDone = false;
                }

                ent.Dispose();
            }
        }
    }
}