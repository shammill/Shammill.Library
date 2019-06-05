using System;
using System.Collections;
using System.Collections.Generic;

namespace Shammill.Library
{
    public static class StaticOther
    {
        // Extension method Adding a function to a String
        public static string SamsToLower(this string value)
        {
            return value.ToLower();
        }
    }


    public class Usage
    {
        // Using above extension method.
        public string ExtensionMethodExample()
        {
            string testString = "SamsTheBest!";
            return testString.SamsToLower();
        }
    }
}

