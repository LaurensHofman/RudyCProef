﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_SpecificProductProperty
    {
        public static void Create(SpecificProductProperty specificProductPropertyModel, List<LanguageAndSpecificPropertyItem> languageAndSpecificPropertyList)
        {
            var ctx = AppDBContext.Instance();

            ctx.SpecificProductProperties.Add(specificProductPropertyModel);

            foreach (Models.LanguageAndSpecificPropertyItem item in languageAndSpecificPropertyList)
            {
                LocalizedSpecificProductProperty localProductProperty = new LocalizedSpecificProductProperty();

                localProductProperty.SpecificProductPropertyID = specificProductPropertyModel.SpecificProductPropertyID;
                localProductProperty.LanguageID = item.LanguageID;
                localProductProperty.LookupName = item.PropertyName;

                ctx.LocalizedSpecificProductProperties.Add(localProductProperty);
            }

            ctx.SaveChanges();
        }

        public static List<PropertyAndName> GetListWithNames(Language userLanguage)
        {
            var ctx = AppDBContext.Instance();

            List<SpecificProductProperty> propertyList = new List<SpecificProductProperty>();

            List<PropertyAndName> returnList = new List<PropertyAndName>();

            propertyList = ctx.SpecificProductProperties.Where(prop => prop.DeletedAt == null).ToList();

            foreach (var property in propertyList)
            {
                returnList.Add(new PropertyAndName() { PropertyID = property.SpecificProductPropertyID
                                                    , PropertyName = GetPropertyName(property.SpecificProductPropertyID, userLanguage) });
            }

            return returnList;
        }

        private static string GetPropertyName(int specificProductPropertyID, Language userLanguage)
        {
            var ctx = AppDBContext.Instance();

            return ctx.LocalizedSpecificProductProperties.SingleOrDefault(sProp => sProp.SpecificProductPropertyID == specificProductPropertyID &&
                                                                        sProp.LanguageID == userLanguage.LanguageID).LookupName;
        }
    }
}
