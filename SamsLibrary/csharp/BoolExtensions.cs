using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.csharp.DataStructures
{

    public static class BoolExtensions
    {
        public static string GetYesNoChar(this bool? value)
        {
            return value.HasValue && value.Value ? "Y" : "N";
        }

        public static string GetYesNoChar(this bool value)
        {
            return value ? "Y" : "N";
        }

        public static string GetYesNo(this bool? value)
        {
            return value.HasValue && value.Value ? "Yes" : "No";
        }

        public static string GetYesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }
    }
}
