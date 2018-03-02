using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.Products.LocalizedProducts
{
    [Table("localized_headset")]
    public class LocalizedHeadset : BaseEntity, ILocalizedProduct
    {
        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
                        
        public override bool IsNew()
        {
            return this.ProductID <= 0;
        }

        [Column("wearing_way")]
        public string WearingWay { get; set; }
    }
}
