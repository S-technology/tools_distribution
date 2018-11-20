using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using S_;
using S_.WindowsForms;
using IM.Classes;
using IM.Functions;
using PM.Entity;
using IM.Hierarchy;
using IM.Hierarchy.Forms;

namespace PM
{
    /// <summary>
    /// Преобразование меню главной формы в панель. Проект PM, тип главной формы fm_PM_Main
    /// </summary>
    public class MainFormReversal : CustomMainFormReversal
    {
//        private string m_OldCapton;
        //public bool prCopyDB;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pMainForm"></param>
        public MainFormReversal(fm_PM_Main pMainForm)
            : base(pMainForm)
		{
            //prCopyDB = false;
            AddSettingButton.Add("ac_about", "О программе");
		}

        /// <summary>
        /// Спец. настройки для проекта PM
        /// </summary>
        protected override void SetDefault()
        {
            base.SetDefault();
            LeftSpace = 5;
            BtnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            BtnSize = new System.Drawing.Size(240, 26);           
        }

        /// <summary>
        /// На базе меню стоим панель с кнопками
        /// </summary>
        protected override bool CreatePanel()
        {
            ToolStripMenuItem mmm;
            if (f_panel_created) //панель уже сформирована
            {
                for (int i = 0; i < f_MainMenu.Items.Count; i++)
                {
                    mmm = (ToolStripMenuItem)f_MainMenu.Items[i];
                    for (int j = 0; j < mmm.DropDownItems.Count; j++)
                    {
                        ToolStripMenuItem miDropDown = (ToolStripMenuItem)mmm.DropDownItems[j];
                        if (miDropDown.Text.SameStr("Примеры отчетов"))
                            MoveItemInContextMenu(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuReport);
                        if (miDropDown.Text.SameStr("Настройка системы"))
                            MoveItemInContextMenu(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuSetting);
                        if (miDropDown.Text.SameStr("Справочники"))
                            MoveItemInContextMenu(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuRef);
                        if (miDropDown.Text.SameStr("Настройки разработчика"))
                            MoveItemInContextMenu(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuSettingDeveloper);
                        //miDropDown.Visible = false;
                    }
                }
                return false;
            }
            GroupBox gb;
            Button btn;
            BtnColumnCount = 3;
            for (int i = 0; i < f_MainMenu.Items.Count; i++)
            {
                mmm = (ToolStripMenuItem)f_MainMenu.Items[i];
                if (!mmm.Text.SameText("Управление системой") && !CheckWorkMenuItem(mmm)) 
                    continue;
                gb = CreateGB(mmm.Text);
                for (int j = 0; j < mmm.DropDownItems.Count; j++)
                {
                    ToolStripMenuItem miDropDown = (ToolStripMenuItem)mmm.DropDownItems[j];
                    if (miDropDown.Text.SameStr("Примеры отчетов")
                        || miDropDown.Text.SameStr("Настройка системы")
                        || miDropDown.Text.SameStr("Справочники")
                        || miDropDown.Text.SameStr("Настройки разработчика"))
                    {
                        if (CheckWorkMenuItem(miDropDown))
                        {
                            switch (miDropDown.Text)
                            {
                                case "Примеры отчетов":
                                    MoveItemInContextMenu(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuReport);
                                    btn = CreateBtn(gb, "btnReports", miDropDown.Text, "Reports");
                                    btn.Click += myShowContextMenu;
                                    btn.ContextMenuStrip = ((fm_PM_Main)f_MainForm).contextMenuReport;
                                    break;
                                case "Настройка системы":
                                    MoveItemInContextMenu(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuSetting);
                                    btn = CreateBtn(gb, "btnSetting", miDropDown.Text, "Setting");
                                    btn.Click += myShowContextMenu;
                                    btn.ContextMenuStrip = ((fm_PM_Main)f_MainForm).contextMenuSetting;
                                    break;
                                case "Справочники":
                                    MoveItemInContextMenu(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuRef);
                                    btn = CreateBtn(gb, "btnRef", miDropDown.Text, "Image_Ref");
                                    btn.Click += myShowContextMenu;
                                    btn.ContextMenuStrip = ((fm_PM_Main)f_MainForm).contextMenuRef;
                                    break;
                                case "Настройки разработчика":
                                    MoveItemInContextMenu(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuSettingDeveloper);
                                    btn = CreateBtn(gb, "btnSettingDeveloper", miDropDown.Text, "SettingDeveloper");
                                    btn.Click += myShowContextMenu;
                                    btn.ContextMenuStrip = ((fm_PM_Main)f_MainForm).contextMenuSettingDeveloper;
                                    break;
                            }
                        }
                        continue;
                    }
                    string mt = GetMetodMenuItem(miDropDown);
                    if (string.IsNullOrEmpty(mt)) //нет параметра Call для этого пункта или пункт недоступен
                        continue;
                    //Установим картинку (если есть) и на пункт меню. Что нам жалко что ли?
                    if (MainFormImageList.Images["Image_" + mt.Substring(2)] != null)
                        miDropDown.Image = MainFormImageList.Images["Image_" + mt.Substring(2)];
                    btn = CreateBtn(gb, "btn_" + mt, miDropDown.Text, "Image_" + mt.Substring(2));
                    btn.Tag = mt;
                    btn.Click += new EventHandler(BtnClick);
                }
            }
            f_panel_created = true;
            return true;
        }

