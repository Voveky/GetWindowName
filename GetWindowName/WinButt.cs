using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetWindowName
{
    public partial class WinButt : UserControl
    {
        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        Shell32.ShellClass shell = new Shell32.ShellClass();
        
        System.Timers.Timer riser;
        public WinButt()
        {
            InitializeComponent();
            //Location = new Point(912, 52);
            Location = new Point(760, 2);
//            Click += new EventHandler(WinButt_Click);
            MouseEnter +=new EventHandler(WinButt_MouseEnter);
            
            riser = new System.Timers.Timer();
            riser.Interval = 200;
            riser.Elapsed += new System.Timers.ElapsedEventHandler(riser_Elapsed);
            //riser.Tick += new EventHandler(riser_Tick);
            riser.AutoReset = true;
            riser.Start();
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd); 

        void WinButt_MouseEnter(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(100);
            //Shell32.ShellClass objShel = new Shell32.ShellClass();
            //((Shell32.IShellDispatch4)objShel).ToggleDesktop();
            //System.Diagnostics.Process.Start("C:\\Documents and Settings\\aslagle\\Application Data\\Microsoft\\Internet Explorer\\Quick Launch\\Show Desktop.scf");

            //MessageBox.Show(FindWindow(null, "FolderView").ToString());
//            BringWindowToTop(FindWindow(null,"FolderView"));
//SetForegroundWindow
//            MessageBox.Show("About to run minall.exe");
//            Location = new Point((Location.X - 755) % 10 + 755, 2);
//            SendKeys.Send("{#D}");
            //ShowStartMenu();

            //IntPtr desktopWindow = FindWindow("Progman", "Program Manager");
            ////IntPtr desktopWindow = GetDesktopWindow();
            //SetForegroundWindow(desktopWindow);
            //BringWindowToTop(desktopWindow);

            //shell.MinimizeAll();

            //BringWindowToTop(taskbarState.TaskbarWindow);
            //SetForegroundWindow(taskbarState.TaskbarWindow);
            
            //System.Threading.Thread.Sleep(500);
            //MouseOperations.LeftClick(144,67);

            //System.Threading.Thread.Sleep(500);
            //ShowStartMenu();

            //System.Threading.Thread.Sleep(500);
            //MouseOperations.LeftClick(94, 748);

            ////System.Threading.Thread.Sleep(500);
            ////MouseOperations.SetCursorPosition(94, 768);
            
            //System.Diagnostics.Process.Start("Show Desktop.scf");

            taskbarState.SetTaskbarState(taskbarState.AppBarStates.AutoHideOnTop);
            System.Diagnostics.Process.Start("minall.exe");
        }

        private static void ShowStartMenu()
        {
            const uint KEYEVENTF_KEYUP = 0x02;
            const byte keyControl = 0x11;
            const byte keyEscape = 0x1B;
            //const byte keyStart = 0x5B;
            //const byte keyM = 0x4D;

//            // key down event:
//            keybd_event(keyStart, 0, 0, UIntPtr.Zero);
//            keybd_event(keyM, 0, 0, UIntPtr.Zero);
////            keybd_event(0x20, 0, 0, UIntPtr.Zero);

//            // key up event:
////            keybd_event(0x20, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
//            keybd_event(keyM, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
//            keybd_event(keyStart, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);

            // key down event:
            keybd_event(keyControl, 0, 0, UIntPtr.Zero);
            keybd_event(keyEscape, 0, 0, UIntPtr.Zero);

            // key up event:
            keybd_event(keyEscape, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            keybd_event(keyControl, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        void riser_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    this.Location = this.Location;
                });
        }

        void riser_Tick(object sender, EventArgs e)
        {
            this.Size = this.Size;
        }
    }
}
