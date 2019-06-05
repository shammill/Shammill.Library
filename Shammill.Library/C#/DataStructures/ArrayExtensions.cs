using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shammill.Library.DataStructures
{
    public static class ArrayExtensions
    {
        public static T[] ConvertArray<T>(this string[] values)
        {
            values = values.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
            T[] newValues = Array.ConvertAll<string, T>(values, delegate (string s)
            {
                if (!conv.CanConvertTo(typeof(T)))
                    throw new ArgumentException(String.Format("Cannot convert to {0}.", typeof(T).Name));
                return (T)conv.ConvertFromString(s);
            });
            return newValues;
        }

        public static string[] ConvertToStringArray<T>(this T[] values)
        {
            TypeConverter conv = TypeDescriptor.GetConverter(typeof(string));
            string[] newValues = Array.ConvertAll<T, string>(values, delegate (T s)
            {
                if (!conv.CanConvertTo(typeof(string)))
                    throw new ArgumentException(String.Format("Cannot convert to {0}.", typeof(string).Name));
                return (string)conv.ConvertToString(s);
            });
            return newValues;
        }

        public static T[] AddRangeToArray<T>(this T[] sequence, T[] items)
        {
            return (sequence ?? Enumerable.Empty<T>()).Concat(items).ToArray();
        }

        public static T[] Add<T>(this T[] sequence, T item)
        {
            return (sequence ?? Enumerable.Empty<T>()).Concat(new[] { item }).ToArray();
        }
    }
}
