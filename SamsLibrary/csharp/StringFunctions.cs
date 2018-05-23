using System;
using System.Collections;
using System.Collections.Generic;

namespace SamsLibrary
{
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

