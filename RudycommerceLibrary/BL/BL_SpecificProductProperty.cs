using System;
using System.Collections;
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
    public static class BL_SpecificProductProperty
    {
        public static void Save(ProductProperty specificProductPropertyModel/*, List<LanguageAndSpecificPropertyItem> languageAndSpecificPropertyList*/
            , List<PropertyEnumerations> propertyEnumerations)
        {
            try
            {
                if (specificProductPropertyModel.IsNew())
                {
                    Create(specificProductPropertyModel/*, languageAndSpecificPropertyList*/, propertyEnumerations);
                }
            }
            catch (Exception)
            {
                throw new SaveFailed();
            }            
        }

        private static void Create(ProductProperty specificProductPropertyModel/*, List<LanguageAndSpecificPropertyItem> languageAndSpecificPropertyList*/
            , List<PropertyEnumerations> propertyEnumerations)
        {
            // I know, this isn't cleanly done, when I began on this project, I didn't know a thing about Lazy loading...
            
            if (specificProductPropertyModel.IsEnumeration == false)
            {
                DAL.DAL_SpecificProductProperty.CreateNonEnumProperty(specificProductPropertyModel/*, languageAndSpecificPropertyList*/);
            }
            else
            {
                if (specificProductPropertyModel.IsMultilingual == true)
                {
                    DAL.DAL_SpecificProductProperty.CreateEnumProperty(specificProductPropertyModel/*, languageAndSpecificPropertyList*/, propertyEnumerations);
                }
                else
                {
                    var languageList = DAL.DAL_Language.GetAllLanguages();

                    foreach (var item in propertyEnumerations)
                    {
                        foreach (var values in item.ValuesList)
                        {
                            values.Value = item.TemporaryNonMLValue;
                        }
                    }

                    DAL.DAL_SpecificProductProperty.CreateEnumProperty(specificProductPropertyModel/*, languageAndSpecificPropertyList*/, propertyEnumerations);
                }
            }             
        }

        public static List<LocalizedProperty> GetLocalizedSpecificProductProperties(Language userLanguage)
        {
            return DAL.DAL_SpecificProductProperty.GetLocalizedSpecificProductProperties(userLanguage);
        }

        public static List<LocalizedProperty> GetLocalizedSpecificProductProperties(int userLanguageID)
        {
            return DAL.DAL_SpecificProductProperty.GetLocalizedSpecificProductProperties(userLanguageID);
        }

        public static List<PropertyDetails> GetPropertyDetails(List<Values_Product_ProductProperties> prodValues, int engID)
        {
            List<int> propIDs = new List<int>();
            
            foreach (Values_Product_ProductProperties val in prodValues)
            {
                propIDs.Add(val.ProductPropertyID);
            }

            //List<LocalizedProperty> locProps = DAL.DAL_SpecificProductProperty.GetLocalizedSpecificProductProperties(propIDs, engID);

            List<ProductProperty> props = DAL.DAL_SpecificProductProperty.GetProperties(propIDs);

            List<PropertyDetails> returnDetails = new List<PropertyDetails>();

            foreach (var prop in props)
            {
                var locproperty = prop.LocalizedSpecificProductProperties.SingleOrDefault(lp => lp.LanguageID == engID);

                PropertyDetails det = new PropertyDetails
                {
                    IsBool = prop.IsBool,
                    IsEnumeration = prop.IsEnumeration,
                    IsMultilingual = prop.IsMultilingual,
                    PropertyID = prop.PropertyID,
                    LookupName = locproperty.LookupName,
                    AdviceDescription = locproperty.AdviceDescription
                };

                returnDetails.Add(det);
            }

            return returnDetails;
        }

        public static List<SpecificProductPropertyOverViewItem> GetPropertyOverview(Language userLanguage)
        {
            return DAL.DAL_SpecificProductProperty.GetPropertyOverview(userLanguage);
        }

        public static List<NecessaryProductPropertyViewItem> GetNecessaryProductProperties(Language lookupNameLanguage, int categoryID)
        {
            return DAL.DAL_SpecificProductProperty.GetNecessaryProductProperties(lookupNameLanguage, categoryID);

            //List<NecessaryProductPropertyViewItem> necessaryProductProperties = new List<NecessaryProductPropertyViewItem>();
            //int? nextCategoryID = categoryID;
            //bool anyParents = false;

            //do
            //{
            //    anyParents = false;

            //    necessaryProductProperties.AddRange(DAL.DAL_SpecificProductProperty.GetNecessaryProductProperties(lookupNameLanguage, nextCategoryID));
                

            //    if (  necessaryProductProperties.Any(npp => npp.CategoryID == nextCategoryID && npp.CategoryParentID != null))
            //    {
            //        nextCategoryID =
            //            necessaryProductProperties.Find(npp => npp.CategoryID == nextCategoryID && npp.CategoryParentID != null).CategoryParentID;
            //        anyParents = true;
            //    }

            //} while (anyParents);

            //return necessaryProductProperties.Distinct(new Utilities.DistinctItemComparerProperties()).ToList();
        }

        public static string GetPropertyLookupName(Language lookupNameLanguage, int specificProductPropertyID)
        {
            return DAL.DAL_SpecificProductProperty.GetPropertyLookupName(specificProductPropertyID, lookupNameLanguage);
        }

        public static ProductProperty GetProductPropertyByID(int specificProductPropertyID)
        {
            return DAL.DAL_SpecificProductProperty.GetProductPropertyByID(specificProductPropertyID);
        }

        private static List<Category_Property> GetProductPropertiesForCategory(int categoryID)
        {
            return DAL.DAL_SpecificProductProperty.GetProductPropertiesForCategory(categoryID);
        }

        public static IEnumerable GetPropertyEnumerations(Language userLanguage, int specificProductPropertyID)
        {
            return DAL.DAL_SpecificProductProperty.GetPropertyEnumerations(userLanguage, specificProductPropertyID);
        }
    }
}
