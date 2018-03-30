using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("specific_product_properties_localized")]
    public class LocalizedSpecificProductProperty : BaseEntity
    {
        [Column("specific_product_property_id")]
        public int SpecificProductPropertyID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("lookup_name")]
        public string LookupName { get; set; }

        public override bool IsNew()
        {
            return this.SpecificProductPropertyID <= 0;
        }
    }
}
