﻿using CardSolutionHost.Core;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace CardSolutionHost
{
    static class Program
    {
        static System.Threading.Mutex RunMutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isNotRun = false;
            RunMutex = new System.Threading.Mutex(true, "CardSolutionHost", out isNotRun);
            if (!isNotRun) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //处理未捕获的异常   
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常   
            Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常   
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            if (ex != null)
            {
                Logger.Writer.Write(ex, TraceEventType.Critical);
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                Logger.Writer.Write(ex, TraceEventType.Critical);
            }
        }
    }
}