using RudycommerceLibrary.Utilities.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Rudycommerce.Validations
{
    public class GenericStringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringToTest = (string)value;

            if (StringValidation.IsTextTooLong(stringToTest, 255))
            {

            }
            return null;
        }
    }
}
