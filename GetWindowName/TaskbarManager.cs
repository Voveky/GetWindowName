using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GetWindowName
{
    public class TaskbarManager
    {
        private const int CONST_SHOW = 5;
        private const int CONST_HIDE = 0;
        private delegate bool EnumThreadProc(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool EnumThreadWindows(int threadId, EnumThreadProc pfnEnum, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        /// <summary>
        /// The actual magic for hiding and showing the taskbar happens here.
        /// </summary>
        /// <param name="visible">Determines if the taskbar and startmenu should be visible.</param>
        private static void ToggleVisibility(bool visible)
        {
            // Find the taskbar window
            var taskbar = FindWindow("Shell_TrayWnd", null);
            // Find the startmenu window
            var startmenu = FindWindowEx(taskbar, IntPtr.Zero, "Button", "Start");
            if (startmenu == IntPtr.Zero)
            {
                // ... sometimes, like Windows 7, just finding 'Button' would suffice
                startmenu = FindWindow("Button", null);
            }
            // Show or hide both containers
            ShowWindow(taskbar, visible ? CONST_SHOW : CONST_HIDE);
            ShowWindow(startmenu, visible ? CONST_SHOW : CONST_HIDE);
        }
    }
}