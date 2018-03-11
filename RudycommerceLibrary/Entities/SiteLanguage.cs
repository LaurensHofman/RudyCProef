using RudycommerceLibrary.Entities.Products;
using RudycommerceLibrary.Entities.Products.LocalizedProducts;
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
    public class SiteLanguage: BaseEntity
    {
        [Key]
        [Column("language_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageID { get; set; }
        
        [Column("local_name")]
        [Required]
        [StringLength(255)]
        public string LocalName { get; set; }

        [Column("dutch_name")]
        public string DutchName { get; set; }

        [Column("english_name")]
        public string EnglishName { get; set; }

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

        #region Localized Entities
        public virtual ICollection<LocalizedHeadset> LocalizedHeadsets { get; set; }
        public virtual ICollection<LocalizedGamingController> LocalizedGamingControllers { get; set; }
        public virtual ICollection<LocalizedGamingKeyboard> LocalizedGamingKeyboards { get; set; }
        #endregion
    }
}

