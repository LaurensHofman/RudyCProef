using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("localized_enumeration_values")]
    public class LocalizedEnumerationValues
    {
        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("value")]
        [Required]
        public string Value { get; set; }

        [Column("enumeration_id")]
        public int EnumerationID { get; set; }
    }
}
