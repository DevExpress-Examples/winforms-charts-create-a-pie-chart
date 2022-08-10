using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Series_PieChart {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            WindowsFormsSettings.SetDPIAware();
            WindowsFormsSettings.AllowDpiScale = true;
            WindowsFormsSettings.AllowAutoScale = DevExpress.Utils.DefaultBoolean.True;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}