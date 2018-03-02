using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities.Products;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_LocalizedProduct
    {
        public static void Create(LocalizedProduct localProduct)
        {
            var ctx = AppDBContext.Instance();

            ctx.LocalizedProducts.Add(localProduct);
            ctx.SaveChanges();
        }
    }
}
