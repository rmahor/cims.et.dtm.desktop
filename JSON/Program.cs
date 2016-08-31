using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETGlobalVar;
using System.Configuration;
using System.Diagnostics;

using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace JSON
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            shoAppSetting();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
        static void shoAppSetting()
        {
            GlobalV.IniVar.gstrDBName = ConfigurationSettings.AppSettings.Get("strDBName");
            GlobalV.IniVar.gstrServerName = ConfigurationSettings.AppSettings.Get("strServerName");
        }

    }
}
