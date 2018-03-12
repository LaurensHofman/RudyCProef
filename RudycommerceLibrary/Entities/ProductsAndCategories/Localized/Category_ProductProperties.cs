using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("category__product_properties")]
    public class Category_ProductProperties : BaseEntity
    {
        [Column("category_id")]
        public int CategoryID { get; set; }

        [Column("product_property_id")]
        public int ProductPropertyID { get; set; }
        
        public override bool IsNew()
        {
            return this.ProductPropertyID <= 0;
        }
    }
}
