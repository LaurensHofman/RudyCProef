using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Rudycommerce.Validations
{
    public class GenericIntegerValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                int testInteger = int.Parse((string)value);

                if (testInteger < 0)
                {
                    return new ValidationResult(false, "NO-ML Please enter a positive number");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "NO-ML Please enter a valid whole number");
            }
        }
    }
}
