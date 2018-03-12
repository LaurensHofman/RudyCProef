using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("product__product_properties")]
    public class Product_ProductProperties : BaseEntity
    {
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("product_property_id")]
        public int ProductPropertyID { get; set; }
                
        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }
    }
}
