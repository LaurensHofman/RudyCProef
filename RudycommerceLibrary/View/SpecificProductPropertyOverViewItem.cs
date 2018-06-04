using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.View
{
    [Table("dbo.vSpecificProductPropertyOverview")]
    public class SpecificProductPropertyOverViewItem
    {
        [Key]
        [Column("ViewID")]
        public Guid ViewID { get; set; }

        [Column("specific_product_property_id")]
        public int PropertyID { get; set; }

        [Column("is_multilingual")]
        public bool IsMultilingual { get; set; }

        [Column("is_bool")]
        public bool IsBool { get; set; }

        [Column("lookup_name")]
        public string LookupName { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }
    }
}
