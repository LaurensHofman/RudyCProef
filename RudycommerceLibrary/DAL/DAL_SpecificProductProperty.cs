using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;
using RudycommerceLibrary.View;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_SpecificProductProperty
    {
        public static void CreateNonEnumProperty(SpecificProductProperty specificProductPropertyModel, List<LanguageAndSpecificPropertyItem> languageAndSpecificPropertyList)
        {
            var ctx = AppDBContext.Instance();
            
            using (var dbContextTransaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    ctx.SpecificProductProperties.Add(specificProductPropertyModel);

                    ctx.SaveChanges();

                    foreach (Models.LanguageAndSpecificPropertyItem item in languageAndSpecificPropertyList)
                    {
                        LocalizedSpecificProductProperty localProductProperty = new LocalizedSpecificProductProperty
                        {
                            SpecificProductPropertyID = specificProductPropertyModel.SpecificProductPropertyID,
                            LanguageID = item.LanguageID,
                            LookupName = item.PropertyName
                        };

                        ctx.LocalizedSpecificProductProperties.Add(localProductProperty);
                    }

                    ctx.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }
            
        }

        public static void CreateEnumProperty(SpecificProductProperty specificProductPropertyModel, List<LanguageAndSpecificPropertyItem> languageAndSpecificPropertyList, List<PropertyEnumerations> propertyEnumerations)
        {
            var ctx = AppDBContext.Instance();

            ctx.SpecificProductProperties.Add(specificProductPropertyModel);

            ctx.SaveChanges();

            foreach (Models.LanguageAndSpecificPropertyItem item in languageAndSpecificPropertyList)
            {
                LocalizedSpecificProductProperty localProductProperty = new LocalizedSpecificProductProperty
                {
                    SpecificProductPropertyID = specificProductPropertyModel.SpecificProductPropertyID,
                    LanguageID = item.LanguageID,
                    LookupName = item.PropertyName
                };

                ctx.LocalizedSpecificProductProperties.Add(localProductProperty);
            }

            ctx.SaveChanges();

            foreach (PropertyEnumerations enums in propertyEnumerations)
            {
                enums.PropertyID = specificProductPropertyModel.SpecificProductPropertyID;

                ctx.PropertyEnumerations.Add(enums);

                ctx.SaveChanges();

                foreach (var item in enums.ValuesList)
                {
                    item.EnumerationID = enums.EnumerationValueID;

                    ctx.LocalizedEnumValues.Add(item);
                }
            }

            ctx.SaveChanges();
        }

        public static List<LocalizedSpecificProductProperty> GetLocalizedSpecificProductProperties(Language userLanguage)
        {
            var ctx = AppDBContext.Instance();

            return ctx.LocalizedSpecificProductProperties.Where(lspp => lspp.LanguageID == userLanguage.LanguageID && lspp.DeletedAt == null).ToList();

            //List<SpecificProductProperty> propertyList = new List<SpecificProductProperty>();

            //List<PropertyAndNameView> returnList = new List<PropertyAndNameView>();

            //propertyList = ctx.SpecificProductProperties.Where(prop => prop.DeletedAt == null).ToList();

            //foreach (var property in propertyList)
            //{
            //    returnList.Add(new PropertyAndNameView() { PropertyID = property.SpecificProductPropertyID
            //                                        , PropertyName = GetPropertyLookupName(property.SpecificProductPropertyID, userLanguage) });
            //}

            //return returnList;
        }


        public static List<SpecificProductPropertyOverViewItem> GetPropertyOverview(Language userLanguage)
        {
            var ctx = AppDBContext.Instance();

            return ctx.vSpecificProductPropertyOverview.Where(p => p.LanguageID == userLanguage.LanguageID).ToList() ;
        }

        public static List<NecessaryProductPropertyViewItem> GetNecessaryProductProperties(Language lookupNameLanguage, int? categoryID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.vNecessaryProductPropertiesView.Where(npp => npp.LanguageID == lookupNameLanguage.LanguageID
                                && npp.CategoryID == categoryID).ToList() ;
        }

        public static List<Category_SpecificProductProperties> GetProductPropertiesForCategory(int categoryID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Category_SpecificProductProperties.Where(cspp => cspp.CategoryID == categoryID && cspp.DeletedAt == null).ToList();
        }

        public static IEnumerable GetPropertyEnumerations(Language userLanguage, int specificProductPropertyID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.vLocalizedEnumerationView
                .Where(enums => enums.LanguageID == userLanguage.LanguageID
                    && enums.PropertyID == specificProductPropertyID)
                    .ToList();
        }

        public static string GetPropertyLookupName(int specificProductPropertyID, Language userLanguage)
        {
            var ctx = AppDBContext.Instance();

            return ctx.LocalizedSpecificProductProperties.SingleOrDefault(sProp => sProp.SpecificProductPropertyID == specificProductPropertyID &&
                                                                        sProp.LanguageID == userLanguage.LanguageID).LookupName;
        }
        
        public static SpecificProductProperty GetProductPropertyByID(int specificProductPropertyID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.SpecificProductProperties.SingleOrDefault(spp => spp.SpecificProductPropertyID == specificProductPropertyID && spp.DeletedAt == null);
        }

        //public static void TestView()
        //{
        //    var ctx = AppDBContext.Instance();

        //    var test = ctx.TestViews.Where(x => x.IsBool == true).ToList();
        //    test.OrderBy(x => x.LookupName);
        //}
    }
}
