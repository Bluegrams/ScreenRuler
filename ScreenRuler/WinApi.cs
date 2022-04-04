using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security;

namespace ScreenRuler
{
    public enum MonitorOptions
    {
        MONITOR_DEFAULTTONULL = 0,
        MONITOR_DEFAULTTOPRIMARY = 1,
        MONITOR_DEFAULTTONEAREST = 2
    }

    public enum MonitorDpiType
    {
        EFFECTIVE_DPI = 0,
        ANGULAR_DPI = 1,
        RAW_DPI = 2,
    }

    /// <summary>
    /// A class that wraps used Win32 API calls.
    /// </summary>
    public static class WinApi
    {
        #region API methods

        [StructLayout(LayoutKind.Sequential)]
        internal struct WinPoint
        {
            public int X;
            public int Y;

            public static explicit operator Point(WinPoint point)
            {
                return new Point(point.X, point.Y);
            }

            public static explicit operator WinPoint(Point point)
            {
                WinPoint pt = new WinPoint();
                pt.X = (int)point.X;
                pt.Y = (int)point.Y;
                return pt;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WinRect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public static explicit operator Rectangle(WinRect winRect)
            {
                int width = winRect.Right - winRect.Left;
                int height = winRect.Bottom - winRect.Top;
                return new Rectangle(winRect.Left, winRect.Top, width, height);
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(WinPoint point);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out WinRect lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string className, string windowTitle);

        [DllImport("dwmapi.dll")]
        private static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out WinRect pvAttribute, int cbAttribute);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll")]
        private static extern IntPtr MonitorFromWindow(IntPtr hwnd, MonitorOptions dwFlags);

        // requires Windows 8.1 or newer
        [SuppressUnmanagedCodeSecurity]
        [DllImport("Shcore.dll")]
        private static extern IntPtr GetDpiForMonitor(IntPtr hmonitor, MonitorDpiType dpiType, out int dpiX, out int dpiY);

        #endregion

        #region Static methods

        /// <summary>
        /// Retrieves the bounding rectangle of the window at the specified point.
        /// </summary>
        public static Rectangle GetWindowRectangle(Point point)
        {
            IntPtr hWnd = WindowFromPoint((WinPoint)point);
            return GetWindowRectangle(hWnd);
        }

        /// <summary>
        /// Retrieves the bounding rectangle of the window with the specified title.
        /// </summary>
        public static Rectangle GetWindowRectangle(string windowTitle)
        {
            IntPtr hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, windowTitle);
            return GetWindowRectangle(hWnd);
        }

        public static Rectangle GetWindowRectangle(IntPtr hWnd)
        {
            if (hWnd == null)
                return Rectangle.Empty;

            int result = DwmGetWindowAttribute(
                            hWnd,
                            /*DWMWA_EXTENDED_FRAME_BOUNDS*/ 9,
                            out WinRect rect,
                            Marshal.SizeOf(typeof(WinRect)));
            if (result < 0)
                GetWindowRect(hWnd, out rect);
            return (Rectangle)rect;
        }
        
        /// <summary>
        /// Gets the dpi of the monitor.
        /// </summary>
        /// <param name="hWnd">The window handle used to determine the monitor of interest.</param>
        /// <param name="dpiType">A value of MonitorDpiType indicating the dpi type to be returned.</param>
        /// <returns>The dpi of the monitor.</returns>
        public static int GetMonitorDpiFromWindow(IntPtr hWnd, MonitorDpiType dpiType)
        {
            IntPtr hmonitor = MonitorFromWindow(hWnd, MonitorOptions.MONITOR_DEFAULTTONEAREST);
            GetDpiForMonitor(hmonitor, dpiType, out int dpiX, out int dpiY);
            return dpiX;
        }

        #endregion
    }
}
