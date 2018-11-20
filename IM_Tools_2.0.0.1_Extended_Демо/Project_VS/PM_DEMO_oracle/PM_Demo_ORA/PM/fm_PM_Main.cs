using System;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using S_;
using agsXMPP;
using IM.Hierarchy;
using IM.Hierarchy.Forms;
using IM.Classes;
using Entities;
using PM.Entity;
using PM.Forms;
using IM.Functions;
using S_.WindowsForms;
using IM.Entities;
using IM.Maps;
using IM.SplashScreen;
/*
 * 01.04.2016 ConstN Удалена кнопка button_sequence "Последовательности". Вместо нее добавлен пункт меню "Проверка последовательностей".
 *                   Добавлен пункт меню "Загрузка описаний классов"
 * 27.04.2016 ConstN подключение SplashScreen
 */
namespace PM
{
    public partial class fm_PM_Main : FormMainBase
    {
        public fm_PM_Main()
        {
            InitializeComponent();

            Disposed += new EventHandler(fm_PM_Main_Disposed);
        }

        void fm_PM_Main_Disposed(object sender, EventArgs e)
        {
            try
            {
                mainNotifyIcon.Visible = false;
            }
            finally { }
        }

        public override void SetupImages()
        {
            if (Func.Designing) return;
            SplashScreen.SetStatus("Загрузка ресурсов");
            base.SetupImages();
        }

        private MainFormReversal FormReversal;

        #region Служебные методы

        /// <summary>
        /// инициализация приложения
        /// </summary>
        /// <returns></returns>
        public override bool s_ApplicationInitializeExecute()
        {           
            if (!base.s_ApplicationInitializeExecute())
                return false;
            if (s_UserEntity.Login.ToLower().SameText("rtime_dba"))
            {
                s_MessageBox.ShowText("[W]Пользователь 'rtime_dba' не имеет права работать с этим приложением.");
                return false;
            }
            Const.res_folder = Application.StartupPath + "\\"; // +"\\res\\ru\\";

            Const.res_i_Res = Const.res_folder + Const.res_i_Res;
            Const.res_dw_Res = Const.res_folder + Const.res_dw_Res;
            Const.res_fm_Res = Const.res_folder + Const.res_fm_Res;

            // классы из Hierarchy
            //HierarchyClassRegist.Register();

            //InuMapsClassRegistration.Register();

            // классы из РМ
            //Class_Registration.Register();

            //классы из IM.ETL
            //IM.ETL.Entities.InuETLClassRegist.Register();

            if (!System.IO.File.Exists(Application.StartupPath + "\\" + "ClientJabberService.dll"))
            {
                SrRemarkEntity.no_jabber = true;
            }
            else
            {
                // рассылка через джаббер отрубается в справочнике "Исполнитель" путем добавления после логина в чате строки "nosend"
                var com = new s_DbCommand(s_DbConnection.CurrentConnectionName);
                string login = "";
                com.CommandText = " select " + SrRExecutiveEntity.ColumnLoginInChat +
                                  " from " + SrRExecutiveEntity.TableName +
                                  " where " + SrRExecutiveEntity.ColumnLogin + " = '" + s_UserEntity.Login + "'";
                try
                {
                    if (com.Open() && com.Read())
                    {
                        login = com[0].ObjToStr(); //login в чате
                        SrRemarkEntity.no_jabber = login.GetNItem(2, ";").SameStr("nosend");
                    }
                }
                finally
                {
                    com.Close();
                }
                com.Dispose();
            }

            //button_sequence.Enabled = FuncDB.IsSysAdmin(s_UserEntity.Login); //01.04.2016 ConstN 
            button_create_privs.Enabled = FuncDB.IsSysAdmin(s_UserEntity.Login);  //button_sequence.Enabled; //01.04.2016 ConstN

            //string[] args = Environment.GetCommandLineArgs();

            if (GlObjects.GlObPerformance != null && GlObjects.GlObPerformance.ParamsCommandLine.IndexOfName("h") >= 0)
            {
                this.Visible = false;
                button_Remarks_Click(null, new EventArgs());
            }

            string hint_text = this.Text;

            if (hint_text.Length > 62)
            {
                hint_text = hint_text.Substring(0, 60);
            }
            try
            {
                mainNotifyIcon.Text = hint_text;
            }
            finally
            {
            }

            return true;
        }

