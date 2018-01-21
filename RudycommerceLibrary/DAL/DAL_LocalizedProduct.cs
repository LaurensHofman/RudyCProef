using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_LocalizedProduct
    {
        public static void Create(LocalizedProduct localizedProductModel)
        {
            var ctx = AppDBContext.Instance();

            ctx.LocalizedProducts.Add(localizedProductModel);
            ctx.SaveChanges();
        }

        public static bool LocalizedProductIsNew(LocalizedProduct localizedProductModel)
        {
            var ctx = AppDBContext.Instance();

            return ctx.LocalizedProducts.Where(lp => lp.LanguageID == localizedProductModel.LanguageID &&
                                                       lp.ProductID == localizedProductModel.ProductID).ToList().Count == 0;
                     
        }

        public static List<LocalizedProduct> GetAll()
        {
            var ctx = AppDBContext.Instance();

            return ctx.LocalizedProducts.Where(lp => lp.DeletedAt == null).ToList();
        }
        
    }
}
