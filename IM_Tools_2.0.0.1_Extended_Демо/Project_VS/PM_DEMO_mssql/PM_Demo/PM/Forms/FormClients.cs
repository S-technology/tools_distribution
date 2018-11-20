using System;
using System.Windows.Forms;
using S_;
using S_.WindowsForms;
using IM.Hierarchy;
using IM.Hierarchy.Forms;
using PM.Entity;

namespace PM.Forms
{
    /// <summary>
    /// Форма 'Заказчики'
    /// </summary>
    public partial class FormClients : FormPM
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormClients()
        {
            InitializeComponent();
        }

        private SrRClientEntity _currentEntity;
        /// <summary>
        /// Назначает сущность формы
        /// </summary>
        /// <returns>сущность формы</returns>
        public override s_EntityObject CreateEntity()
        {
            _currentEntity = new SrRClientEntity();

            return _currentEntity;
        }

        /// <summary>
        /// Готовит форму к работе
        /// </summary>
        /// <returns>подготовлено успешно</returns>
        protected override bool s_Prepare()
        {
            if (!base.s_Prepare()) return false;

            ObjViewMapsClass = new ViewMapsClass(this, tb_MapArcMap_Click, tb_MapArcReader_Click);
            MapLayerID = "1";
            if (View == null || !View.Prepare()) return false;

            return true;
        }

        /*
        /// <summary>
        /// Показ карты ArcReader
        /// </summary>
        protected override void tb_MapArcReader_Click(object sender, EventArgs e)
        {
            if (View.Data.DataViewRows.Count == 0) return;
            string patnm = string.Empty;
            if (sender is ToolStripItem && (!(sender is ToolStripMenuItem) || ((ToolStripMenuItem)sender).DropDownItems.Count == 0) && ViewMapsClass.ArcReaderPatternsList != null)
            {
                patnm = (string)((ToolStripItem)sender).Tag;
            }
            string str = GetSelectedValues(this.KeyField, ",");
            if (str.Length == 0) return;
            s_NamedObjects pList = new s_NamedObjects();
            pList.Add(MapLayerID, str);
            int IdTmpProj = IM.Maps.Entity.TMmPrjmapEntity.CreateTmpProject(pList, patnm, true);
            if (IdTmpProj > 0)
            {
                try
                {
                    //IM.Maps.Forms.fm_MapViewer.Execute(IdTmpProj);
                    IM.Maps.Forms.fm_MapViewer.Execute(IdTmpProj, patnm, new IM.Maps.DataAdapters.MapDataAdapterBase());
                }
                finally
                {
                    IM.Maps.Entity.TMmPrjmapEntity.DeleteProject(IdTmpProj, true);
                }
            }

        }

        /// <summary>
        /// Показ карты ArcMap
        /// </summary>
        protected override void tb_MapArcMap_Click(object sender, EventArgs e)
        {
            if (View.Data.DataViewRows.Count == 0) return;
            string patnm = string.Empty;
            if (sender is ToolStripItem && (!(sender is ToolStripMenuItem) || ((ToolStripMenuItem)sender).DropDownItems.Count == 0) && ViewMapsClass.ArcMapPatternsList != null)
            {
                patnm = (string)((ToolStripItem)sender).Tag;
            }
            string str = GetSelectedValues(this.KeyField, ","); 
            if (str.Length == 0) return;
            s_NamedObjects pList = new s_NamedObjects();
            pList.Add(MapLayerID, str);
            int IdTmpProj = IM.Maps.Entity.TMmPrjmapEntity.CreateTmpProject(pList, patnm, true);
            if (IdTmpProj > 0)
            {
                try
                {
                    //IM.Maps.Forms.fm_ArcMapViewer.Execute(IdTmpProj);
                    IM.Maps.Forms.fm_ArcMapViewer.Execute(IdTmpProj, patnm, new IM.Maps.DataAdapters.MapDataAdapterBase());
                }
                finally
                {
                    IM.Maps.Entity.TMmPrjmapEntity.DeleteProject(IdTmpProj, true);
                }
            }
        }
         */ 
        /*
        /// <summary>
        /// Настраивает View до вызова View.Prepare()
        /// </summary>
        /// <param name="view">View</param>
        protected override void SetupView(s_View view)
        {
            if (view == null) return;

            base.setuview(view);

            view.Options = view.Options
                | s_ViewOption.ConfSave
                | s_ViewOption.ImportFile;

            // 5) раскомментируем этот блок, вместо ColumnName_XXXX подставляем имя колонки-наименования, 
            // если нужна рукотворная карточка вместо стандартной
            // view.Attributes[Entity_XXXX.ColumnName_XXXX].ControlView = textBox_Name;
        }
        /**/
    }
}