        /// <summary>
        /// Приложение запущено в не визуальном режиме или требутся ввод пароля
        /// </summary>
        /// <returns></returns>
        private bool IsRunUnVisual()
        {
            //анализ параметров командной строки
            var args = Environment.GetCommandLineArgs()
                .Where(x => !string.IsNullOrEmpty(x))
                .Where(x => x.Length >= 2)
                .Select(x => x.Substring(1, 1).ToUpper());

            var enumerable = args as IList<string> ?? args.ToList();

            //if (!enumerable.Any())
            //    return true;

            return //enumerable.Contains("O")
                //|| enumerable.Contains("Z")
                //|| enumerable.Contains("G")
            //    || 
            !enumerable.Contains("U");
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Hide(); //убрать формирующуюся форму с экрана.
            if (!IsRunUnVisual())
            {
                SplashScreen.ShowSplashScreen();
                SplashScreen.SetStatus("Соединение с базой данных");
            }
            base.OnLoad(e);
            //!!!Это тупая заплатка!!!
            //После восстановления положения формы, несмотря на все ухишрения this.Top становится = 0
            //При этом this.Left восстанавливается нормально. Это надо показать АЛ, но все недосуг,
            //а видеть каждый раз форму в самом верху VM неудобно.
            if (this.Top <= 0)
                this.Top = 30;
            if (this.Left <= 0)
                this.Left = 30;
            SplashScreen.CloseForm();
            this.Show();
            this.TopMost = true;
            this.TopMost = false;
            this.Activate();
            Application.DoEvents();
            
        }

        protected override void s_MenuInitializeExecute()
        {
            SplashScreen.SetStatus("Загрузка меню");
            base.s_MenuInitializeExecute();
        }

        /// <summary>
        /// Дополнительное управление некоторыми пунктами меню
        /// </summary>
        protected override void s_MenuFinalizeExecute()
        {
            base.s_MenuFinalizeExecute();
            //Пункты доступные только админам
            //1. acCheckSEQ             - Проверка последовательностей
            //2. acLoadClassDiscription - Загрузка описаний классов
            ToolStripMenuItem tsm = MenuItemByLabel("CheckSEQ");
            if (tsm != null)
            {
                tsm.Visible = FuncDB.IsSysAdmin(s_UserEntity.Login); 
            }
            tsm = MenuItemByLabel("LoadClassDiscription");
            if (tsm != null)
            {
                tsm.Visible = FuncDB.IsSysAdmin(s_UserEntity.Login);
            }
            SplashScreen.SetStatus("Формирование главной формы");
            FormReversal = new MainFormReversal(this);
            FormReversal.SetFormStyle(MainFormStyle.PANEL);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            //if(GlObjects.GlObPerformance != null && GlObjects.GlObPerformance.ParamsCommandLine.IndexOfName("h")>=0)
           //{
            //    this.Visible = false;
            //    button_Remarks_Click(null,new EventArgs());
            //}

            SetPositionToDefault();
        }
        public override void s_ApplicationFinalizeExecute()
        {
            base.s_ApplicationFinalizeExecute();
            mainNotifyIcon.Visible = false;
        }

        /// <summary>
        /// отладочный режим, при котором по кнопке "О программе"
        /// запускается отладочный код (метод ac_debug())
        /// </summary>
        bool debug_mode = false;//false;

        //fm_Remark ffm = null;
        //fm_Remark get_fm()
        //{
        //    if (ffm != null) return ffm;

        //    ffm = new fm_Remark();
        //    ffm.data.Add_Condition("123", "1=2");
        //    ffm.outer_Prepare();
        //    ffm.View.Prepare();
        //    return ffm;
        //}

        /// <summary>
        /// некие отладочные действия
        /// </summary>
        void ac_debug() 
        {
            acDynamicForms(null, null);
            //fm_Remark.Execute("PM.Forms.fm_Remark,PM");
        }

        void clear_all_objects()
        {
            s_ApplicationFinalizeExecute();

            GC.Collect(2);
            GC.WaitForPendingFinalizers();
            Application.DoEvents();
        }

