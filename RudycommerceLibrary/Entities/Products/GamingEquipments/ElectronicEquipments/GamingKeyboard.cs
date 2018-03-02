using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments
{
    [Table("keyboard")]
    public class GamingKeyboard : ElectronicEquipment, IGamingKeyboard
    {
        [Column("function_keys")]
        public int FunctionKeys { get; set; }

        [Column("layout")]
        public string Layout { get; set; }

        [Column("length")]
        public float Length { get; set; }

        [Column("depth")]
        public float Depth { get; set; }

        [Column("width")]
        public float Width { get; set; }

        //public string BacklitKeys { get; set; }
    }
}
