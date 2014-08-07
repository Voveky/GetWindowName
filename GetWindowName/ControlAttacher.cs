using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
//using System.Windows.Controls;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GetWindowName
{
    public static class ControlAttacher
    {
        public static WinButt WindowsButton;
        public static void AttachButton(IntPtr hwndPt)
        {
            WindowsButton = new WinButt();
            HandleRef WBHandle = new HandleRef(WindowsButton.Handle, WindowsButton.Handle);
            NativeMethods.SetWindowLong((IntPtr)WBHandle, NativeMethods.GWLParameter.GWL_HWNDPARENT, (int)hwndPt);
            WindowsButton.Show();
        }
    }

    static class NativeMethods
    {
        public static IntPtr SetWindowLongPtr(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8) //Check if this window is 64bit
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }

        //Specifies the zero-based offset to the value to be set.
        //Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer.
        public enum GWLParameter
        {
            GWL_EXSTYLE = -20, //Sets a new extended window style
            GWL_HINSTANCE = -6, //Sets a new application instance handle.
            GWL_HWNDPARENT = -8, //Set window handle as parent
            GWL_ID = -12, //Sets a new identifier of the window.
            GWL_STYLE = -16, // Set new window style
            GWL_USERDATA = -21, //Sets the user data associated with the window. This data is intended for use by the application that created the window. Its value is initially zero.
            GWL_WNDPROC = -4 //Sets a new address for the window procedure.
        }

        public static int SetWindowLong(IntPtr windowHandle, GWLParameter nIndex, int dwNewLong)
        {
            if (IntPtr.Size == 8) //Check if this window is 64bit
                return (int)SetWindowLongPtr64(windowHandle, nIndex, new IntPtr(dwNewLong));
            else
                return SetWindowLong32(windowHandle, nIndex, dwNewLong);
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            internal int left;
            internal int top;
            internal int right;
            internal int bottom;
        }
        ///The SetWindowLongPtr function changes an attribute of the specified window

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        internal static extern int SetWindowLong32(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        internal static extern int SetWindowLong32(IntPtr windowHandle, GWLParameter nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        internal static extern IntPtr SetWindowLongPtr64(IntPtr windowHandle, GWLParameter nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        internal static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        internal static extern IntPtr SetWinEventHook(
            AccessibleEvents eventMin, //Specifies the event constant for the lowest event value in the range of events that are handled by the hook function. This parameter can be set to EVENT_MIN to indicate the lowest possible event value.
            AccessibleEvents eventMax, //Specifies the event constant for the highest event value in the range of events that are handled by the hook function. This parameter can be set to EVENT_MAX to indicate the highest possible event value.
            IntPtr eventHookAssemblyHandle, //Handle to the DLL that contains the hook function at lpfnWinEventProc, if the WINEVENT_INCONTEXT flag is specified in the dwFlags parameter. If the hook function is not located in a DLL, or if the WINEVENT_OUTOFCONTEXT flag is specified, this parameter is NULL.
            WinEventProc eventHookHandle, //Pointer to the event hook function. For more information about this function
            uint processId, //Specifies the ID of the process from which the hook function receives events. Specify zero (0) to receive events from all processes on the current desktop.
            uint threadId,//Specifies the ID of the thread from which the hook function receives events. If this parameter is zero, the hook function is associated with all existing threads on the current desktop.
            SetWinEventHookParameter parameterFlags //Flag values that specify the location of the hook function and of the events to be skipped. The following flags are valid:
            );

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        internal static extern bool UnhookWinEvent(IntPtr eventHookHandle);

        internal delegate void WinEventProc(IntPtr winEventHookHandle, AccessibleEvents accEvent, IntPtr windowHandle, int objectId, int childId, uint eventThreadId, uint eventTimeInMilliseconds);

        [DllImport("user32.dll")]
        internal static extern IntPtr SetFocus(IntPtr hWnd);

        [Flags]
        internal enum SetWinEventHookParameter
        {
            WINEVENT_INCONTEXT = 4,
            WINEVENT_OUTOFCONTEXT = 0,
            WINEVENT_SKIPOWNPROCESS = 2,
            WINEVENT_SKIPOWNTHREAD = 1
        }
    }
}
