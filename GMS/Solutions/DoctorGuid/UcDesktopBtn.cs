using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DoctorGuid
{
    public partial class UcDesktopBtn : UserControl
    {

        public AppItem AppItem { get; set; }

        private readonly ParameterizedThreadStart _parStart = new ParameterizedThreadStart(ThreadMethod);
        private Thread myThread = null;

        private string IconPath = null;


        public UcDesktopBtn(AppItem item,string ico_path)
        {
            InitializeComponent();

            IconPath = ico_path;

            AppItem = item;
            AppItem.ToLower();

            this.label1.Text = AppItem.Name;

            bool bFlag = false;

            try
            {
                this.button1.Image = Image.FromFile(IconPath + AppItem.Icon);
                bFlag = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            if (!bFlag)
            {
                if (AppItem.AppType.EndsWith("exe"))
                {
                    this.button1.Image = global::DoctorGuid.Properties.Resources.exe;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppItem.AppType.EndsWith("exe"))
                {
                    Process.Start(AppItem.FileName, AppItem.Url);
                }
                else
                {
                    //火狐单独处理
                    if (!AppItem.FileName.Contains("firefox.exe"))
                    {
                        Process.Start(AppItem.FileName, AppItem.Url);
                        return;
                    }

                    if (myThread != null && myThread.IsAlive)
                    {
                        myThread.Abort();
                    }

                    myThread = new Thread(_parStart);

                    AppItem obj = new AppItem();
                    obj.ProcessName = AppItem.ProcessName;
                    obj.FileName = AppItem.FileName;
                    obj.Url = AppItem.Url;

                    myThread.Start(obj);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ThreadMethod(object obj)
        {
            try
            {
                AppItem parObject = (AppItem) obj;

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

        public void Close()
        {
            if (myThread != null && myThread.IsAlive)
            {
                myThread.Abort();
            }
        }

        private void UcDesktopBtn_Paint(object sender, PaintEventArgs e)
        {
            //GraphicsPath FormPath = new GraphicsPath();

            //Rectangle rect = new Rectangle(-1, -1, this.Width+1, this.Height +1);//this.Left-10,this.Top-10,this.Width-10,this.Height-10);                 

            //FormPath = GetRoundedRectPath(rect, 20);

            //this.Region = new Region(FormPath);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {

            int diameter = radius;

            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            GraphicsPath path = new GraphicsPath();

            //   左上角   

            path.AddArc(arcRect, 180, 90);

            //   右上角   

            arcRect.X = rect.Right - diameter;

            path.AddArc(arcRect, 270, 90);

            //   右下角   

            arcRect.Y = rect.Bottom - diameter;

            path.AddArc(arcRect, 0, 90);

            //   左下角   

            arcRect.X = rect.Left;

            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();

            return path;

        }
    }
   
}
