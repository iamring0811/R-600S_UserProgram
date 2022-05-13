using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace frmrestart
{
    public partial class Frmrestart : Form
    {
        string App = Application.StartupPath + @"\UrineAnalyzer.exe";
        string AppName = "UrineAnalyzer";//220406_3
        public Frmrestart()
        {
            InitializeComponent();

            //Process[] process = Process.GetProcessesByName(App);
            Process[] process = Process.GetProcessesByName(AppName);//220406_3
            if (process.GetLength(0) > 0)
            {
                process[0].Kill();
            }

            try
            {
                Process.Start(App);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Application.Exit();
            Environment.Exit(0);
            Process.GetCurrentProcess().Kill();
        }
    }
}
