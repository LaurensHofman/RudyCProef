using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("localized_product_category")]
    public class LocalizedProductCategory : BaseEntity
    {
        [Column("category_id")]
        public int CategoryID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public override bool IsNew()
        {
            return this.CategoryID <= 0;
        }
    }
}
