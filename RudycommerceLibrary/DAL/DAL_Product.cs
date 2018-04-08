using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_Product
    {
        public static void Create(Product productModel, List<LocalizedProduct> localizedProductList, List<Product_SpecificProductProperties> product_ProductPropertiesList, List<Localized_Product_SpecificProductProperties> localizedValuesProduct_SpecificProductProperties)
        {
            var ctx = AppDBContext.Instance();

            ctx.Products.Add(productModel);

            foreach (LocalizedProduct localProduct in localizedProductList)
            {
                localProduct.ProductID = productModel.ProductID;
                ctx.LocalizedProducts.Add(localProduct);
            }

            foreach (Product_SpecificProductProperties p_prop in product_ProductPropertiesList)
            {
                p_prop.ProductID = productModel.ProductID;
                ctx.Product_SpecificProductProperties.Add(p_prop);
            }

            foreach (Localized_Product_SpecificProductProperties loc_p_prop in localizedValuesProduct_SpecificProductProperties)
            {
                loc_p_prop.ProductID = productModel.ProductID;
                ctx.Localized_Product_SpecificProductProperties.Add(loc_p_prop);
            }

            ctx.SaveChanges();
        }
    }
}
