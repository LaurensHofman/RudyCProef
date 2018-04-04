using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_ProductCategory
    {
        public static void Create(ProductCategory productCategoryModel, List<Models.LanguageAndCategoryItem> languageAndCategoryList)
        {
            var ctx = AppDBContext.Instance();

            ctx.ProductCategories.Add(productCategoryModel);

            // Language And Category Item/List houdt gewoon wat extra informatie in, dat ik makkelijker kon binden met m'n datagrid
            // (eigenlijk zoals een view in mssql, zodat de taalnaam ook te zien was in de datagrid)
            foreach (Models.LanguageAndCategoryItem item in languageAndCategoryList)
            {
                LocalizedProductCategory localCategory = new LocalizedProductCategory();

                localCategory.CategoryID = productCategoryModel.CategoryID;
                localCategory.LanguageID = item.LanguageID;
                localCategory.Name = item.CategoryName;

                ctx.LocalizedProductCategories.Add(localCategory);
            }

            ctx.SaveChanges();

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

        public static ProductCategory GetParentCategory(int? parentID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.ProductCategories.Single(pc => pc.CategoryID == parentID && pc.DeletedAt == null);
        }
    }
}
