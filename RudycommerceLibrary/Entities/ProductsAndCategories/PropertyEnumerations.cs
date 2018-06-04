using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories
{
    [Table("property_enumerations")]
    public class PropertyEnumerations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("enumeration_id")]
        public int EnumerationValueID { get; set; }

        [Column("specific_property_id")]
        public int PropertyID { get; set; }

        public ProductProperty Property { get; set; }
        public virtual ICollection<Values_Product_ProductProperties> Product_PropertyValues { get; set; }
        public virtual ICollection<LocalizedEnumerationValues> LocalizedEnumerationValues { get; set; }

        [NotMapped]
        public List<LocalizedEnumerationValues> ValuesList { get; set; }
        [NotMapped]
        public string TemporaryNonMLValue { get; set; }

        public PropertyEnumerations()
        {
            Product_PropertyValues = new List<Values_Product_ProductProperties>();
            LocalizedEnumerationValues = new List<LocalizedEnumerationValues>();
            ValuesList = new List<LocalizedEnumerationValues>();
        }
    }
}
