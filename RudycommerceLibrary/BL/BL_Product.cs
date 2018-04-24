using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.View;

namespace RudycommerceLibrary.BL
{
    public static class BL_Product
    {
        public static void Create(Product productModel, List<LocalizedProduct> localizedProductList, List<Product_SpecificProductProperties> product_ProductPropertiesList, List<Values_Product_SpecificProductProperties> localizedValuesProduct_SpecificProductProperties)
        {
            productModel.CurrentStock = productModel.InitialStock;
            DAL.DAL_Product.Create(productModel, localizedProductList, product_ProductPropertiesList, localizedValuesProduct_SpecificProductProperties);
        }

        public static List<ProductOverViewItem> GetProductOverview(Language userLanguage)
        {
            return DAL.DAL_Product.GetProductOverview(userLanguage);
        }

        public static Product GetProduct(int productID)
        {
            return DAL.DAL_Product.GetProduct(productID);
        }

        public static List<LocalizedProduct> GetLocalizedProductList(int productID)
        {
            return DAL.DAL_Product.GetLocalizedProductList(productID);
        }

        public static List<Product_SpecificProductProperties> GetPropertiesFromProduct(int productID)
        {
            return DAL.DAL_Product.GetPropertiesFromProduct(productID);
        }

        public static List<Values_Product_SpecificProductProperties> GetLocalizedPropertiesFromProduct(int productID)
        {
            return DAL.DAL_Product.GetLocalizedPropertiesFromProduct(productID);
        }
    }
}
