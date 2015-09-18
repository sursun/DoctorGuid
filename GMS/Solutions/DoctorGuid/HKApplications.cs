using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DoctorGuid
{
    public class HKApplications
    {
        public AppItem[] AppItems { get; set; }
    }

    public enum AppTypeEnum
    {
        Exe,
        Explorer
    }

    public class AppItem
    {
        public AppItem()
        {
            this.AppType = AppTypeEnum.Exe.ToString();
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// exe
        /// explorer
        /// </summary>
        public string AppType { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 运行参数
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 进程名称
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 图标名称
        /// </summary>
        public string Icon { get; set; }

        public void ToLower()
        {
            this.AppType = this.AppType.ToLower();
            this.FileName = this.FileName.ToLower();
            this.ProcessName = this.ProcessName.ToLower();
        }
    }

    public class AppItemObject
    {
        public AppItemObject(AppItem item, string ico_path,Boolean isDefault)
        {
            AppItem = item;
            _image = null;
            _iconPath = ico_path;

            IsDefault = isDefault;
        }

        private readonly string _iconPath;

        public Boolean IsDefault { get; set; }

        public AppItem AppItem { get; set; }

        private Image _image { get; set; }

        public Image GetImage()
        {
            if (_image != null) 
                return _image;

            try
            {
                _image = Image.FromFile(_iconPath + AppItem.Icon);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            if (_image != null) return _image;

            if (AppItem.AppType.Equals(AppTypeEnum.Exe.ToString()))
            {
                _image = global::DoctorGuid.Properties.Resources.exe;
            }
            else
            {
                _image = global::DoctorGuid.Properties.Resources.explorer;
            }

            return _image;
        }

        private readonly ParameterizedThreadStart _parStart = new ParameterizedThreadStart(ThreadMethod);
        private Thread _myThread = null;

        public void Start()
        {
            try
            {
                //Process process = new Process();
                //process.StartInfo.FileName = AppItem.FileName;
                //process.StartInfo.Arguments = AppItem.Url;
                ////process.StartInfo.UseShellExecute = false;
                //process.Start();

                if (AppItem.AppType.Equals(AppTypeEnum.Exe.ToString()))
                {
                    Process.Start(AppItem.FileName, AppItem.Url);
                }
                else
                {
                    //火狐单独处理
                    if (!AppItem.FileName.Contains("firefox"))
                    {
                        Process.Start(AppItem.FileName, AppItem.Url);
                        return;
                    }

                    if (_myThread != null && _myThread.IsAlive)
                    {
                        _myThread.Abort();
                    }

                    _myThread = new Thread(_parStart);

                    AppItem obj = new AppItem();
                    obj.ProcessName = AppItem.ProcessName;
                    obj.FileName = AppItem.FileName;
                    obj.Url = AppItem.Url;

                    _myThread.Start(obj);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private static void ThreadMethod(object obj)
        {
            try
            {
                AppItem parObject = (AppItem)obj;

                Boolean bFind = false;
                Boolean bStarted = false;

                while (true)
                {
                    if (bStarted == false)
                    {
                        //没有启动过，开始启动
                        bStarted = true;

                        Process p = Process.Start(parObject.FileName);

                        HKWin32.ShowWindow(p.MainWindowHandle, 9);

                        HKWin32.SetForegroundWindow(p.MainWindowHandle);

                        Thread.Sleep(1000);
                    }

                    Process[] processes = Process.GetProcessesByName(parObject.ProcessName);
                    if (processes.Length > 0)
                    {
                        //
                        IntPtr hWnd = IntPtr.Zero;
                        hWnd = HKWin32.GetForegroundWindow();

                        int nProcessId;
                        HKWin32.GetWindowThreadProcessId(hWnd, out nProcessId);
                        Process process = Process.GetProcessById(nProcessId);
                        if (process.ProcessName.ToLower().Equals(parObject.ProcessName.ToLower()))
                        {
                            bFind = true;
                            break;
                        }

                        foreach (var p in processes)
                        {
                            HKWin32.ShowWindow(p.MainWindowHandle, 9);

                            HKWin32.SetForegroundWindow(p.MainWindowHandle);
                        }
                    }

                    Thread.Sleep(2000);
                }

                if (bFind)
                {


                    Process p = Process.Start(parObject.FileName, parObject.Url);

                    if (p != null)
                    {
                        HKWin32.ShowWindow(p.MainWindowHandle, 9);

                        HKWin32.SetForegroundWindow(p.MainWindowHandle);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        public void Exit()
        {
            if (_myThread != null && _myThread.IsAlive)
            {
                _myThread.Abort();
            }   

        }

    }
}
