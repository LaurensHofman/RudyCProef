using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products
{
    public class GeneralProduct : BaseEntity, IGeneralProduct
    {
        //[Key]
        //[Column("general_product_id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int GeneralProductID { get; set; }

        [Key]
        [Column("product_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Column("unit_price")]
        public Decimal UnitPrice { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("initial_stock")]
        public int InitialStock { get; set; }

        [Column("current_stock")]
        public int CurrentStock { get; set; }

        [Column("available_stock")]
        public int AvailableStock { get; set; }

        [Column("iron_stock")]
        public int IronStock { get; set; }

        [Column("maximum_stock")]
        public int MaximumStock { get; set; }

        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }

        //[Column("type_of_product")]
        //public string TypeOfProduct { get; set; }

        //[Column("type_of_equipment")]
        //public string TypeOfEquipment { get; set; }

        //public virtual ICollection<LocalizedProduct> LocalizedProducts { get; set; }

    }
}
