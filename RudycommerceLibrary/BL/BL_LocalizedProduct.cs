using RudycommerceLibrary.DAL;
using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL
{
    public static class BL_LocalizedProduct
    {
        public static void Save(LocalizedProduct localizedProductModel)
        {
            if (LocalizedProductIsNew(localizedProductModel))
            {
                Create(localizedProductModel);
            }
        }

        private static void Create(LocalizedProduct localizedProductModel)
        {
            DAL_LocalizedProduct.Create(localizedProductModel);
        }

        public static bool LocalizedProductIsNew(LocalizedProduct localizedProductModel)
        {
            return DAL_LocalizedProduct.LocalizedProductIsNew(localizedProductModel);
        }

        public static List<LocalizedProduct> GetAll()
        {
            return DAL_LocalizedProduct.GetAll();
        }
    }
}
