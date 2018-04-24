using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Rudycommerce.Validations
{
    public class GenericDecimalValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                Decimal testDecimal = Decimal.Parse((string)value);

                if ( testDecimal < 0 )
                {
                    return new ValidationResult(false, "NO-ML Must be a positive number");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "NO-ML Please enter a valid price");
            }
        }
    }
}
