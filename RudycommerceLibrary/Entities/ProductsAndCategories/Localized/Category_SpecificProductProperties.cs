using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("category__specific_product_properties")]
    public class Category_SpecificProductProperties : BaseEntity
    {
        [Column("category_id")]
        public int CategoryID { get; set; }

        [Column("specific_product_property_id")]
        public int SpecificProductPropertyID { get; set; }

        [Column("is_required")]
        public bool IsRequired { get; set; }

        public override bool IsNew()
        {
            return this.SpecificProductPropertyID <= 0;
        }
    }
}
