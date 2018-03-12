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
    [Table("product_properties")]
    public class ProductProperty : BaseEntity
    {
        [Key]
        [Column("product_property_id")]
        public int ProductPropertyID { get; set; }

        public override bool IsNew()
        {
            return this.ProductPropertyID <= 0;
        }

        public virtual ICollection<LocalizedProductProperty> LocalizedProductProperties { get; set; }
        public virtual ICollection<Category_ProductProperties> Category_ProductProperties { get; set; }
        public virtual ICollection<Localized.Product_ProductProperties> Product_ProductProperties { get; set; }
    }
}
