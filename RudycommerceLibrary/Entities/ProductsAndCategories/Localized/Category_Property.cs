using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Entities.ProductsAndCategories.Localized
{
    [Table("category_properties")]
    public class Category_Property 
    {
        [Column("category_id")]
        public int CategoryID { get; set; }

        [Column("property_id")]
        public int PropertyID { get; set; }

        //[Column("is_required")]
        //public bool IsRequired { get; set; }

        [NotMapped]
        public string PropertyName { get; set; }
    }
}
