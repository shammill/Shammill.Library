using System;
using System.Collections;

namespace Shammill.Library
{
    public static class StaticDateFunctions
    {
        public static double UnixTimestamp(this DateTime dt) => dt.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
    }

    public class DateFunctions
    {
        public DateFunctions()
        {

        }
    }
}