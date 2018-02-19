using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities
{
    [Table("language")]
    public class Language: BaseEntity
    {
        [Key]
        [Column("language_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageID { get; set; }

        [Column("language_name")]
        public string LanguageName { get; set; }

        [Column("ISO")]
        public string ISO { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("is_default")]
        public bool IsDefault { get; set; }

        public override bool IsNew()
        {
            return this.LanguageID <= 0;
        }

        //public virtual ICollection<LocalizedProduct> LocalizedProducts { get; set; }
    }
}

