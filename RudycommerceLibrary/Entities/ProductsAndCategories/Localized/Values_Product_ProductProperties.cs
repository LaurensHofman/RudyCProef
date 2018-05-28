using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("values__product__product_properties")]
    public class Values_Product_ProductProperties
    {
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("specific_product_property_id")]
        public int ProductPropertyID { get; set; }

        [Column("language_id")]
        public int? LanguageID { get; set; }
        
        [Column("input_value")]
        public string Value { get; set; }

        [Column("enumeration_value_id")]
        public int? EnumerationValueID { get; set; }

        public virtual PropertyEnumerations EnumerationValue { get; set; }

        [NotMapped]
        public string DisplayValue { get; set; }
    }
}
