using System;
using System.Windows.Forms;
using S_.WindowsForms;
using S_;

namespace PM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //s_WinApplication.SetProjectID("PM");

            s_WinApplication.IniOptions =       
                s_ApIniOption.ChangePassword
                | s_ApIniOption.ActiveLog
                | s_ApIniOption.Session
                | s_ApIniOption.EnglishPassword
                ;

            Application.Run(new fm_PM_Main());
        }
    }
}
