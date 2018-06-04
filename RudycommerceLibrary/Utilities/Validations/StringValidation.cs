using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Utilities.Validations
{
    public static class StringValidation
    {
        public static bool IsTextTooLong(string text, int max)
        {
            return text.Length > max;
        }

        public static bool IsTextEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public static bool IsTextXLetters(string text, int v)
        {
            if ( Regex.IsMatch(text, @"^[a-zA-Z]+$") && text.Length == v)
            {
                return true;
            }
            return false;
        }

        public static bool IsTextNotUnique(string text, string[] stringArray)
        {
            if (stringArray.Any(sa => sa.Equals(text)))
            {
                return true;
            }
            return false;
        }
    }
}
