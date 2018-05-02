using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.View
{
    [Table("vHomePageProducts")]
    public class HomePageProductViewItem
    {
        [Key]
        [Column("view_id")]
        public Guid ViewID { get; set; }

        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("unit_price")]
        public Decimal UnitPrice { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("image_url")]
        public string ImageURL { get; set; }
    }
}
