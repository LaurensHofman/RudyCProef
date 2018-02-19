using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments
{
    [Table("keyboard")]
    public class Keyboard : ElectronicEquipment
    {
        [Column("function_keys")]
        public int FunctionKeys { get; set; }

        [Column("layout")]
        public string Layout { get; set; }

        [Column("length")]
        public int Length { get; set; }

        [Column("depth")]
        public int Depth { get; set; }

        [Column("width")]
        public int Width { get; set; }

        //public string BacklitKeys { get; set; }
    }
}
