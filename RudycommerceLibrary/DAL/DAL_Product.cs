using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.View;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_Product
    {
        public static void Create(Product productModel)
        {
            var ctx = AppDBContext.Instance();

            using (var ctxTransaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    // Just learned about lazy loading in entity framework

                    ctx.Products.Add(productModel);

                    ctx.SaveChanges();

                    foreach (ProductImage img in productModel.Images)
                    {
                        img.ProductID = productModel.ProductID;
                        img.ImageURL = DAL_ProductImages.uploadImage(img);
                    }

                    ctx.SaveChanges();

                    ctxTransaction.Commit();
                }
                catch (Exception)
                {
                    ctxTransaction.Rollback();
                }
            }            
        }

        public static HomePageProductViewItem[] GetHomePageProducts()
        {
            var ctx = AppDBContext.Instance();

            return ctx.vHomePageProductView.ToArray();
        }

        public static List<Product_ProductProperties> GetPropertiesFromProduct(int productID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Product_SpecificProductProperties.Where(pspp => pspp.ProductID == productID).ToList();
        }

        public static List<Values_Product_ProductProperties> GetLocalizedPropertiesFromProduct(int productID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Localized_Product_SpecificProductProperties.Where(lppp => lppp.ProductID == productID).ToList() ;
        }

        public static List<LocalizedProduct> GetLocalizedProductList(int productID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.LocalizedProducts.Where(lp => lp.ProductID == productID).ToList();
        }

        public static Product GetProduct(int productID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Products.Single(p => p.ProductID == productID && p.DeletedAt == null);
        }

        public static List<ProductOverViewItem> GetProductOverview(Language userLanguage)
        {
            var ctx = AppDBContext.Instance();

            return ctx.vProductOverview.Where(p => p.LanguageID == userLanguage.LanguageID).ToList();
        }
    }
}
