using System;
using System.Collections;
using System.Collections.Generic;

namespace SamsLibrary
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
                    var nextNumber = "0";//GetNextNumber();
                    return nextNumber;
                case "MonthText":
                    return DateTime.Now.Date.ToString("MMM");
                case "MonthNumber":
                    return DateTime.Now.Date.ToString("MM");
                case "Name1":
                    {
                        string name = string.Empty;
                        return name;
                    }
                case "Name2":
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

