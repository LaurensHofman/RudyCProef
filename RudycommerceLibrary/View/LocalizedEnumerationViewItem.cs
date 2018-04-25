using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.View
{
    [Table("dbo.vLocalizedEnumerationViewItem")]
    public class LocalizedEnumerationViewItem
    {
        [Key]
        [Column("ViewID")]
        public Guid ViewID { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("enumeration_id")]
        public int EnumerationID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("prop_id")]
        public int PropertyID { get; set; }
    }
}
