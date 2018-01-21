using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Key]
        [Column("product_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Column("unit_price")]
        public Decimal UnitPrice { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("initial_stock")]
        public int InitialStock { get; set; }
        
        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }

        public virtual ICollection<LocalizedProduct> LocalizedProducts { get; set; }
    }
}
