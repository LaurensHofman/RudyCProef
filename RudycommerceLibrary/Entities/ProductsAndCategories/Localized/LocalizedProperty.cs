using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("localized_property")]
    public class LocalizedProperty
    {
        [Column("property_id")]
        public int PropertyID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("lookup_name")]
        [Required]
        public string LookupName { get; set; }
    }
}
