﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("localized_category")]
    public class LocalizedCategory
    {
        [Column("category_id")]
        public int CategoryID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public string LanguageName { get; set; }
    }
}
