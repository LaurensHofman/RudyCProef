using RudycommerceLibrary.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities
{
    [Table("desktop_users")]
    public class DesktopUser : BaseEntity
    {
        [Key]
        [Column("user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Column("is_admin")]
        public bool IsAdmin { get; set; }

        [Column("verified_by_admin")]
        public bool VerifiedByAdmin { get; set; }

        [Column("last_name")]
        [Required]
        public string LastName { get; set; }

        [Column("first_name")]
        [Required]
        public string FirstName { get; set; }

        [Column("email")]
        [Required]
        public string EMail { get; set; }

        [Column("preferred_language_id")]
        public int PreferredLanguageID { get; set; }

        [Column("username")]
        [Required]
        public string Username { get; set; }

        [Column("encrypted_password")]
        [Required]
        public string EncryptedPassword { get; set; }

        [Column("salt")]
        [Required]
        public string Salt { get; set; }

        public Language Language { get; set; }

        public Language PreferredLanguage
        {
            get
            {
                return BL_Language.GetLanguageByID(this.PreferredLanguageID);
            }
        }
        
        public override bool IsNew()
        {
            return UserID <= 0;
        }
    }
}
