using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Utilities.Validations
{
    public class SiteLanguageValidation
    {
        public static string ValidateLocalName(string text)
        {
            if (StringValidation.IsTextTooLong(text, 255))
            {
                return "NO-ML Local name cannot be longer than 255 characters";
            }
            if (StringValidation.IsTextEmpty(text))
            {
                return "NO-ML Local name cannot be empty";
            }

            return null;
        }
    }
}
