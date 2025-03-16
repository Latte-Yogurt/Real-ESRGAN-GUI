using System;
using System.Windows.Forms;

namespace Real_ESRGAN_GUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(args));
            }

            catch (Exception)
            {
                Environment.Exit(0);
            }
        }
    }
}
