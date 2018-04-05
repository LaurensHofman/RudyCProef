using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Models;

namespace RudycommerceLibrary.BL
{
    public static class BL_SpecificProductProperty
    {
        public static void Save(SpecificProductProperty specificProductPropertyModel, List<LanguageAndSpecificPropertyItem> languageAndSpecificPropertyList)
        {
            if (specificProductPropertyModel.IsNew())
            {
                Create(specificProductPropertyModel, languageAndSpecificPropertyList);
            }
        }

        private static void Create(SpecificProductProperty specificProductPropertyModel, List<LanguageAndSpecificPropertyItem> languageAndSpecificPropertyList)
        {
            DAL.DAL_SpecificProductProperty.Create(specificProductPropertyModel, languageAndSpecificPropertyList);
        }

        public static List<PropertyAndName> GetListWithNames(Language userLanguage)
        {
            return DAL.DAL_SpecificProductProperty.GetListWithNames(userLanguage);
        }
    }
}
