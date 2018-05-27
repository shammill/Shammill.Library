using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SamsLibrary
{
    public class ScreenFunctions : Form
    {
        public ScreenFunctions()
        {
            IDictionary screenNames = new Dictionary<int, string>();
            Screen[] screens = Screen.AllScreens;

            int index = 0;
            foreach (var screen in screens)
            {
                screenNames.Add(index, screen.DeviceName);
                index++;
            }


            var mainscreen = Screen.PrimaryScreen;

        }
    }
}