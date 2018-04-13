using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
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

        public static List<LocalizedSpecificProductProperty> GetLocalizedSpecificProductProperties(Language userLanguage)
        {
            return DAL.DAL_SpecificProductProperty.GetLocalizedSpecificProductProperties(userLanguage);
        }

        public static List<NecessaryProductProperties> GetNecessaryProductProperties(Language lookupNameLanguage, int categoryID)
        {
            List<NecessaryProductProperties> necessaryProductProperties = new List<NecessaryProductProperties>();
            ProductCategory category = new ProductCategory();
            int nextCategoryID = categoryID;

            do
            {
                categoryID = nextCategoryID;

                List<Category_SpecificProductProperties> category_requiredPropertiesList = BL_SpecificProductProperty.GetProductPropertiesForCategory(categoryID);
                category = BL_ProductCategory.GetProductCategory(categoryID);

                foreach (Category_SpecificProductProperties categoryProperties in category_requiredPropertiesList)
                {
                    SpecificProductProperty productProperty = GetProductPropertyByID(categoryProperties.SpecificProductPropertyID);

                    necessaryProductProperties.Add(
                        new NecessaryProductProperties
                        {
                            PropertyID = categoryProperties.SpecificProductPropertyID,
                            IsRequired = categoryProperties.IsRequired,
                            IsMultilingual = productProperty.IsMultilingual,
                            IsBool = productProperty.IsBool,
                            LookupName = GetPropertyLookupName(lookupNameLanguage, productProperty.SpecificProductPropertyID)
                        });
                }

                if (category.ParentID != null)
                {
                    nextCategoryID = category.ParentID.Value;
                }
            } while (category.ParentID != null);

            return necessaryProductProperties.Distinct(new Utilities.DistinctItemComparerProperties()).ToList() ;
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
