using RudycommerceLibrary.DAL;
using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL
{
    public static class BL_Product
    {
        public static void Save(Product model)
        {
            if (model.IsNew())
            {
                Create(model);
            }
        }

        private static void Create(Product model)
        {
            DAL_Product.Create(model);
        }

    }
}
