using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("product__specific_product_properties")]
    public class Product_SpecificProductProperties : BaseEntity
    {
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("specific_product_property_id")]
        public int SpecificProductPropertyID { get; set; }
                
        [Column("non_multilingual_value")]
        public string NonMultilingualValue { get; set; }

        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }
        
    }
}
