using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments
{
    [Table("headset")]
    public class Headset : ElectronicEquipment
    {
        //[Column("wearing_way")]
        //public string WearingWay { get; set; }

        //[Column("volume_management")]
        //public string VolumeManagement { get; set; }

        //[Column("integrated_microphone")]
        //public bool IntegratedMicrophone { get; set; }
    }
}
