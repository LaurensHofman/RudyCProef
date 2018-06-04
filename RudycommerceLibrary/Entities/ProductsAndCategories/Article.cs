using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories
{   
    [Table("articles")]
    public class Article : BaseEntity
    {
        [Key]
        [Column("article_id")]
        public int ArticleID { get; set; }

        [Column("serial_number")]
        public int SerialNumber { get; set; }

        [Column("product_id")]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        public override bool IsNew()
        {
            return this.ArticleID <= 0;
        }
    }
}