        /// <summary>
        /// Вызовы контекстных меню по кнопкам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myShowContextMenu(object sender, EventArgs e)
        {
            string btnName = ((Button)sender).Name;
            if (btnName.SameText("btnReports"))
            {
                if (((fm_PM_Main)f_MainForm).contextMenuReport.Items.Count > 0)
                    ((fm_PM_Main)f_MainForm).contextMenuReport.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            else if (btnName.SameText("btnSetting"))
            {
                if (((fm_PM_Main)f_MainForm).contextMenuSetting.Items.Count > 0)
                    ((fm_PM_Main)f_MainForm).contextMenuSetting.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            else if (btnName.SameText("btnRef"))
            {
                if (((fm_PM_Main)f_MainForm).contextMenuRef.Items.Count > 0)
                    ((fm_PM_Main)f_MainForm).contextMenuRef.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            else if (btnName.SameText("btnSettingDeveloper"))
            {
                if (((fm_PM_Main)f_MainForm).contextMenuSettingDeveloper.Items.Count > 0)
                    ((fm_PM_Main)f_MainForm).contextMenuSettingDeveloper.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        /// <summary>
        /// дополнительные 2 мелкие кнопки в первом GroupBox
        /// </summary>
        /// <param name="pParent"></param>
        protected override void CreateAddSmallButton(Control pParent)
        {
            Button bt;
            //ac_about
            int x = LeftSpace + ((BtnMargin.Left > BtnMargin.Right ? BtnMargin.Left : BtnMargin.Right) * f_BtnColumnCountMax) + BtnSize.Width * f_BtnColumnCountMax + BtnMargin.Right * 3;
            /*
            if (AddSettingButton.Count > 0 && AddSettingButton[AddSettingButton.Count - 1].ToString().SameStr("О программе"))
            {
                string met = AddSettingButton.Names[AddSettingButton.Count - 1];
                bt = CreateBtn(pParent, new Point(x, BtnMargin.Top + TopSpace), "btn_" + met, "", "Image_" + met);
                bt.Size = new Size(BtnSize.Height, BtnSize.Height);
                bt.FlatStyle = FlatStyle.Popup;
                bt.Click += ((fm_PM_Main)f_MainForm).button_about_Click;
                f_ToolTip.SetToolTip(bt, AddSettingButton[AddSettingButton.Count - 1].ToString());
            }
            */
            if (AddSettingButton.Count > 0 && AddSettingButton[AddSettingButton.Count - 1].ToString().SameStr("О программе"))
            {
                string met = AddSettingButton.Names[AddSettingButton.Count - 1];
                bt = CreateBtn(pParent, new Point(x, BtnMargin.Top + TopSpace), "btn_" + met, "", "Image_" + met);
                bt.Size = new Size(BtnSize.Height, BtnSize.Height);
                bt.FlatStyle = FlatStyle.Popup;
                bt.Tag = "M_" + met;
                bt.Click += new EventHandler(this.BtnClick);
                f_ToolTip.SetToolTip(bt, AddSettingButton[AddSettingButton.Count - 1].ToString());
            }

            bt = CreateBtn(pParent, new Point(x + BtnSize.Height + 5, BtnMargin.Top + TopSpace), "btn_Exit", "", "s_Exit");
            bt.Size = new Size(BtnSize.Height, BtnSize.Height);
            bt.Margin = new Padding(0, 0, 5, 0);
            //bt.Padding = new Padding(0);
            bt.FlatStyle = FlatStyle.Popup;
            bt.Click += ((fm_PM_Main)f_MainForm).button_exit_Click;
            f_ToolTip.SetToolTip(bt, "Выход");
        }

        /// <summary>
        /// Возвращаем пункты "Примеры отчетов", "Настройка системы", "Справочники" и "Настройки разработчика" из контекстных меню
        /// </summary>
        /// <returns></returns>
        protected override bool SetMenuStyleUser()
        {
            ToolStripMenuItem mmm;
            for (int i = 0; i < f_MainMenu.Items.Count; i++)
            {
                mmm = (ToolStripMenuItem)f_MainMenu.Items[i];
                //mmm.Visible = true;
                if (mmm.Text.SameStr("Отчеты")|| mmm.Text.SameStr("Управление системой"))
                {
                    for (int j = 0; j < mmm.DropDownItems.Count; j++)
                    {
                        ToolStripMenuItem miDropDown = (ToolStripMenuItem)mmm.DropDownItems[j];
                        if (miDropDown.Text.SameStr("Примеры отчетов")
                            || miDropDown.Text.SameStr("Настройка системы")
                            || miDropDown.Text.SameStr("Справочники")
                            || miDropDown.Text.SameStr("Настройки разработчика"))
                        {
                            switch (miDropDown.Text)
                            {
                                case "Примеры отчетов":
                                    MoveContextMenuInItem(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuReport);
                                    break;
                                case "Настройка системы":
                                    MoveContextMenuInItem(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuSetting);
                                    break;
                                case "Справочники":
                                    MoveContextMenuInItem(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuRef);
                                    break;
                                case "Настройки разработчика":
                                    MoveContextMenuInItem(miDropDown, ((fm_PM_Main)f_MainForm).contextMenuSettingDeveloper);
                                    break;
                            }
                            
                        }
                        //miDropDown.Visible = true;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Устанвливаем в заголовке название базовой АЕ
        /// </summary>
        /// <param name="debug_mode"></param>
        public override void ChangeFormCaption(bool debug_mode = false)
        {           
            base.ChangeFormCaption(debug_mode);
            /*
            if (String.IsNullOrEmpty(m_OldCapton))
                m_OldCapton = "Система МИСП «Волость»";
            f_MainForm.Text = m_OldCapton;
            using (s_DbCommand Q = new s_DbCommand())
            {
                Q.CommandText
                   = "SELECT ae.NAME_FULL_AEMP NAME_FULL "
                   + "FROM " + s_Extensions.ToFullTableName("AE_ADM_UNIT_AEMP") + " ae "
                   + "where " + AeAdmUnitEntity.ColumnIdAeAdmUnit + "=:idBaseAe";
                Q.ParamByName("idBaseAe").Value = AeAdmUnitEntity.GetIdBaseAe(); // fix 12682
                string cap = Q.ExecuteScalar().ObjToStr();
                if (!cap.IsEmptyOrSpace())
                    f_MainForm.Text += ". " + cap;
            }
            if (debug_mode)
                f_MainForm.Text += ". Внимание! Программа запущена в режиме отладки!";
             */ 
        }

        /// <summary>
        /// Проверка доступности пункта меню по метке
        /// </summary>
        /// <param name="pLabel">Метка пункта меню</param>
        /// <param name="pSetUnVisible">Сделать недоступный пункт невидимым</param>
        /// <returns></returns>
        public override int CheckEnabledMemuItemByLabel(string pLabel, bool pSetUnVisible = true)
        {
            int res = base.CheckEnabledMemuItemByLabel(pLabel, pSetUnVisible);
            if (res > 0)
            {
                res = -1;
                pLabel = pLabel.ToUpper();
                ToolStripMenuItem tsm = f_MainForm.MenuItemByLabel(pLabel);
                if (tsm != null)
                {
                    bool en = tsm.Enabled;
                    //Пункты доступные только s_dba
                    //1. ac_create_privs     - Создание привилегий
                    //3. acDescrForImpGetter - Загрузка описаний классов для импорта
                    if (pLabel.SameStr("PRIV") || pLabel.SameStr("LoadClassDiscription") || pLabel.SameStr("Build_CheckSEQ")) //
                        en = s_UserEntity.Login.SameStr("S_DBA");
                    //Пункты доступные s_dba и rtime_dba
                    //1. ConstrXMLSchemeForms - Конструктор XML схем
                    //2. ac_TuningList        - Настройка обмена
                    //3. ac_DeleteErrAE       - Удаление ошибочных АЕ
                    //4. acCheckSEQ           - Проверка последовательностей
                    //5. ac_GenReport         - Генератор отчетов
                    else if (pLabel.SameStr("CONSRT_XML")
                        || pLabel.SameStr("TUNING_LIST")
                        || pLabel.SameStr("DELETEERRAE")
                        || pLabel.SameStr("DELETEERRPOKAZAE")
                        || pLabel.SameStr("GenReport")
                        )
                        en = s_UserEntity.Login.SameStr("S_DBA") ||
                             s_UserEntity.Login.SameStr("RTIME_DBA");
                    if (en)
                        res = 1;
                    else
                    {
                        if (pSetUnVisible)
                            tsm.Visible = false;
                        res = 0;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Картинки для кнопок
        /// </summary>
        protected override void AddImages()
        {
            //Картинки для кнопок главного меню (по именам методов)
            //MainFormImageList.Images.Add("Image_acProjectManagement", PM.Properties.Resources.Book_Open_Blue);
            MainFormImageList.Images.Add("Image_acProjectManagement", PM.Properties.Resources.Book_Forder);
            MainFormImageList.Images.Add("Image_acClients", PM.Properties.Resources.userClient);
            MainFormImageList.Images.Add("Image_acExecutors", PM.Properties.Resources.peoples);
            //MainFormImageList.Images.Add("Image_acPhysPersons", PM.Properties.Resources.Contact_16_h_p);
            MainFormImageList.Images.Add("Image_acPhysPersons", PM.Properties.Resources.id_card);
            MainFormImageList.Images.Add("Image_acGrafConstructor", PM.Properties.Resources.branch_element_new);
            MainFormImageList.Images.Add("Image_acDatabaseQueries", PM.Properties.Resources.funnel_new);
            MainFormImageList.Images.Add("Image_acGenReport", PM.Properties.Resources.documents_gear);
            MainFormImageList.Images.Add("Reports", PM.Properties.Resources.documents_new);
            MainFormImageList.Images.Add("Image_acDataExchangeTuning", PM.Properties.Resources.ED);
            MainFormImageList.Images.Add("Image_acOrdinateClient", s_Application.Image16List.Images["Ordinatexyh"]);
            MainFormImageList.Images.Add("Image_acOrdinateExecutor", PM.Properties.Resources.Scatter_Graph_16_h_p);
            MainFormImageList.Images.Add("Image_acMapProjectList", PM.Properties.Resources.MapProject);
            MainFormImageList.Images.Add("Image_Ref", PM.Properties.Resources.books_blue);
            //MainFormImageList.Images.Add("Image_Ref", PM.Properties.Resources.dictionary);
            MainFormImageList.Images.Add("Setting", PM.Properties.Resources.colors);
            MainFormImageList.Images.Add("SettingDeveloper", PM.Properties.Resources.settings);
            MainFormImageList.Images.Add("Image_ac_about", PM.Properties.Resources.About);
            MainFormImageList.Images.Add("Image_acDynamicForms", s_Application.Image16List.Images["Window"]);
        }
    }

}
