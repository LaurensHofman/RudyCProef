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
        [Column("property_id")]
        public int PropertyID { get; set; }

        [Column("is_multilingual")]
        public bool IsMultilingual { get; set; }

        [Column("is_bool")]
        public bool IsBool { get; set; }

        [Column("is_enumeration")]
        public bool IsEnumeration { get; set; }
        

        public virtual ICollection<PropertyEnumerations> Enumerations { get; set; }

        public override bool IsNew()
        {
            return this.PropertyID <= 0;
        }

        public ProductProperty()
        {
            IsMultilingual = true;
            Enumerations = new List<PropertyEnumerations>();
        }

        public virtual ICollection<LocalizedProperty> LocalizedSpecificProductProperties { get; set; }
        public virtual ICollection<Category_Property> Category_SpecificProductProperties { get; set; }
        public virtual ICollection<Product_ProductProperties> Product_SpecificProductProperties { get; set; }
        public virtual ICollection<Values_Product_ProductProperties> Localized_Product_SpecificProductProperties { get; set; }
    }
}
