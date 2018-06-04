using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.View
{
    [Table("dbo.vProductOverview")]
    public class ProductOverViewItem
    {
        [Key]
        [Column("ViewID")]
        public Guid ViewID { get; set; }

        [Column("product_id")]
        public int ProductID { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        //public int MultilingualCount { get; set; }

        [Column("category_id")]
        public int CategoryID { get; set; }

        [Column("category_name")]
        public string CategoryName { get; set; }

        [Column("current_stock")]
        public int CurrentStock { get; set; }

        [Column("unit_price")]
        public decimal UnitPrice { get; set; }

        [Column("language_id")]
        public int LanguageID { get; set; }

    }
}
