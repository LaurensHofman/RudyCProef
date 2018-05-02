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
        public static void Create(Product productModel, List<LocalizedProduct> localizedProductList, 
            //List<Product_SpecificProductProperties> product_ProductPropertiesList, 
            List<Values_Product_SpecificProductProperties> localizedValuesProduct_SpecificProductProperties,
            List<ProductImage> productImages)
        {
            productModel.CurrentStock = productModel.InitialStock;

            List<Language> LanguageList = BL_Language.GetAllLanguages();

            List<Values_Product_SpecificProductProperties> tempList = new List<Values_Product_SpecificProductProperties>();

            foreach (var item in localizedValuesProduct_SpecificProductProperties
                                    .Where(x => x.LanguageID == null))
            {
                foreach (Language lang in LanguageList)
                {
                    tempList.Add(
                        new Values_Product_SpecificProductProperties
                        {
                            LanguageID = lang.LanguageID,
                            SpecificProductPropertyID = item.SpecificProductPropertyID,
                            Value = item.Value,
                            EnumerationValueID = item.EnumerationValueID
                        });
                }                
            }

            localizedValuesProduct_SpecificProductProperties.RemoveAll(x => x.LanguageID == null);

            localizedValuesProduct_SpecificProductProperties.AddRange(tempList);

            DAL.DAL_Product.Create(productModel, localizedProductList, 
                localizedValuesProduct_SpecificProductProperties, productImages);
        }

        public static HomePageProductViewItem[] GetHomePageProducts()
        {
            return DAL.DAL_Product.GetHomePageProducts();
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
