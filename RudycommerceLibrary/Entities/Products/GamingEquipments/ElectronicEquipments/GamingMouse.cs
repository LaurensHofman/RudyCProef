using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments
{
    [Table("mouse")]
    public class GamingMouse : ElectronicEquipment
    {
        [Column("max_resolution")]
        public int MaxResolution { get; set; }

        //public string SignalTransfer { get; set; }

        [Column("height")]
        public float Height { get; set; }

        [Column("length")]
        public float Length { get; set; }

        [Column("width")]
        public float Width { get; set; }

        [Column("programmable_buttons")]
        public int ProgrammableButtons { get; set; }
    }
}
