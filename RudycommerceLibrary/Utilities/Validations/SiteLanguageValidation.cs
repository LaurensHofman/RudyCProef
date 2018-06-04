using RudycommerceLibrary.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Utilities.Validations
{
    public class SiteLanguageValidation
    {
        public static string ValidateLocalName(string text)
        {
            if (StringValidation.IsTextTooLong(text, 255))
            {
                return "NO-ML Local name cannot be longer than 255 characters";
            }
            if (StringValidation.IsTextEmpty(text))
            {
                return "NO-ML Local name cannot be empty";
            }

            return "";
        }

        public static string ValidateDutchName(string text)
        {
            if (StringValidation.IsTextTooLong(text, 255))
            {
                return "NO-ML Dutch name cannot be longer than 255 characters";
            }
            if (StringValidation.IsTextEmpty(text))
            {
                return "NO-ML Dutch name cannot be empty";
            }

            return "";
        }

        public static string ValidateEnglishName(string text)
        {
            if (StringValidation.IsTextTooLong(text, 255))
            {
                return "NO-ML English name cannot be longer than 255 characters";
            }
            if (StringValidation.IsTextEmpty(text))
            {
                return "NO-ML English name cannot be empty";
            }

            return "";
        }

        public static string ValidateISO(string text)
        {
            if ( ! StringValidation.IsTextXLetters(text, 3))
            {
                return "NO-ML ISO-code has to be exactly 3 letters";
            }
            if (StringValidation.IsTextNotUnique(text, BL_Language.GetAllISOCodes()))
            {
                return "NO-ML This ISO code is already taken";
            }

            return "";
        }        

        public static string ValidateDefaultActive(bool checkedIsActive, bool checkedIsDefault)
        {
            if (checkedIsDefault == true)
            {
                if (checkedIsActive == false)
                {
                    return "NO-ML A default language has to be active as well";
                }
            }
            return "";
        }
    }
}
