﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.CustomExceptions;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;
using RudycommerceLibrary.View;

namespace RudycommerceLibrary.BL
{
    public static class BL_Product
    {
        public static async Task Create(Product productModel)
        {

            try
            {
                // For each value where the language wasn't defined, saves the value for each language

                productModel.CurrentStock = productModel.InitialStock.Value;

                List<Language> LanguageList = BL_Language.GetAllLanguages();

                List<Values_Product_ProductProperties> tempList = new List<Values_Product_ProductProperties>();

                foreach (var item in productModel.Values_Product_Properties
                                        .Where(x => x.LanguageID == null))
                {
                    bool firstLanguage = true;
                    foreach (Language lang in LanguageList)
                    {
                        if (firstLanguage == true)
                        {
                            item.LanguageID = lang.LanguageID;
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
                            });
                        }

                        firstLanguage = false;
                    }
                }

                foreach (var tempItem in tempList)
                {
                    productModel.Values_Product_Properties.Add(tempItem);
                }
                productModel.Values_Product_Properties = productModel.Values_Product_Properties.OrderBy(prop => prop.ProductPropertyID).ToList();

                await DAL.DAL_Product.Create(productModel);
            }
            catch (Exception)
            {
                throw new SaveFailed();
            }            
        }

        public static ProductDetails GetProductDetails(int productID, int engID)
        {
            ProductDetails productDetails = new ProductDetails();

            #region ProductDetails.Product            

            productDetails.Product = GetProduct(productID);

            List<Values_Product_ProductProperties> prodValues;
            prodValues = productDetails.Product.Values_Product_Properties.Where(p => p.LanguageID == engID).ToList();
            productDetails.Product.Values_Product_Properties = prodValues;

            // Filtering unnecessary data from the product

            foreach (var val in productDetails.Product.Values_Product_Properties)
            {
                if (val.EnumerationValueID != null)
                {
                    val.DisplayValue = val.EnumerationValue.LocalizedEnumerationValues.SingleOrDefault(enm => enm.LanguageID == engID).Value;
                }
                else
                {
                    val.DisplayValue = val.Value;
                }
            }

            #endregion


            #region ProductDetails.PropertyDetails 

            productDetails.PropertyDetails = BL_SpecificProductProperty.GetPropertyDetails(prodValues, engID);
            
            #endregion


            return productDetails;
        }

        public static HomePageProductViewItem[] GetHomePageProducts()
        {
            return DAL.DAL_Product.GetHomePageProducts();
        }

        public static List<ProductOverViewItem> GetProductOverview(Language userLanguage)
        {
            return DAL.DAL_Product.GetProductOverview(userLanguage);
        }

        public static Product GetProduct(int productID)
        {
            return DAL.DAL_Product.GetProduct(productID);
        }

        public static List<LocalizedProduct> GetLocalizedProductList(int productID)
        {
            return DAL.DAL_Product.GetLocalizedProductList(productID);
        }

        public static List<Product_ProductProperties> GetPropertiesFromProduct(int productID)
        {
            return DAL.DAL_Product.GetPropertiesFromProduct(productID);
        }

        public static List<Values_Product_ProductProperties> GetLocalizedPropertiesFromProduct(int productID)
        {
            return DAL.DAL_Product.GetLocalizedPropertiesFromProduct(productID);
        }
    }
}
