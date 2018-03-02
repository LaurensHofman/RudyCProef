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
        public float Length { get; set; }

        [Column("depth")]
        public float Depth { get; set; }

        [Column("width")]
        public float Width { get; set; }
    }
}
