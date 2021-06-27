using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shammill.Library
{
    public static class RegexExamples
    {
        public const string EmailPattern = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
        public const string SimpleEmailPattern = @"^[a-zA-Z\.\-_]+@([a-zA-Z\.\-_]+\.)+[a-zA-Z]{2,4}$";
        public const string WebSitePattern = @"^[a-z-]*api\.mywebsite\.com\.au$";
        public const string FilePartPrefixPattern = @"(^ABC[0-9]{3}_{1})"; // matches on ABC123_
        public const string abc1234567 = @"^(abc|xyz)\d{1,7}$"; // matches on abc or xyz and between 1 and 7 numbers 
        public const string UnitStreetAddress = @"(\w+\s)*(([A-Z0-9]+)/\s?)?([0-9][A-Z0-9-]*)$"; // Unit A 122 or Apartment 12 222 etc
        public const string splitOnBrXmlRegex = @"<\s*br\s*\/?\s*>";
        public const string integerOrNegativeInteger = @"^[-]?[0-9]*$";



        public static string RegexExample(this string str)
        {
            str = Regex.Replace(str, @"([A-Z])([A-Z][a-z])", "$1 $2");  // Capital followed by capital AND a lowercase.
            str = Regex.Replace(str, @"([a-z])([A-Z])", "$1 $2"); // Lowercase followed by a capital.
            str = Regex.Replace(str, @"(\D)(\d)", "$1 $2"); //Letter followed by a number.
            str = Regex.Replace(str, @"(\d)(\D)", "$1 $2"); // Number followed by non-number.

            // letter followed by dash followed by letter
            str = Regex.Replace(str, @"([A-Za-z])-([A-Za-z])", "$1 - $2"); //no spaces
            str = Regex.Replace(str, @"([A-Za-z]) -([A-Za-z])", "$1 - $2"); //space on left
            str = Regex.Replace(str, @"([A-Za-z])- ([A-Za-z])", "$1 - $2"); //space on right

            str = new Regex("{|\\[").Replace(str, ""); //open brackets
            str = new Regex("}|\\]").Replace(str, ""); //close brackets
            str = new Regex(",\\s*$").Replace(str, ""); //commas
            str = new Regex("\"").Replace(str, ""); //quotes
            str = new Regex("^[ ]{2}", RegexOptions.Multiline).Replace(str, ""); //indents
            str = new Regex("[ ]{2}").Replace(str, "    "); //indents
            str = new Regex("^(\\s|,)*$", RegexOptions.Multiline).Replace(str, "\n").Replace("\r", ""); //blank lines
            str = new Regex("\\n+").Replace(str, "\n"); //replace multiple lines

            return str;
        }

        public static bool IsHex(this string value)
        {
            return Regex.Match(value.ToUpper(), @"^[A-F|0-9]+[A-F|0-9]+$").Success;
        }

        public static IEnumerable<Recipient> FromRfc822(this string input)
        {
            const string regex = @"(""(?<name>.+)"")?\s?<(?<email>.+)>";
            var split = input.Split(", ");
            var result = split.Select(item => Regex.Match(item, regex))
                .Select(item => item.Groups["email"].Value)
                .Select(item => new Recipient { Email = item })
                .ToList();
            return result;
        }

        public static bool IsXml(this string data)
        {
            return new Regex(@"^\s*<.*>\s*$").IsMatch(data);
        }

        public class Recipient
        {
            public string Email { get; set; }
        }

        private static string ReplaceNewlinesWithHtml(string body)
        {
            return Regex.Replace(body, @"\r\n?|\n", "<br/>");
        }

        public static string RemoveInvalidCharactersFromFileFolderName(string fileFolderName, string replacementCharacter)
        {
            string pattern = "[\\\\~#%&*{}()/:<>?|\"-]";
            Regex regEx = new Regex(pattern);
            return Regex.Replace(regEx.Replace(fileFolderName, replacementCharacter), @"\s+", " ");
        }

        public static string RemoveInvalidCharactersFromFileName(string fileName, string replacementCharacter)
        {
            string pattern = "[\\\\*/:<>?|\"]";
            Regex regEx = new Regex(pattern);
            return regEx.Replace(fileName, replacementCharacter);
        }


        private static readonly Regex ACNRegex = new Regex("^\\d{9}$", RegexOptions.Compiled);
        private static readonly Regex ABNRegex = new Regex("^\\d{11}$", RegexOptions.Compiled);
        public static bool IsACN(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ACNRegex.IsMatch(value.Replace(" ", ""));
        }
        public static bool IsABN(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ABNRegex.IsMatch(value.Replace(" ", ""));
        }

        /// <summary>
        /// Strip unicode characters from string so it will be ASCII only.
        /// </summary>
        /// <param name="input">A unicode string</param>
        /// <returns></returns>
        public static string UnicodeToAscii(string input)
        {
            return Regex.Replace(input, @"[^\u0000-\u007F]", string.Empty);
        }

        public static string FormatPhoneNumber(string value)
        {
            string numberWithAreaCodePattern = "^([0-9]{2})[ ]([0-9]{4})[ ]([0-9]{4})$";
            string numberWithoutAreaCodePattern = "^([0-9]{4})[ ]([0-9]{4})$";
            string numberWithCountryCodePattern = "^([0-9]{2})[ ]([0-9]{4}) ([0-9]{4})[ ]([0-9]{4})$";
            string mobilePattern = "^([0-9]{4})[ ]([0-9]{3})[ ]([0-9]{3})$";

            string numberWithoutAreaCodeFormat = "^([0-9]{4})([0-9]{4})$";
            string numberWithAreaCodeFormat = "^([0-9]{1,2})([0-9]{4})([0-9]{4})$";
            string numberMobileAnd13And18Format = "^([0-9]{4})([0-9]{3})([0-9]{1,3})$";
            Regex digitsOnly = new Regex(@"[^\d]");

            if (Regex.IsMatch(value, numberWithAreaCodePattern) ||
                  Regex.IsMatch(value, numberWithoutAreaCodePattern) ||
                  Regex.IsMatch(value, numberWithCountryCodePattern) ||
                  Regex.IsMatch(value, mobilePattern))
                return value;
            value = digitsOnly.Replace(value, "");
            if (value.Length == 8)
            {
                var match = Regex.Match(value, numberWithoutAreaCodeFormat);
                if (match.Success && match.Groups.Count == 3)
                {
                    value = $"{match.Groups[1]} {match.Groups[2]}";
                }
            }
            else if (value.StartsWith("04") || value.StartsWith("13") || value.StartsWith("18"))
            {
                if (value.Length > 8)
                {
                    var match = Regex.Match(value, numberMobileAnd13And18Format);
                    if (match.Success && match.Groups.Count >= 3)
                    {
                        value = $"{match.Groups[1]} {match.Groups[2]}";
                        if (match.Groups.Count == 4)
                            value += " " + match.Groups[3];
                    }
                }
            }
            else if (value.Length > 8 && value.Length <= 10)
            {
                var match = Regex.Match(value, numberWithAreaCodeFormat);
                if (match.Success && match.Groups.Count == 4)
                {
                    value = $"{match.Groups[1].Value.PadLeft(2, '0')} {match.Groups[2]} {match.Groups[3]}";
                }
            }
            return value;
        }
    }
}

