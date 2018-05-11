using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Key]
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("unit_price")]
        public decimal? UnitPrice { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("intial_stock")]
        public int? InitialStock { get; set; }

        [Column("current_stock")]
        public int? CurrentStock { get; set; }
        
        [Column("category_id")]
        public int CategoryID { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public Product()
        {
            this.IsActive = true;
        }

        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }

        public virtual ICollection<Localized.LocalizedProduct> LocalizedProducts { get; set; }
        public virtual ICollection<Localized.Product_ProductProperties> Product_SpecificProductProperties { get; set; }
        public virtual ICollection<Localized.Values_Product_ProductProperties> Values_Product_Properties { get; set; }
    }
}
