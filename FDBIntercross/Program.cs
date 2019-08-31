using DBLogic.Model;
using System;
using System.Threading;
using System.Windows.Forms;

namespace FDBIntercross
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += ApplicationExit;
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new MIntercross());
        }

        private static void ApplicationExit(object sender, EventArgs e)
        {
            FileBaseModel.Save();
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs t)
        {
            MessageBox.Show(t.Exception.Message + "\n\n请联系管理员！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
