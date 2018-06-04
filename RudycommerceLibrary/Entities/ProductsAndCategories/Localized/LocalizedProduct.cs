using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("localized_products")]
    public class LocalizedProduct
    {
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        [Required]
        public string Description { get; set; }
    }
}
