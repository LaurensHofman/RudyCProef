using RudycommerceLibrary.DAL;
using RudycommerceLibrary.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL
{
    public static class BL_LocalizedProduct
    {
        public static void Save(LocalizedProduct localProduct, int productID)
        {
            if (localProduct.IsNew())
            {
                localProduct.ProductID = productID;
                Create(localProduct);
            }
        }

        private static void Create(LocalizedProduct localProduct)
        {
            DAL_LocalizedProduct.Create(localProduct);
        }

    }
}
