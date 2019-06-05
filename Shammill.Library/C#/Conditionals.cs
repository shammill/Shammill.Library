using System;
using System.Collections;
using System.Collections.Generic;

namespace Shammill.Library
{
    public class Conditionals
    {
        public string SwitchStatement(string templateField)
        {
            switch (templateField)
            {
                case "None":
                    return string.Empty;
                case "StartingNumber":
                    var nextNumber = "0";
                    return nextNumber;
                case "MonthText":
                    return DateTime.Now.Date.ToString("MMM");
                case "Name":
                    {
                        string name = string.Empty;
                        return name;
                    }
                case "Year(TwoDigits)":
                    return DateTime.Now.ToString("yy");
                case "Year(FourDigits)":
                    return DateTime.Now.ToString("yyyy");
                case "Other":
                    if (templateField != null)
                    {
                        return "blurp";
                    }
                    break;
                default:
                    return "";
            }
            return "";
        }
    }
}

