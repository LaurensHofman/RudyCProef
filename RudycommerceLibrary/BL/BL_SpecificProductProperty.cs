using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;
using RudycommerceLibrary.View;

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

        public static List<LocalizedSpecificProductProperty> GetLocalizedSpecificProductProperties(Language userLanguage)
        {
            return DAL.DAL_SpecificProductProperty.GetLocalizedSpecificProductProperties(userLanguage);
        }

        public static List<SpecificProductPropertyOverViewItem> GetPropertyOverview(Language userLanguage)
        {
            return DAL.DAL_SpecificProductProperty.GetPropertyOverview(userLanguage);
        }

        public static List<NecessaryProductPropertyViewItem> GetNecessaryProductProperties(Language lookupNameLanguage, int categoryID)
        {
            return DAL.DAL_SpecificProductProperty.GetNecessaryProductProperties(lookupNameLanguage, categoryID);

            //List<NecessaryProductPropertyViewItem> necessaryProductProperties = new List<NecessaryProductPropertyViewItem>();
            //int? nextCategoryID = categoryID;
            //bool anyParents = false;

            //do
            //{
            //    anyParents = false;

            //    necessaryProductProperties.AddRange(DAL.DAL_SpecificProductProperty.GetNecessaryProductProperties(lookupNameLanguage, nextCategoryID));
                

            //    if (  necessaryProductProperties.Any(npp => npp.CategoryID == nextCategoryID && npp.CategoryParentID != null))
            //    {
            //        nextCategoryID =
            //            necessaryProductProperties.Find(npp => npp.CategoryID == nextCategoryID && npp.CategoryParentID != null).CategoryParentID;
            //        anyParents = true;
            //    }

            //} while (anyParents);

            //return necessaryProductProperties.Distinct(new Utilities.DistinctItemComparerProperties()).ToList();
        }

        public static string GetPropertyLookupName(Language lookupNameLanguage, int specificProductPropertyID)
        {
            return DAL.DAL_SpecificProductProperty.GetPropertyLookupName(specificProductPropertyID, lookupNameLanguage);
        }

        public static SpecificProductProperty GetProductPropertyByID(int specificProductPropertyID)
        {
            return DAL.DAL_SpecificProductProperty.GetProductPropertyByID(specificProductPropertyID);
        }

        private static List<Category_SpecificProductProperties> GetProductPropertiesForCategory(int categoryID)
        {
            return DAL.DAL_SpecificProductProperty.GetProductPropertiesForCategory(categoryID);
        }
    }
}
