using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shammill.Library
{
    public class ScreenFunctions : Form
    {
        public ScreenFunctions()
        {
            var size1 = SystemInformation.PrimaryMonitorSize;
            var size2 = SystemInformation.PrimaryMonitorMaximizedWindowSize;
        }

        /// <summary> 
        /// WorkingArea = resolution minus taskbar, etc. 
        /// </summary>
        public Rectangle GetWorkingArea()
        {
            return Screen.PrimaryScreen.WorkingArea;
        }


        public Size GetScreenResolutionHeightWidth()
        {
            return Screen.PrimaryScreen.Bounds.Size;
            //return new Size { Height = Screen.PrimaryScreen.Bounds.Height, Width = Screen.PrimaryScreen.Bounds.Width };
        }

        public Rectangle GetScreenResolutionRectangle()
        {
            return Screen.PrimaryScreen.Bounds;
        }

        public int GetScreenResolutionWidth()
        {
            return Screen.PrimaryScreen.Bounds.Width;
        }

        public int GetScreenResolutionHeight()
        {
            return Screen.PrimaryScreen.Bounds.Height;
        }

        public Dictionary<int, string> GetScreensIntName()
        {
            Dictionary<int, string> screenNames = new Dictionary<int, string>();
            Screen[] screens = Screen.AllScreens;

            int index = 0;
            foreach (var screen in screens)
            {
                screenNames.Add(index, screen.DeviceName);
                index++;
            }

            return screenNames;
        }




    }
}

/// <summary>
/// Gets supported screen resolutions and other data.
/// </summary>
namespace Shammill.Library.ListResolutions
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);
        const int ENUM_CURRENT_SETTINGS = -1;
        const int ENUM_REGISTRY_SETTINGS = -2;

        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        static void Main(string[] args)
        {
            DEVMODE vDevMode = new DEVMODE();
            int i = 0;
            while (EnumDisplaySettings(null, i, ref vDevMode))
            {
                if (vDevMode.dmPelsWidth > 1080 && (1 << vDevMode.dmBitsPerPel) > 256)
                Console.WriteLine("Width:{0} Height:{1} Color:{2} Frequency:{3}",
                                        vDevMode.dmPelsWidth,
                                        vDevMode.dmPelsHeight,
                                        1 << vDevMode.dmBitsPerPel,
                                        vDevMode.dmDisplayFrequency);
                i++;
            }
        }

    }

}