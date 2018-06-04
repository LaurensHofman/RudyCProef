using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories
{
    [Table("product_images")]
    public class ProductImage
    {
        [Key]
        [Column("image_id")]
        public int ImageID { get; set; }

        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("order")]
        [Required]
        public int Order { get; set; }

        [Column("image_url")]
        [Required]
        public string ImageURL { get; set; }
        
        public Product Product { get; set; }

        [NotMapped]
        public string FileLocation { get; set; }
    }
}
