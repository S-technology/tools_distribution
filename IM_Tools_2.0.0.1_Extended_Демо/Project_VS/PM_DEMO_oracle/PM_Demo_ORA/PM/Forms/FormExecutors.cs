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
    /// Форма 'Исполнители'
    /// </summary>
    public partial class FormExecutors : FormPM
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormExecutors()
        {
            InitializeComponent();
        }

        private SrRExecutiveEntity _currentEntity;
        /// <summary>
        /// Назначает сущность формы
        /// </summary>
        /// <returns>сущность формы</returns>
        public override s_EntityObject CreateEntity()
        {
            _currentEntity = new SrRExecutiveEntity();

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
            MapLayerID = "2";
            if (View == null || !View.Prepare()) return false;

            return true;
        }
		
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