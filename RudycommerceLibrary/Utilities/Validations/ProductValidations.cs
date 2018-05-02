using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Utilities.Validations
{
    public static class ProductValidations
    {
        public static string InitialStockValidation(object input)
        {
            try
            {
                int initialStock = int.Parse((string)input);

                if (initialStock < 0)
                {
                    return "NO-ML Please enter a positive number";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return "NO-ML Please enter a valid number";
            }            
        }


        public static string UnitPriceValidation(object input)
        {
            try
            {
                Decimal unitPrice = Decimal.Parse((string)input);

                if (unitPrice <= 0)
                {
                    return "NO-ML Please enter a price over 0";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return "NO-ML Please enter a valid price";
            }
        }
    }
}
