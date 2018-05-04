using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.View
{
    [Table("dbo.vNecessaryProductProperties")]
    public class NecessaryProductPropertyViewItem
    {
        [Key]
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("lookup_name")]
        public string LookupName { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("is_bool")]
        public bool IsBool { get; set; }
        
        [Column("is_multilingual")]
        public bool IsMultilingual { get; set; }

        [Column("is_enumeration")]
        public bool IsEnumeration { get; set; }

        //[Column("is_required")]
        //public bool IsRequired { get; set; }

        [Column("category_id")]
        public int CategoryID { get; set; }

        [Column("specific_product_property_id")]
        public int PropertyID { get; set; }

        //[Column("parent_id")]
        //public int? CategoryParentID { get; set; }
    }
}