        /// <summary>
        /// шифрация пароля пользователя custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void ac_shifr_pass(ToolStripMenuItem sender, string parameters)
        {
            ac_shifr_password();
        }

        /// <summary>
        /// показ формы "О программе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void ac_about(ToolStripMenuItem sender, string parameters)
        {
            if (debug_mode)
            {
                ac_debug();
            }
            else
            {
                fm_About fm_about = new fm_About();
                fm_about.ShowDialog(this);
            }
        }

        /// <summary>
        /// событие "восстановление конфигурации формы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnRestoreCofig(s_FormConfigurationObject sender, s_FormConfigurationRestoreEventArgs e)
        {
            base.OnRestoreCofig(sender, e);

            if (e.TextId.SameStr("ID_CONTRACTOR"))
            {
                int lId = e.Value.ToIntDef(-1);

                /// сохраненное в конфигурации последнее С.Ю.Л другое, заменим С.Ю.Л
                if ((lId > 0) && (lId != GlObjects.GlObPerformance.OurOrg.OurOrgId))
                    ChangeContractor(lId);
            }
        }
        /// <summary>
        /// смена текущего С.Ю.Л
        /// </summary>
        /// <param name="pIdContr"></param>
        private void ChangeContractor(int pIdContr)
        {
            if (pIdContr > 0)
            {
                CurrentOurOrg contr = new CurrentOurOrg(pIdContr);
                if (contr.ErrorStr.Length > 0)
                {
                    s_MessageBox.Show("E[MP_0002E] Ошибка выбора организации;" + contr.ErrorStr);
                    return;
                }
                GlObjects.GlObPerformance.OurOrg = contr;
                GlObjects.GlObPerformance.User.OurOrgId = contr.OurOrgId;
                GlObjects.GlObPerformance.User.OurOrgName = contr.OurOrgName;
            }
        }

        /// <summary>
        /// событие "сохранение конфигурации формы"
        /// </summary>
        /// <param name="sender"></param>
        protected override void OnSaveConfig(s_FormConfigurationObject sender)
        {
            base.OnSaveConfig(sender);

            sender.AddText("ID_CONTRACTOR", GlObjects.GlObPerformance.OurOrg.OurOrgId.ToString());
        }
        #endregion

        #region Обработчики пунктов меню. Некоторые дублируют функционал Обработчиков нажатия кнопок, некоторые новые

