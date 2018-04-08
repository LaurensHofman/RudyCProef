using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("localized__product__specific_product_properties")]
    public class Localized_Product_SpecificProductProperties : BaseEntity
    {
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("specific_product_property_id")]
        public int SpecificProductPropertyID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("property_value")]
        public string PropertyValue { get; set; }

        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }
    }
}
