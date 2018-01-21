using RudycommerceLibrary.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities
{
    [Table("localized_product")]
    public class LocalizedProduct : BaseEntity
    {
        [Key]
        [Column("product_id", Order = 0)]
        public int ProductID { get; set; }
        
        [Key]
        [Column("language_id", Order = 1)]
        public int LanguageID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Language Language { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public decimal ProductPrice
        {
            get
            {
                return DAL_Product.GetProductPrice(ProductID);
            }
        }

        public string LanguageName
        {
            get
            {
                return DAL_Language.GetLanguageName(LanguageID);
            }
        }

        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }
    }
}
