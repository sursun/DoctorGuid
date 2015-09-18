using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DoctorGuid
{
    static class Program
    {
        //[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        //public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        //[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        //public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Process[] tProcess = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            

            if (tProcess.Length > 1)
            {
                
                int nCurProcessId = Process.GetCurrentProcess().Id;
                foreach (var p in tProcess)
                {
                    if (nCurProcessId != p.Id)
                    {
                        HKWin32.ShowWindow(p.MainWindowHandle, 9);

                        HKWin32.SetForegroundWindow(p.MainWindowHandle);
                    }
                }

                Application.Exit();
            }
            else
            {
                Application.Run(new FormMain());
            }
        }
    }
}
