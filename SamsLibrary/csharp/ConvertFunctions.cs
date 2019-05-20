using System;
using System.Collections;
using System.Collections.Generic;

namespace SamsLibrary
{
    public class ConvertFunctions
    {
        public ConvertFunctions()
        {

        }


        public int StringToInt(string value)
        {
            return Convert.ToInt32(value);
        }
    }

    public class BoolToYesNoString
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                bool bl = (bool)value;

                if (bl)
                    return "Yes";
                else
                    return "No";
            }
            else
            {
                return "";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}

