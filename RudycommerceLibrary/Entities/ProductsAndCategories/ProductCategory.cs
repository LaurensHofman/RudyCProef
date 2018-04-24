using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories
{
    [Table("product_category")]
    public class ProductCategory : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("category_id")]
        public int CategoryID { get; set; }

        //[Column("parent_id")]
        //public int? ParentID { get; set; }


        //Zie: Children Vertonen NOTES
        //Uitleg staat ook in boek bij Arrays (denkik)


        //[ForeignKey("ParentID")]
        //public virtual ProductCategory Parent { get; set; }
        //public virtual ICollection<ProductCategory> Children { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public ProductCategory()
        {
            //Children = new List<ProductCategory>();
            Products = new List<Product>();
        }

        public override bool IsNew()
        {
            return this.CategoryID == 0;
        }

        public virtual ICollection<LocalizedProductCategory> LocalizedProductCategories { get; set; }
        public virtual ICollection<Category_SpecificProductProperties> Category_SpecificProductProperties { get; set; }
    }
}
