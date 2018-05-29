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
        public static void CreateNonEnumProperty(ProductProperty specificProductPropertyModel/*, List<LanguageAndSpecificPropertyItem> languageAndSpecificPropertyList*/)
        {
            var ctx = AppDBContext.Instance();
            
            using (var dbContextTransaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    ctx.SpecificProductProperties.Add(specificProductPropertyModel);

                    ctx.SaveChanges();

                    //foreach (Models.LanguageAndSpecificPropertyItem item in languageAndSpecificPropertyList)
                    //{
                    //    LocalizedProperty localProductProperty = new LocalizedProperty
                    //    {
                    //        PropertyID = specificProductPropertyModel.PropertyID,
                    //        LanguageID = item.LanguageID,
                    //        LookupName = item.PropertyName
                    //    };

                    //    ctx.LocalizedSpecificProductProperties.Add(localProductProperty);
                    //}

                    //ctx.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }
            
        }

        public static void CreateEnumProperty(ProductProperty specificProductPropertyModel/*, List<LanguageAndSpecificPropertyItem> languageAndSpecificPropertyList,*/ , List<PropertyEnumerations> propertyEnumerations)
        {
            var ctx = AppDBContext.Instance();

            ctx.SpecificProductProperties.Add(specificProductPropertyModel);

            ctx.SaveChanges();

            //foreach (Models.LanguageAndSpecificPropertyItem item in languageAndSpecificPropertyList)
            //{
            //    LocalizedProperty localProductProperty = new LocalizedProperty
            //    {
            //        PropertyID = specificProductPropertyModel.PropertyID,
            //        LanguageID = item.LanguageID,
            //        LookupName = item.PropertyName
            //    };

            //    ctx.LocalizedSpecificProductProperties.Add(localProductProperty);
            //}

            //ctx.SaveChanges();

            foreach (PropertyEnumerations enums in propertyEnumerations)
            {
                enums.PropertyID = specificProductPropertyModel.PropertyID;

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

        public static List<LocalizedProperty> GetLocalizedSpecificProductProperties(Language userLanguage)
        {
            var ctx = AppDBContext.Instance();

            return ctx.LocalizedSpecificProductProperties.Where(lspp => lspp.LanguageID == userLanguage.LanguageID).ToList();
        }

        public static List<LocalizedProperty> GetLocalizedSpecificProductProperties(int userLanguageID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.LocalizedSpecificProductProperties.Where(lspp => lspp.LanguageID == userLanguageID).ToList();
        }

        public static List<ProductProperty> GetProperties(List<int> propIDs)
        {
            var ctx = AppDBContext.Instance();

            return ctx.SpecificProductProperties.Where(p => propIDs.Contains(p.PropertyID)).ToList();
        }

        //public static List<LocalizedProperty> GetLocalizedSpecificProductProperties(List<int> propIDs, int engID)
        //{
        //    var ctx = AppDBContext.Instance();

        //    return ctx.LocalizedSpecificProductProperties.Where(x => propIDs.Contains(x.PropertyID) && x.LanguageID == engID).ToList() ;
        //}
        
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

        public static List<Category_Property> GetProductPropertiesForCategory(int categoryID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Category_SpecificProductProperties.Where(cspp => cspp.CategoryID == categoryID).ToList();
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

            return ctx.LocalizedSpecificProductProperties.SingleOrDefault(sProp => sProp.PropertyID == specificProductPropertyID &&
                                                                        sProp.LanguageID == userLanguage.LanguageID).LookupName;
        }
        
        public static ProductProperty GetProductPropertyByID(int specificProductPropertyID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.SpecificProductProperties.SingleOrDefault(spp => spp.PropertyID == specificProductPropertyID && spp.DeletedAt == null);
        }

        //public static void TestView()
        //{
        //    var ctx = AppDBContext.Instance();

        //    var test = ctx.TestViews.Where(x => x.IsBool == true).ToList();
        //    test.OrderBy(x => x.LookupName);
        //}
    }
}
