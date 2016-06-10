using CardSolutionHost.Core;
using CardSolutionHost.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace CardSolutionHost
{
    public static class Program
    {
        public static Mutex RunMutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isNotRun = false;
            RunMutex = new Mutex(true, "CardSolutionHost", out isNotRun);
            if (!isNotRun) return;
            Logger.Writer.Write("启动");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //处理未捕获的异常   
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常   
            Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常   
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            var mainForm = ServiceLoader.LoadService<IMenJinHost>() as MainForm;
            mainForm.RunMutex = RunMutex;
            Application.Run(mainForm);
        }


        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            if (ex != null)
            {
                Logger.Writer.Write(ex, TraceEventType.Critical);
                throw ex;
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                Logger.Writer.Write(ex, TraceEventType.Critical);
                throw ex;
            }
        }
    }
}
