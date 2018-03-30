using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.DAL;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
using RudycommerceLibrary.Models;

namespace RudycommerceLibrary.BL
{
    public static class BL_ProductCategory
    {
        public static List<CategoryItem> GetPotentialParents(Language selectedLanguage)
        {
            var parentList = new List<CategoryItem>();

            parentList.Add(new CategoryItem() { CategoryID = null, Name = "NO-ML No parent"});
            
            List<ProductCategory> _overview = DAL_ProductCategory.GetAll();
                        
            foreach (var _item in _overview)
            {
                var categoryItem = _item;

                int categoryID = _item.CategoryID;
                string name = "";


                bool continueDoWhile = false;
                do
                {
                    continueDoWhile = false;

                    name = ($"{GetLocalizedProductCategory(categoryItem.CategoryID, selectedLanguage).Name}") + " " + name;

                    if (categoryItem.ParentID != null)
                    {
                        categoryItem = GetParentCategory(categoryItem.ParentID);
                        name = "- " + name;
                        continueDoWhile = true;
                    }

                } while (continueDoWhile);

                parentList.Add(new CategoryItem()
                {
                    CategoryID = categoryID,
                    Name = name
                });
            }

            return parentList;
        }

        private static ProductCategory GetParentCategory(int? parentID)
        {
            return DAL_ProductCategory.GetParentCategory(parentID);
        }

        public static void Save(ProductCategory productCategoryModel, LocalizedProductCategory localizedProductCategoryModel)
        {
            if (productCategoryModel.IsNew())
            {
                Create(productCategoryModel, localizedProductCategoryModel);
            }
            else
            {
                Update(productCategoryModel, localizedProductCategoryModel);
            }
        }

        public static LocalizedProductCategory GetLocalizedProductCategory(int categoryID, Language language)
        {
            return DAL_ProductCategory.GetLocalizedProductCategory(categoryID, language);
        }

        private static void Update(ProductCategory productCategoryModel, LocalizedProductCategory localizedProductCategoryModel)
        {
            throw new NotImplementedException();
        }

        private static void Create(ProductCategory productCategoryModel, LocalizedProductCategory localizedProductCategoryModel)
        {
            DAL_ProductCategory.Create(productCategoryModel, localizedProductCategoryModel);
        }
    }
}

