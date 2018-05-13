using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities
{
    [Table("languages")]
    public class Language: BaseEntity
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
        [Required]
        [StringLength(255)]
        public string DutchName { get; set; }

        [Column("english_name")]
        [Required]
        [StringLength(255)]
        public string EnglishName { get; set; }

        [Column("ISO")]
        [Index(IsUnique = true)]
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string ISO { get; set; }

        [Column("is_desktop_language")]
        public bool IsDesktopLanguage { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("is_default")]
        public bool IsDefault { get; set; }

        [Column("flag_icon_url")]
        [Required]
        public string FlagIconURL { get; set; }

        [NotMapped]
        public string LocalFlagIconPath { get; set; }

        public virtual ICollection<DesktopUser> DesktopUsers { get; set; }

        public override bool IsNew()
        {
            return this.LanguageID <= 0;
        }

        public Language()
        {
            IsActive = true;
        }

        public virtual ICollection<LocalizedProduct> LocalizedProducts { get; set; }
        public virtual ICollection<LocalizedCategory> LocalizedProductCategories { get; set; }
        public virtual ICollection<LocalizedProperty> LocalizedSpecificProductProperties { get; set; }
        public virtual ICollection<Values_Product_ProductProperties> Localized_Product_SpecificProductProperties { get; set; }
        public virtual ICollection<LocalizedEnumerationValues> LocalizedEnumerationValues { get; set; }
    }
}

