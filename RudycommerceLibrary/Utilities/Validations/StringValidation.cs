using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Utilities.Validations
{
    public static class StringValidation
    {
        public static bool IsTextTooLong(string text, int max)
        {
            return text.Length > max;
        }

        public static bool IsTextEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
    }
}
