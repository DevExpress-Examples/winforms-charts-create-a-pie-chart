Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace Series_PieChart
    Friend Module Program
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            WindowsFormsSettings.SetDPIAware()
            WindowsFormsSettings.AllowDpiScale = True
            WindowsFormsSettings.AllowAutoScale = DevExpress.Utils.DefaultBoolean.True
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New Form1())
        End Sub
    End Module
End Namespace