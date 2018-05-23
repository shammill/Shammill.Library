using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SamsLibrary.csharp
{
    public static class StaticEnums
    {

        public enum MyEnum
        {
            [Description("Employee")]
            Employee,
            [Description("Manager")]
            Manager
        }

        // Get description Attribute from an Enum
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            string description = null;

            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memberInfo = type.GetMember(e.ToString());
                        var descriptionAttributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (descriptionAttributes.Length > 0)
                        {
                            description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                        }

                        break;
                    }
                }
            }

            return description;
        }

        // New Untested
        public static string GetDescription(this Enum enumeration)
        {
            Type type = enumeration.GetType();
            MemberInfo[] enumMemberInfo = type.GetMember(enumeration.ToString());

            if (!enumMemberInfo.Any())
            {
                return enumeration.ToString();
            }

            object[] attributes = enumMemberInfo.First().GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Any())
            {
                return ((DescriptionAttribute)attributes.First()).Description;
            }

            return enumeration.ToString();
        }
    }

    public class Enums
    {
        public enum TheEnum
        {
            [Description("Tester")]
            Test,
        }

        public Enums()
        {
            TheEnum enumer = TheEnum.Test;
            var description = StaticEnums.MyEnum.Employee.GetDescription();
            var description2 = enumer.GetDescription();
        }

    }

    // usually you'll get this from using System.ComponentModel; or using System.ComponentModel.Primatives; but that wasn't working.
    internal class DescriptionAttribute : Attribute
    {
        public string Description;

        public DescriptionAttribute(string v)
        {
            this.Description = v;
        }
    }
}
