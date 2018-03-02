using RudycommerceLibrary.Entities.Products.LocalizedProducts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments
{
    [Table("gaming_controller")]
    public class GamingController : ElectronicEquipment
    {
        //public string PostionDPad { get; set; }

        public virtual ICollection<LocalizedGamingController> LocalizedGamingControllers { get; set; }
    }
}
