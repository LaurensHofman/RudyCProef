using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;

namespace RudycommerceLibrary.BL
{
    public static class BL_Product
    {
        public static void Create(Product productModel, List<LocalizedProduct> localizedProductList, List<Product_SpecificProductProperties> product_ProductPropertiesList, List<Localized_Product_SpecificProductProperties> localizedValuesProduct_SpecificProductProperties)
        {
            DAL.DAL_Product.Create(productModel, localizedProductList, product_ProductPropertiesList, localizedValuesProduct_SpecificProductProperties);
        }
    }
}
