using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products
{
    public class GamingEquipment : BaseEntity
    {
        [Key]
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("weight")]
        public float Weight { get; set; }

        //public string OtherCharacteristics { get; set; }

        //public string Colour { get; set; }

        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }
    }
}
