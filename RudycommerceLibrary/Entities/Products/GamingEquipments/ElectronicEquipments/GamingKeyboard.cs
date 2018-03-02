using RudycommerceLibrary.Entities.Products.LocalizedProducts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments
{
    [Table("gaming_keyboard")]
    public class GamingKeyboard : ElectronicEquipment
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

        public virtual ICollection<LocalizedGamingKeyboard> LocalizedGamingKeyboards { get; set; }
    }
}
