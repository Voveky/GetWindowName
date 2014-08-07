using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GetWindowName
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(HandleRef hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32")]
        private static extern UInt32 GetWindowThreadProcessId(IntPtr hWnd, out IntPtr lpdwProcessId);

        IntPtr hwndPt;

        public static Rectangle GetWindowBounds(IntPtr hWnd)
        {
            RECT rct = new RECT();
            GetWindowRect(hWnd, ref rct);
            return new Rectangle(rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        Timer askName = new Timer();

        public Form1()
        {
            InitializeComponent();
            askName.Interval = 200;
            askName.Tick += new EventHandler(askName_Tick);
            askName.Start();
            KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            Shown += new EventHandler(Form1_Shown);
        }

        void Form1_Shown(object sender, EventArgs e)
        {
//////////////////////////////////////////////////////////////////////////////////////////
//////// RE-ENABLE THIS TO TURN ON THE WINDOWS BUTTON ATTACHER!!! ////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////
//            ControlAttacher.AttachButton(WindowFromPoint(1,1));
//            Visible = false;
//            ShowInTaskbar = false;
//            askName.Enabled = false;
        }

        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
//////////////////////////////////////////////////////////////////////////////////////////
//////// RE-ENABLE THIS TO TURN ON THE WINDOWS BUTTON ATTACHER!!! ////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////
//            if (e.KeyChar == '\r')
//                ControlAttacher.AttachButton(hwndPt);
            if (e.KeyChar == '\r')
                askNameStartTrack = true;
        }

        public static IntPtr GetWindowProcessID(IntPtr hwnd)
        {
            IntPtr pid;
            GetWindowThreadProcessId(hwnd, out pid);
            return pid;
        }

        public string GetWindowName(IntPtr hwndPt)
        {
            int capacity = GetWindowTextLength(new HandleRef(this, hwndPt)) * 2;
            StringBuilder stringBuilder = new StringBuilder(capacity);
            GetWindowText(new HandleRef(this, hwndPt), stringBuilder, stringBuilder.Capacity);
            return stringBuilder.ToString();    
        }

        bool askNameStartTrack = false;
        IntPtr trackingPointer;
        void askName_Tick(object sender, EventArgs e)
        {
            if((hwndPt = WindowFromPoint(Control.MousePosition.X, Control.MousePosition.Y)) != null)
            {
                lblWindowName.Text = "Window name = " + GetWindowName(hwndPt);
                lblWindowBounds.Text = "Bounds = " + GetWindowBounds(hwndPt).ToString();
                lblMousePos.Text = "Mouse pos = " + Control.MousePosition.ToString();
                Process p = Process.GetProcessById((int)GetWindowProcessID(hwndPt));
                lblProcessName.Text = "Process name = " + p.ProcessName;
                if (hwndPt == p.MainWindowHandle)
                    lblMainWindow.Text = "IS MAIN WINDOW";
                else
                {
                    lblMainWindow.Text = "Main window name = " + GetWindowName(p.MainWindowHandle);
                }

                if (askNameStartTrack)
                {
                    trackingPointer = hwndPt;
                    askNameStartTrack = false;
                    btnRaise.Enabled = true;
                }
                if (hwndPt != null)
                {
                    lblWindowNameTracking.Text = "Window name = " + GetWindowName(trackingPointer);
                    lblWindowBoundsTracking.Text = "Bounds = " + GetWindowBounds(trackingPointer).ToString();
                    p = Process.GetProcessById((int)GetWindowProcessID(trackingPointer));
                    lblProcessNameTracking.Text = "Process name = " + p.ProcessName;
                    if (trackingPointer == p.MainWindowHandle)
                        lblMainWindowTracking.Text = "IS MAIN WINDOW";
                    else
                    {
                        lblMainWindowTracking.Text = "Main window name = " + GetWindowName(p.MainWindowHandle);
                    }
                }


                StringBuilder visibleWindows = new StringBuilder();
                visibleWindows.AppendLine("Visible Windows:");
                foreach (IntPtr visibleHwndPt in VisibilityTester.enumedwindowPtrs)
                {
                    visibleWindows.AppendLine(
                        "\"" +
                        GetWindowName(visibleHwndPt) +
                        "\" of \"" +
                        GetWindowName(Process.GetProcessById((int)GetWindowProcessID(visibleHwndPt)).MainWindowHandle).ToString() +
                        "\"");
                }
                //DWORD  dwPID;
                //HANDLE hProcess;

                //GetWindowThreadProcessId(hwndPt, &dwPID);

                //hProcess = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION, FALSE, dwPID);

                //if(hProcess == NULL) {
                //    wprintf(L"OpenProcess failed with error: %d\n", GetLastError());
                //} else {
                //    wchar_t lpFileName[MAX_PATH];
                //    DWORD   dwSize = _countof(lpFileName);

                //    QueryFullProcessImageName(hProcess, 0, lpFileName, &dwSize);
                //    wprintf(L"%s\n", lpFileName);

                //    CloseHandle(hProcess);
                //}
            }
        }


        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int CONST_SHOW = 5;
        private void btnRaise_Click(object sender, EventArgs e)
        {
            if (trackingPointer != null)
            {
                ShowWindow(trackingPointer, CONST_SHOW);
                SetForegroundWindow(trackingPointer);
            }
        }
    }
}
