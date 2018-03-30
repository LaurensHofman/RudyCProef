using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_ProductCategory
    {
        public static void Create(ProductCategory productCategoryModel, LocalizedProductCategory localizedProductCategoryModel)
        {
            var ctx = AppDBContext.Instance();

            ctx.ProductCategories.Add(productCategoryModel);

            localizedProductCategoryModel.CategoryID = productCategoryModel.CategoryID;

            ctx.LocalizedProductCategories.Add(localizedProductCategoryModel);

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

            return ctx.LocalizedProductCategories.Single(lpc => lpc.CategoryID == categoryID && lpc.LanguageID == language.LanguageID);
        }

        public static ProductCategory GetParentCategory(int? parentID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.ProductCategories.Single(pc => pc.CategoryID == parentID && pc.DeletedAt == null);
        }
    }
}
