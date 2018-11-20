using IM.Functions;
using S_.WindowsForms;
using System;
using System.IO;
using IM.Hierarchy;
using IM.Hierarchy.Forms;
using S_;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using IM.Maps.DataAdapters;
using IM.Maps.Entity;
using IM.Maps.Forms;
using System.ComponentModel;

/*
 * 18.05.2016 TV Задание 14586, 14587. Исправлена ошибка при создании временного проекта карты (раньше шаблон по умолчанию
 * всегда был формата PMF, исправлена ошибка создания адаптера для показа временного проекта карты).
*/


namespace PM.Forms
{
    /// <summary>
    /// Предок для некоторых форм проекта PM. Пока реализует методы вывода на карту,
    /// в дальнейшем функционал может быть дополнен по аналогии с подобными формами др. проектов.
    /// </summary>
    public partial class FormPM : FormForExperiments
    {
        public FormPM()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки третьего уровня
        /// </summary>
        public virtual void ac_doc()
        {
            
        }



        protected override bool s_Prepare()
        {
            return base.s_Prepare();
        }

        /// <summary>
        /// Обработчик кнопки показа карты (ArcReader). В потомке передается классу ViewMapsClass
        /// </summary>
        protected override void tb_MapArcReader_Click(object sender, EventArgs e)
        {
            string patnm = string.Empty;
            if (sender is ToolStripItem && (!(sender is ToolStripMenuItem) || ((ToolStripMenuItem)sender).DropDownItems.Count == 0) && ViewMapsClass.ArcReaderPatternsList != null)
            {
                patnm = (string)((ToolStripItem)sender).Tag;
            }
            int IdTmpProj = CreateMapTmpProject(patnm, false);
            if (IdTmpProj > 0)
            {
                try
                {
                    fm_MapViewer.Execute(IdTmpProj, patnm, new IM.Maps.DataAdapters.MapDataAdapterExtended());
                }
                finally
                {
                    TMmPrjmapEntity.DeleteProject(IdTmpProj, true);
                }
            }
        }
        /// <summary>
        /// Обработчик кнопки показа карты (ArcMap). В потомке передается классу ViewMapsClass
        /// </summary>
        protected override void tb_MapArcMap_Click(object sender, EventArgs e)
        {
            string patnm = string.Empty;
            if (sender is ToolStripItem && (!(sender is ToolStripMenuItem) || ((ToolStripMenuItem)sender).DropDownItems.Count == 0) && ViewMapsClass.ArcMapPatternsList != null)
            {
                patnm = (string)((ToolStripItem)sender).Tag;
            }
            int IdTmpProj = CreateMapTmpProject(patnm, true);
            if (IdTmpProj > 0)
            {
                try
                {
                    fm_ArcMapViewer.Execute(IdTmpProj, patnm, new IM.Maps.DataAdapters.MapDataAdapterExtended());
                }
                finally
                {
                    TMmPrjmapEntity.DeleteProject(IdTmpProj, true);
                }
            }
        }
        /// <summary>
        /// Создание временного проекта карты.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="patnm"></param>
        /// <returns></returns>
        private int CreateMapTmpProject(string patnm, bool isArcMap)
        {
            //Д.б. определен ID вид слоя и сетка д.б. не пустая
            if (MapLayerID.IsEmptyOrSpace() || View.Data.DataViewRows.Count == 0) return -1;
            string str = GetSelectedValues(this.KeyField, ",");
            if (str.Length == 0) return -1;
            s_NamedObjects pList = new s_NamedObjects();
            pList.Add(MapLayerID, str);
            if (isArcMap)
                return IM.Maps.Entity.TMmPrjmapEntity.CreateTmpProject(pList, patnm, true);
            else
                return IM.Maps.Entity.TMmPrjmapEntity.CreateTmpProject(pList, patnm);
        }

        protected virtual void add_image_to_PM()
        {                                                             //  imageList_MP
            //image_list.Images.Add("MP_Light", imageList_MP.Images["42a.bmp"]);
            if (ImageList == null) return;

            //ImageList.Images.Add("MP_AddFolder", imageList_MP.Images["13.png"]);
            //ImageList.Images.Add("MP_AddFolder", imageList_MP.Images["doc.png"]);

            //ImageList.Images.Add("MP_perenos", imageList_MP.Images["appointment.png"]);
            //ImageList.Images.Add("MP_perezakladka", imageList_MP.Images["cal.png"]);
            //tb_add.Image = image_list.Images["MP_AddFolder"];
            //fm_func.AddButtonOnToolStrip(bd_Navigator, "tb_doc", "sp_Navigator", true, image_list.Images["doc.png"]);
        }

        public virtual void ac_hand_card()
        {

        }
        public string hand_card = "hand_card";

        bool _privilegExcel = false;
        bool _privilegExcelGot = false;

        /// <summary>
        /// привилегия на экспорт в Эксель
        /// </summary>
        protected bool PrivilegExcel
        {
            get 
            {
                if (!_privilegExcelGot)
                {
                    _privilegExcelGot = true;
                    _privilegExcel = s_UserEntity.IsPrivGranted("EXCEL_EXPORT");
                }
                return _privilegExcel;
            }
        }

        protected override void SetupView(s_View p_View)
        {
            base.SetupView(p_View);

            //if (Data_Grid.ContextMenuStrip == null)
            //{
            //    Data_Grid.ContextMenuStrip = new ContextMenuStrip();
            //}
            //Data_Grid.ContextMenuStrip.Opening += GridContextMenu_Popup;
        }

        protected virtual void GridContextMenu_Popup(object sender, CancelEventArgs e)
        {
        }
    }
}
