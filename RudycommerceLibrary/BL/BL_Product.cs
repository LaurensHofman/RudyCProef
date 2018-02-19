using RudycommerceLibrary.DAL;
using RudycommerceLibrary.Entities;
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
        //public static void Save(Product model)
        //{
        //    if (model.IsNew())
        //    {
        //        Create(model);
        //    }
        //}

        //private static void Create(Product model)
        //{
        //    DAL_Product.Create(model);
        //}

        public static string[] GetProductTypes(string selectedLanguage)
        {
            string[] productTypes;
            switch (selectedLanguage)
            {
                case "Nederlands":
                    productTypes = new string[]
                    {
                        "Gaming uitrusting",
                        "Game",
                        "Game console"
                    };
                    break;

                case "English":
                    productTypes = new string[]
                    {
                        "Gaming equipment",
                        "Game",
                        "Game console"
                    };
                    break;

                default:
                    productTypes = new string[]
                    {
                        "Gaming equipment",
                        "Game",
                        "Game console"
                    };
                    break;
            }

            return productTypes;
        }
    }
}
