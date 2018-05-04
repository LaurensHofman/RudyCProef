using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_ProductCategory
    {
        public static void Create(ProductCategory productCategoryModel, List<Models.LanguageAndCategoryItem> languageAndCategoryList, List<PropertyAndCategoryItem> propertyAndCategoriesList)
        {
            var ctx = AppDBContext.Instance();

            using (var ctxTransaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    ctx.ProductCategories.Add(productCategoryModel);

                    foreach (LanguageAndCategoryItem item in languageAndCategoryList)
                    {
                        LocalizedProductCategory localCategory = new LocalizedProductCategory();

                        localCategory.CategoryID = productCategoryModel.CategoryID;
                        localCategory.LanguageID = item.LanguageID;
                        localCategory.Name = item.CategoryName;

                        ctx.LocalizedProductCategories.Add(localCategory);
                    }

                    foreach (PropertyAndCategoryItem item in propertyAndCategoriesList)
                    {
                        Category_SpecificProductProperties categoryProperties = new Category_SpecificProductProperties();

                        categoryProperties.CategoryID = productCategoryModel.CategoryID;
                        categoryProperties.SpecificProductPropertyID = item.PropertyID;
                        //categoryProperties.IsRequired = item.IsRequired;

                        ctx.Category_SpecificProductProperties.Add(categoryProperties);
                    }

                    ctx.SaveChanges();

                    ctxTransaction.Commit();
                }
                catch (Exception)
                {
                    ctxTransaction.Rollback();
                }
            }
        }
        
        public static List<ProductCategory> GetAll()
        {
            var ctx = AppDBContext.Instance();

            return ctx.ProductCategories.Where(pc => pc.DeletedAt == null).ToList();
        }

        public static LocalizedProductCategory GetLocalizedProductCategory(int categoryID, Language language)
        {
            var ctx = AppDBContext.Instance();
                        
            LocalizedProductCategory returnLocalizedCategory = ctx.LocalizedProductCategories.SingleOrDefault(lpc => lpc.CategoryID == categoryID && lpc.LanguageID == language.LanguageID);

            if (returnLocalizedCategory == null)
            {
                Language defaultLanguage = BL_Language.GetDefaultLanguage();
                returnLocalizedCategory = ctx.LocalizedProductCategories.Single(lpc => lpc.CategoryID == categoryID && lpc.LanguageID == defaultLanguage.LanguageID);
            }

            return returnLocalizedCategory;
        }

        public static ProductCategory GetProductCategory(int categoryID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.ProductCategories.SingleOrDefault(pc => pc.CategoryID == categoryID && pc.DeletedAt == null);
        }

        public static ProductCategory GetParentCategory(int? parentID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.ProductCategories.Single(pc => pc.CategoryID == parentID && pc.DeletedAt == null);
        }
    }
}
