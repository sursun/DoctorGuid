using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DoctorGuid
{
    public static class HKWin32
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        
        [DllImport("user32", EntryPoint = "GetWindowThreadProcessId")]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int pid);
    }
}