        /// <summary>
        /// Управление проектами (кнопка button_Remarks - Задания)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acProjectManagement(ToolStripMenuItem sender, string parameters)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                WFGraph.ShowGraph(Remarks_scheme.scheme_text);
            }
            catch
            {
            }
            finally
            {
                UnBlockForm();
                this.Show();
            }
        }

        /// <summary>
        /// Заказчики (кнопка ButtonClients)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acClients(ToolStripMenuItem sender, string parameters)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                WFGraph.ShowGraph(ClientsScheme.SchemeText);
            }
            catch
            {
            }
            finally
            {
                UnBlockForm();
                this.Show();
            }
        }

        /// <summary>
        /// Исполнители. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acExecutors(ToolStripMenuItem sender, string parameters)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                WFGraph.ShowGraph(Executors.SchemeText);
            }
            catch
            {
            }
            finally
            {
                UnBlockForm();
                this.Show();
            }

            //Это по сути оказался просто справочник Исполнитель. 
            //Из меню вызывается стандартно как справочник, метод оставлен на всякий случай.
            //s_View.RefExec("", null, null, 0, false, "", null);
        }

        /// <summary>
        /// Физические лица. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acPhysPersons(ToolStripMenuItem sender, string parameters)
        {
            if (IsBlocked()) return;
            BlockForm();
            try
            {
                WFGraph.ShowGraph(PhysPers.SchemeText);
            }
            catch
            {
            }
            finally
            {
                UnBlockForm();
                this.Show();
            }
        }

        /// <summary>
        /// Конструктор схем (кнопка button_Graf_constructor)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public override void acGrafConstructor(ToolStripMenuItem sender, string parameters)
        {
            base.acGrafConstructor(sender, parameters);
        }

        /// <summary>
        /// Список запросов к БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public override void acDatabaseQueries(ToolStripMenuItem sender, string parameters)
        {
            base.acDatabaseQueries(sender, parameters);
        }

        public override void acDynamicForms(ToolStripMenuItem sender, string parameters)
        {
            base.acDynamicForms(sender, parameters);
        }

        /// <summary>
        /// Генератор отчетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acGenReport(ToolStripMenuItem sender, string parameters)
        {
            IM.Formulas.Forms.FrmInterpretator frm = new IM.Formulas.Forms.FrmInterpretator();
            frm.ShowDialog(this);
        }

        /// <summary>
        /// Примеры отчетов. Параметром пункта меню задается xls-шаблон отчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acReports(ToolStripMenuItem sender, string parameters)
        {
            //13.04.2016 Пунктов меню, использующих этот метод пока нет.
            //При добавлении подобного пункта, помимо параметра Call - acReports надо задать параметр Parameters - <Имя xls-файла отчета>
            if (!(sender is s_ToolStripMenuItem))
                return;
            string xlsFile = (sender as s_ToolStripMenuItem).Parameters;
            if (String.IsNullOrEmpty(xlsFile))
                return;
            if (IsBlocked()) 
                return;
            BlockForm();
            try
            {
                s_NamedObjects fParam = new s_NamedObjects();
                //Какое-то спец. управление для определенных отчетов. Возможно задание значения параметров (fParam) и п.р. Пока ничего нет
                //if (sender.Text == "Отчет 1")
                //{
                //
                //}
                //else if (sender.Text == "Отчет 2")
                //{
                //
                //}
                //Вызов отчета. Возврат пока не анализирует
                IM.Formulas.FuncReport.RunInteractive(xlsFile,
                                          sender.Text,
                                          fParam,
                                          IM.Formulas.ReportParamInteractiveMode.rpimAll,
                                          IM.Formulas.ReportOutputType.rotExcel);
            }
            finally
            {
                UnBlockForm();
            }
        }

        /// <summary>
        /// Список настроек обмена данными
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acDataExchangeTuning(ToolStripMenuItem sender, string parameters)
        {
            //bool rem_1 = WFGraph.CardEditOnly;
            //bool rem_2 = WFGraph.DetailGridsCollapsed;
            //WFGraph.CardEditOnly = false;
            //WFGraph.DetailGridsCollapsed = false;
            WFGraph.ShowGraph(IM.ETL.Schemes.TuningListScheme.scheme_text, this);
            //WFGraph.CardEditOnly = rem_1;
            //WFGraph.DetailGridsCollapsed = rem_2;
        }

        /// <summary>
        /// Координаты Заказчиков (кнопка ButtonOrdinates)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acOrdinateClient(ToolStripMenuItem sender, string parameters)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                WFGraph graph = new WFGraph();
                graph.GraphProp["HideContur"] = true;
                graph.LoadFromXML(Client_Ordinate.SchemeText);
                graph.ShowGraph();
            }
            catch
            {
            }
            finally
            {
                UnBlockForm();
                this.Show();
            }
        }

        /// <summary>
        /// Координаты Исполнителей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acOrdinateExecutor(ToolStripMenuItem sender, string parameters)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                WFGraph graph = new WFGraph();
                graph.GraphProp["HideContur"] = true;
                graph.LoadFromXML(ExecutorsOrdinate.SchemeText);
                graph.ShowGraph();
            }
            catch
            {
            }
            finally
            {
                UnBlockForm();
                this.Show();
            }
        }

        /// <summary>
        /// Список проектов карт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acMapProjectList(ToolStripMenuItem sender, string parameters)
        {
            IM.Maps.Forms.MmPrjmapScheme ob = new IM.Maps.Forms.MmPrjmapScheme();
            WFGraph.ShowGraph(ob.GetText(), this);
            ob = null;         
        }

        /// <summary>
        /// Журнал системы (кнопка button_log)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acProjectLog(ToolStripMenuItem sender, string parameters)
        {
            //Напрямую метод предка ac_log_scheme меню АЛ не понимает.
            //Надо здесь переопределить его типа
            //        public override void ac_log_scheme(ToolStripMenuItem sender, string parameters)
            //        {
            //            base.ac_log_scheme(sender, parameters);
            //        }
            //но на мой взгляд у метода неудачное название, поэтому сделал свой, который и вызовет ac_log_scheme
            ac_log_scheme(sender, parameters);
        }

        /// <summary>
        /// Настройка интерфейса, установка цветов (кнопка button_User_Colors)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acSetInterface(ToolStripMenuItem sender, string parameters)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                SelectColors_(null, "");
            }
            finally
            {
                UnBlockForm();
            }
        }


        /*
         
         */

        #endregion

        #region Обработчики нажатия кнопок на главной форме. Функционал перенесен в Обработчики пунктов меню (см. выше)
        /// <summary>
        /// Задания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Remarks_Click(object sender, EventArgs e)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                WFGraph.ShowGraph(Remarks_scheme.scheme_text);
            }
            catch 
            {
            }
            finally
            {
                UnBlockForm();
                this.Show();
            }
        }
        /// <summary>
        /// о программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_about_Click(object sender, EventArgs e)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                ac_about(null, "");
            }
            finally
            {
                UnBlockForm();
            }
        }
        /// <summary>
        /// смена цветов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_User_Colors_Click(object sender, EventArgs e)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                SelectColors_(null, "");
            }
            finally
            {
                UnBlockForm();
            }
        }
        /// <summary>
        /// конструктор схем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Graf_constructor_Click(object sender, EventArgs e)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                ConstrXMLSchemeForms();
            }
            finally
            {
                UnBlockForm();
            }
        }
        /// <summary>
        /// последовательности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_sequence_Click(object sender, EventArgs e)
        {
            //if (IsBlocked()) return;

            //BlockForm();
            //try
            //{
            //  FuncDB.CheckSEQ(); //01.04.2016 ConstN устарело, если надо можно вызвать WFGraph.ShowGraph(ListSEQ_scheme_xml.scheme_text, this);, но вообще-то кнопку убираю
            //}
            //finally
            //{
            //    UnBlockForm();
            //}
        }

        /// <summary>
        /// Проверка последовательностей (вызов из меню, метка CheckSEQ)
        /// </summary>
        public void acCheckSEQ(ToolStripMenuItem sender, string parameters)
        {
            WFGraph.ShowGraph(ListSEQ_scheme_xml.scheme_text, this);
            //funcDB.CheckSEQ();
        }

        /// <summary>
        /// Загрузка описаний классов (вызов из меню, метка LoadClassDiscription)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameters"></param>
        public void acLoadClassDiscription(ToolStripMenuItem sender, string parameters)
        {
            WFGraph.ShowGraph(ListEntityClass_scheme_xml.scheme_text, this);
        }

        /// <summary>
        /// создание привилегий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_create_privs_Click(object sender, EventArgs e)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                ac_create_privs(null, null);
            }
            finally
            {
                UnBlockForm();
            }
        }
        #endregion

        private void fm_PM_Main_DoubleClick(object sender, EventArgs e)
        {
        #if DEBUG
            ac_debug();
        #endif
        }

        private int _countMarkCur = -1;
        private int _countMarkPred = -1;
        private int _countMarkFast = -1;
        
        
        private DateTime _dateLastCheck = Convert.ToDateTime("01.01.1753");
        /// <summary>
        /// Разрешает или запрещает проверку кол-ва сообщений
        /// </summary>
        public static bool CheckMsg = true;

        private void timerForCheckMsg_Tick(object sender, EventArgs e)
        {
            if (!CheckMsg) return;

            CheckMsg = false;
            s_DbCommand _q = new s_DbCommand(s_DbConnection.CurrentConnectionName);
            DateTime _dateLastInput = Convert.ToDateTime("01.01.1753");

            _q.CommandText =
            "SELECT  COUNT(*) count,MAX(DATE_INPUT_SRRM) dateLastInput " +
            "FROM  " + "SR_REMARK_SRRM".ToFullTableName() + 
            " JOIN " + "SR_R_EXECUTIVE_SREX".ToFullTableName() + " ON SR_REMARK_SRRM.ID_WHOM_SRRM = SR_R_EXECUTIVE_SREX.ID_SR_R_EXECUTIVE_SREX " +
            "and LOGIN_SREX = :login ";
            _q.ParamByName("login").Value = s_UserEntity.Login;
            try
            {
                if (_q.Open() && _q.Read())
                {
                    _dateLastInput = Func.DateInOut(_q["dateLastInput"], true);
                    _countMarkCur = _q["count"].ObjToID();
                }
            }
            catch { }
            finally
            {
                if (!_q.IsClosed) _q.Close();
            }

            //по таймеру проверяем кол-во сообщений
            //при первом счете ничего не показываем
            if (_countMarkCur > _countMarkPred && _countMarkPred != -1)
            {
                _countMarkFast = 0;
                _q.CommandText =
              "SELECT  COUNT(*) count " +
             "FROM  " + "SR_REMARK_SRRM".ToFullTableName() + " " +
             " JOIN " + "SR_R_EXECUTIVE_SREX".ToFullTableName() + " ON SR_REMARK_SRRM.ID_WHOM_SRRM = SR_R_EXECUTIVE_SREX.ID_SR_R_EXECUTIVE_SREX " +
             "join " + "SR_R_PROMPTNESS_SRPR".ToFullTableName() + " ON SR_REMARK_SRRM.ID_SR_R_PROMPTNESS_SRRM = SR_R_PROMPTNESS_SRPR.ID_SR_R_PROMPTNESS_SRPR " +
             "and LOGIN_SREX = :login " +
             "and DATE_INPUT_SRRM >:dateLastCheck " +
             "and NUMBER_PP_SRPR = 1"; //срочные
                _q.ParamByName("dateLastCheck").Value = _dateLastCheck;
                _q.ParamByName("login").Value = s_UserEntity.Login;

                _countMarkFast = _q.ExecuteScalar().ObjToID();
                if (_countMarkFast == -1)
                    _countMarkFast = 0;
                _q.Close();
                //узнаем сколько срочных 
                mainNotifyIcon.ShowBalloonTip(130000, "У вас новое задание",
                    string.Format("Количество новых заданий: {0} \n Количество новых срочных : {1} ", _countMarkCur - _countMarkPred, _countMarkFast), ToolTipIcon.Info);

            }
            _q.Dispose();
            _countMarkPred = _countMarkCur;
            _dateLastCheck = _dateLastInput;
            CheckMsg = true;
        }

        //осталось для запуска таймера, срабатывает при входе в форму заданий
        //а вообще вместе с методом MouseDoubleClick должен добавлять и удалять значек из трея, а так же останавливать и запускать таймер
        //сейчас значек горит всегда
        private void fm_PM_Main_Deactivate(object sender, EventArgs e)
        {
            //свернуть трей
            if (this.WindowState == FormWindowState.Minimized)
            {
                //this.ShowInTaskbar = false;
                mainNotifyIcon.Visible = true;
                timerForCheckMsg.Start();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            mainNotifyIcon.Visible = false;
            
            base.OnClosed(e);
        }

        public void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Form fm;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                fm = Application.OpenForms[i];
                if (fm.Visible)
                {
                    if (fm.WindowState == FormWindowState.Minimized)
                        fm.WindowState = FormWindowState.Normal;
                    if (fm.TopLevel)
                        fm.Activate();
                }
            }
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            ac_log_scheme(null, null);
        }

        private void ButtonOrdinates_Click(object sender, EventArgs e)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                WFGraph.ShowGraph(Client_Ordinate.SchemeText);
            }
            catch
            {
            }
            finally
            {
                UnBlockForm();
                this.Show();
            }
        }

        private void ButtonClients_Click(object sender, EventArgs e)
        {
            if (IsBlocked()) return;

            BlockForm();
            try
            {
                WFGraph.ShowGraph(ClientsScheme.SchemeText);
            }
            catch
            {
            }
            finally
            {
                UnBlockForm();
                this.Show();
            }
        }

        private void fm_PM_Main_Shown(object sender, EventArgs e)
        {
           // SplashScreen.CloseForm();
           //             this.TopMost = true;
           //             this.TopMost = false;
           //             this.Focus();
           //             Application.DoEvents();

        }
        
        /*
        //не используется но может быть полезен(остановка таймер, разворачивание формы, и убирание значка из трея)
        private void mainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //востановление из трея
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                mainNotifyIcon.Visible = false;
                timerForCheckMsg.Stop();
            }
        }
         */
    }
}
