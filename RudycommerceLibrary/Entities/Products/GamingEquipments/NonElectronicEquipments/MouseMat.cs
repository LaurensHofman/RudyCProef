using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products.GamingEquipments.NonElectronicEquipments
{
    [Table("mouse_mat")]
    public class MouseMat : NonElectronicEquipment
    {
        [Column("length")]
        public int Length { get; set; }

        [Column("depth")]
        public int Depth { get; set; }

        [Column("width")]
        public int Width { get; set; }
    }
}
