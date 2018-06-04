using RudycommerceLibrary.Utilities.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Rudycommerce.Validations
{
    public class InitialStockValidation : ValidationRule
    {
        // https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-binding-validation

        public override ValidationResult Validate(object input, CultureInfo cultureInfo)
        {
            string errorMessage = ProductValidations.InitialStockValidation(input);

            if (errorMessage == null)
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, errorMessage);
            }
        }
    }
}
