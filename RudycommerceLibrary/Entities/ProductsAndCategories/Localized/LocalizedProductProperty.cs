using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("product_properties_localized")]
    public class LocalizedProductProperty : BaseEntity
    {
        [Column("product_property_id")]
        public int ProductPropertyID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("lookup_name")]
        public string LookupName { get; set; }

        public override bool IsNew()
        {
            return this.ProductPropertyID <= 0;
        }
    }
}
