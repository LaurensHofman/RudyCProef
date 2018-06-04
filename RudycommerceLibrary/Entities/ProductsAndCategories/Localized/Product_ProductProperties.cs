using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("product__product_properties")]
    public class Product_ProductProperties
    {
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("specific_product_property_id")]
        public int PropertyID { get; set; }

        //[Column("non_multilingual_value")]
        //public string NonMultilingualValue { get; set; }

    }
}
