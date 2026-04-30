using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Microsoft.Win32;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        // Import the Windows api function to set the window attribute for dark mode
        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        // The ID for the Dark Mode attribute (works for Windows 11 and Windows 10 starting with Build 18985)
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public MainWindow()
        {
            InitializeComponent();

            // We have to wait until the window handle (HWND) has been generated
            this.SourceInitialized += MainWindow_SourceInitialized;
        }

        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            ApplyThemeToTitleBar();
        }

        private void ApplyThemeToTitleBar()
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;

            // 1 = Dark Mode on, 0 = Dark Mode off (Light Mode)
            int useDarkMode = IsWindowsInDarkMode() ? 1 : 0;

            DwmSetWindowAttribute(hwnd, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDarkMode, sizeof(int));
        }

        // Check the registry to see if Windows is currently in Dark Mode or Light Mode
        private bool IsWindowsInDarkMode()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    if (key != null && key.GetValue("AppsUseLightTheme") is int lightTheme)
                    {
                        return lightTheme == 0; // 0 means Dark Mode, 1 means Light Mode
                    }
                }
            }
            catch
            {
                // Error handling if registry access fails
            }

            return false; // Fallback to Light Mode
        }
    }
}