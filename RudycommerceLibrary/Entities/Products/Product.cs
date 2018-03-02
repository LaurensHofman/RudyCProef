using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products
{
    [Table("product")]
    public class Product: BaseEntity
    {
        [Key]
        [Column("product_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }

        [Column("type_of_product")]
        public string ProductType { get; set; }

        [Column("type_of_equipment")]
        public string EquipmentType { get; set; }

        //public virtual ICollection<LocalizedProduct> LocalizedProducts { get; set; }
    }
}
