using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Collections;
using S_;
using IM.Hierarchy;
using IM.Hierarchy.Forms;

namespace PM.Forms
{
    public partial class fm_About : Form
    {
        IM.Hierarchy.u_AssemblyInformation info;

        public fm_About()
        {
            InitializeComponent();
            info = new IM.Hierarchy.u_AssemblyInformation();

            string fileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            if (fileName.Contains(".vshost"))
                fileName = fileName.Replace(".vshost", "");
            Description.Text = "Дата сборки: " + info.RetrieveLinkerTimestamp(fileName);//string.Format("{0}\\SF.exe", Application.StartupPath)); 
            lProductVersion.Text = "Версия продукта: " + info.AssemblyVersion;
            MainModulVersion.Text = "Главный модуль сборка: " + info.AssemblyFileVersion;
            // Company.Text = AssemblyCopyright + " " + info.AssemblyCompany;
            string lVer = IM.Classes.GlObjects.GlObPerformance.DB_Version;
            if (String.IsNullOrEmpty(lVer))
                lbDBVer.Text += "нет данных";
            else
                lbDBVer.Text += lVer;
            //linkLabel_website.Text = "www.inu.su";
            //label_ContactData.Text = "mail@inu.su \r\n" + "тел. 8-473-252-15-73 \r\n" + "факс 8-473-252-68-90";

            this.ShowInTaskbar = false;
        }
        
        private void linkLabel_website_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string SndName = ((LinkLabel)sender).Name;
            if (SndName == "lURL")
            {
                System.Diagnostics.Process.Start("http://www.inu.su");
            }
            else if (SndName == "lEmail")
            {
                System.Diagnostics.Process.Start("mailto://mail@inu.su");
            }
        }

        public ArrayList GetAssemblies()
        {
            ArrayList assemblies = new ArrayList();
            try
            {
                string[] dir = Directory.GetDirectories(Application.StartupPath);
                string[] files;

                //first loop through all the directories in the
                //GAC directory
                foreach (string str in dir)
                {
                    //on each iteration set the sub directory to
                    //the current sub directory
                    string[] subDir = Directory.GetDirectories(str);

                    //loop through all sub directories
                    foreach (string sub in subDir)
                    {
                        //get a string array of all the DLL files in the sub directory
                        files = Directory.GetFiles(sub, "*.dll");
                        //now we loop through each file
                        foreach (string file in files)
                        {
                            //add it to our ArrayList
                            assemblies.Add(file);
                        }
                    }
                }

                files = Directory.GetFiles(Application.StartupPath, "*.exe");
                foreach (string file in files)
                {
                    assemblies.Add(file);
                }

                files = Directory.GetFiles(Application.StartupPath, "*.dll");
                foreach (string file in files)
                {
                    assemblies.Add(file);
                }

                return assemblies;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        } 
        private void bt_modules_Click(object sender, EventArgs e)
        {
            /*
            ArrayList al = GetAssemblies();
            if (al == null) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("col_1", typeof(string));
            dt.Columns.Add("col_2", typeof(string));
            dt.Columns.Add("col_3", typeof(string));
            dt.Columns.Add("col_4", typeof(string));

            object[] dr = new object[4];

            FileVersionInfo fvi;
            foreach (string s in al)
            {
                fvi = FileVersionInfo.GetVersionInfo(s);
                if (fvi == null) continue;
                
                dr[0] = fvi.InternalName;
                dr[1] = s;
                dr[2] = fvi.FileVersion;
                dr[3] = File.GetLastWriteTime(s);

                dt.Rows.Add(dr);
            }

            FormLow.Execute(dt, "Имя модуля;Имя файла;Версия файла;Время изменения;");
            /**/ 
            DataTable dt = info.GetModulesAsDataTable(true, 1);
            if (dt != null)
                FormLow.Execute(dt, "Имя модуля;Имя файла;Версия файла;Версия модуля;Время изменения;", info.AssemblyProduct + ". Список модулей");

        }
    }
}