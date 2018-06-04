using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_ProductCategory
    {
        public static void Create(ProductCategory productCategoryModel)
        {
            var ctx = AppDBContext.Instance();

            using (var ctxTransaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    ctx.ProductCategories.Add(productCategoryModel);

                    ctx.SaveChanges();

                    ctxTransaction.Commit();
                }
                catch (Exception)
                {
                    ctxTransaction.Rollback();
                    // TODO Throw ERROR
                }
            }
        }
        
        public static List<ProductCategory> GetAll()
        {
            var ctx = AppDBContext.Instance();

            return ctx.ProductCategories.Where(pc => pc.DeletedAt == null).ToList();
        }

        public static LocalizedCategory GetLocalizedProductCategory(int categoryID, Language language)
        {
            var ctx = AppDBContext.Instance();
                        
            LocalizedCategory returnLocalizedCategory = ctx.LocalizedProductCategories.SingleOrDefault(lpc => lpc.CategoryID == categoryID && lpc.LanguageID == language.LanguageID);

            if (returnLocalizedCategory == null)
            {
                Language defaultLanguage = BL_Language.GetDefaultLanguage();
                returnLocalizedCategory = ctx.LocalizedProductCategories.Single(lpc => lpc.CategoryID == categoryID && lpc.LanguageID == defaultLanguage.LanguageID);
            }

            return returnLocalizedCategory;
        }

        public static ProductCategory GetProductCategory(int categoryID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.ProductCategories.SingleOrDefault(pc => pc.CategoryID == categoryID && pc.DeletedAt == null);
        }

        public static ProductCategory GetParentCategory(int? parentID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.ProductCategories.Single(pc => pc.CategoryID == parentID && pc.DeletedAt == null);
        }
    }
}
