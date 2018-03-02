using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products.LocalizedProducts
{
    [Table("localized_gaming_keyboard")]
    public class LocalizedGamingKeyboard : BaseEntity, ILocalizedProduct
    {
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }


    }
}
