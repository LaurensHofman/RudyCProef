﻿using System;
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
        public string LastName { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("email")]
        public string EMail { get; set; }

        [Column("pref_language")]
        public string PreferredLanguage { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("encrypted_password")]
        public string EncryptedPassword { get; set; }

        [Column("salt")]
        public string Salt { get; set; }

        public override bool IsNew()
        {
            return UserID <= 0;
        }
    }
}
