using RudycommerceLibrary.DAL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL
{
    public static class BL_Product
    {
        public static void Save(Product product)
        {
            if (product.IsNew())
            {
                Create(product);
            }
        }

        private static void Create(Product product)
        {
            DAL_Product.Create(product);
        }

        public static string[] GetProductTypes(string selectedLanguage)
        {
            string[] productTypes;

            productTypes = BL_Multilingual.ProductTypes(selectedLanguage);

            //productTypes = new string[]
            //{
            //    BL_Multilingual.GamingEquipment(selectedLanguage),
            //    BL_Multilingual.Game(selectedLanguage)
            //    //, BL_Multilingual.GameConsole(selectedLanguage)
            //};
                        
            return productTypes;
        }

        /// <summary>
        /// Returns array of the specific product types, based on the selected product type
        /// </summary>
        /// <param name="selectedLanguage"></param>
        /// <param name="productType"></param>
        /// <returns></returns>
        public static string[] GetSpecificProductTypes(string selectedLanguage, string productType)
        {
            string[] specificProductTypes;

            switch (productType)
            {
                case "Gaming equipment":
                    specificProductTypes = BL_Multilingual.SpecificTypesGamingEquipment(selectedLanguage);
                    break;

                    // Game doesn't have subtypes -yet-

                default:
                    specificProductTypes = null;
                    break;
            }

            return specificProductTypes;
        }
    }
}
