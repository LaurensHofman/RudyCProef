using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products
{
    public class GamingEquipment : GeneralProduct
    {
        [Column("weight")]
        public float Weight { get; set; }

        //public string OtherCharacteristics { get; set; }

        //public string Colour { get; set; }
    }
}
