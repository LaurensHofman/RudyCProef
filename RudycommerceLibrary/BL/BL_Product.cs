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
        public static void Create(Product productModel)
        {
            // For each value where the language wasn't defined, saves the value for each language

            productModel.CurrentStock = productModel.InitialStock;

            List<Language> LanguageList = BL_Language.GetAllLanguages();

            List<Values_Product_ProductProperties> tempList = new List<Values_Product_ProductProperties>();

            foreach (var item in productModel.Values_Product_Properties
                                    .Where(x => x.LanguageID == null))
            {
                bool firstLanguage = true;
                foreach (Language lang in LanguageList)
                {
                    if (firstLanguage == true)
                    {
                        item.LanguageID = lang.LanguageID;
                    }
                    else
                    {
                        tempList.Add(
                        new Values_Product_ProductProperties
                        {
                            LanguageID = lang.LanguageID,
                            ProductPropertyID = item.ProductPropertyID,
                            Value = item.Value,
                            EnumerationValueID = item.EnumerationValueID
                        });
                    }             

                    firstLanguage = false;
                }                
            }

            foreach (var tempItem in tempList)
            {
                productModel.Values_Product_Properties.Add(tempItem);
            }
            productModel.Values_Product_Properties = productModel.Values_Product_Properties.OrderBy(prop => prop.ProductPropertyID).ToList();

            DAL.DAL_Product.Create(productModel);
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

        public static List<Product_ProductProperties> GetPropertiesFromProduct(int productID)
        {
            return DAL.DAL_Product.GetPropertiesFromProduct(productID);
        }

        public static List<Values_Product_ProductProperties> GetLocalizedPropertiesFromProduct(int productID)
        {
            return DAL.DAL_Product.GetLocalizedPropertiesFromProduct(productID);
        }
    }
}
