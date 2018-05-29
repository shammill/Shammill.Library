using System;
using System.Collections;
using System.Collections.Generic;

namespace SamsLibrary
{
    public static class StaticStringFunctions
    {
        // This already exists as String.IsNullOrEmpty(val), but val.IsNullOrEmpty() flows a lot better.
        public static bool IsNullOrEmpty(this string value)
        {
            return (value == null || value != string.Empty);
        }

        public static string Escape(this string str)
        {
            var result = System.Text.RegularExpressions.Regex.Escape(str);
            result = result.Replace("'", "\\'");
            result = result.Replace("\"", @"\\x22");
            return result;
        }

        public static string Reverse(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }


    public class StringFunctions
    {
        public StringFunctions()
        {

        }

        // Support for leading 0s on Numbers ie: 0001
        private string GetLeadingZeros(string stringNumber = "0005")
        {

            string leadingZeros = "";
            if (stringNumber.StartsWith("0"))
            {
                foreach (char c in stringNumber)
                {
                    leadingZeros += "0";
                }
            }
            return leadingZeros;

        }

        private string IncrementNumberWithLeadingZeros(string stringNumber = "0005")
        {
            int number = Convert.ToInt32(stringNumber);
            number++;
            return number.ToString(GetLeadingZeros(stringNumber));
        }
    }
}

