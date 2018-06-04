using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Models
{
    public class ProductDetails
    {
        public Product Product { get; set; }

        public List<PropertyDetails> PropertyDetails { get; set; }
    }
}
