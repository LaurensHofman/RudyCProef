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
        public static void Create(Product productModel, List<LocalizedProduct> localizedProductList, /*List<Product_SpecificProductProperties> product_ProductPropertiesList,*/ 
            List<Values_Product_SpecificProductProperties> localizedValuesProduct_SpecificProductProperties,
            List<ProductImage> productImages)
        {
            var ctx = AppDBContext.Instance();

            ctx.Products.Add(productModel);

            ctx.SaveChanges();

            foreach (LocalizedProduct localProduct in localizedProductList)
            {
                localProduct.ProductID = productModel.ProductID;
                ctx.LocalizedProducts.Add(localProduct);
            }

            ctx.SaveChanges();

            //foreach (Product_SpecificProductProperties p_prop in product_ProductPropertiesList)
            //{
            //    p_prop.ProductID = productModel.ProductID;
            //    ctx.Product_SpecificProductProperties.Add(p_prop);
            //}

            foreach (Values_Product_SpecificProductProperties loc_p_prop in localizedValuesProduct_SpecificProductProperties)
            {
                loc_p_prop.ProductID = productModel.ProductID;
                ctx.Localized_Product_SpecificProductProperties.Add(loc_p_prop);
            }

            foreach (ProductImage img in productImages)
            {
                img.ProductID = productModel.ProductID;
                img.ImageURL = DAL_ProductImages.uploadImage(img);
                ctx.ProductImages.Add(img);
            }

            ctx.SaveChanges();
        }

        public static List<Product_SpecificProductProperties> GetPropertiesFromProduct(int productID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Product_SpecificProductProperties.Where(pspp => pspp.ProductID == productID).ToList();
        }

        public static List<Values_Product_SpecificProductProperties> GetLocalizedPropertiesFromProduct(int productID)
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
