using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories
{   
    [Table("specific_product_properties")]
    public class SpecificProductProperty : BaseEntity
    {
        [Key]
        [Column("specific_product_property_id")]
        public int SpecificProductPropertyID { get; set; }

        public override bool IsNew()
        {
            return this.SpecificProductPropertyID <= 0;
        }

        public virtual ICollection<LocalizedSpecificProductProperty> LocalizedSpecificProductProperties { get; set; }
        public virtual ICollection<Category_SpecificProductProperties> Category_SpecificProductProperties { get; set; }
        public virtual ICollection<Product_SpecificProductProperties> Product_SpecificProductProperties { get; set; }
        public virtual ICollection<Localized_Product_SpecificProductProperties> Localized_Product_SpecificProductProperties { get; set; }
    }
}
