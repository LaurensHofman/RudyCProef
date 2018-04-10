using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public static List<CategoryItem> GetPotentialParents(Language selectedLanguage)
        //{
        //    var parentList = new List<CategoryItem>();
            
        //    // gets all categories
        //    List<ProductCategory> _overview = DAL_ProductCategory.GetAll();
            

        //    foreach (var _item in _overview)
        //    {
        //        var categoryItem = _item;

        //        int categoryID = _item.CategoryID;
        //        string name = "";

        //        bool parentsLeft = false;

        //        do
        //        {
        //            parentsLeft = false;

        //            name = ($"{GetLocalizedProductCategory(categoryItem.CategoryID, selectedLanguage).Name}") + " " + name;

        //            if (categoryItem.ParentID != null)
        //            {
        //                categoryItem = GetParentCategory(categoryItem.ParentID);
        //                name = "- " + name;
        //                parentsLeft = true;
        //            }

        //        } while (parentsLeft);

        //        parentList.Add(new CategoryItem()
        //        {
        //            CategoryID = categoryID,
        //            Name = name
        //        });
        //    }

        //    parentList.OrderBy(ppc => ppc.Name).ToList();

        //    // adds an 'empty' parent (at the start of the list)~§, with no categoryID, for when there is no parent
        //    parentList.Insert(0, new CategoryItem() { CategoryID = null, Name = "NO-ML No parent" });

        //    return parentList;
        //}

        public static List<CategoryItem> GetCategoryNameWithID(Language userLanguage)
        {
            List<ProductCategory> categoryList = DAL_ProductCategory.GetAll();

            List<CategoryItem> categoryItemList = new List<CategoryItem>();

            foreach (ProductCategory category in categoryList)
            {
                categoryItemList.Add(new CategoryItem
                {
                    CategoryID = category.CategoryID,
                    Name = GetLocalizedProductCategory(category.CategoryID, userLanguage).Name
                });
            }

            return categoryItemList;
        }

        private static ProductCategory GetParentCategory(int? parentID)
        {
            return DAL_ProductCategory.GetParentCategory(parentID);
        }

        public static void Save(ProductCategory productCategoryModel, List<LanguageAndCategoryItem> languageAndCategoryList, List<PropertyAndCategoryItem> propertyAndCategoriesList)
        {
            if (productCategoryModel.IsNew())
            {
                Create(productCategoryModel, languageAndCategoryList, propertyAndCategoriesList);
            }
        }




        //public static void Save(ProductCategory productCategoryModel, LocalizedProductCategory localizedProductCategoryModel)
        //{
        //    if (productCategoryModel.IsNew())
        //    {
        //        Create(productCategoryModel, localizedProductCategoryModel);
        //    }
        //    else
        //    {
        //        Update(productCategoryModel, localizedProductCategoryModel);
        //    }
        //}

        public static LocalizedProductCategory GetLocalizedProductCategory(int categoryID, Language language)
        {
            return DAL_ProductCategory.GetLocalizedProductCategory(categoryID, language);
        }

        private static void Update(ProductCategory productCategoryModel, List<LanguageAndCategoryItem> languageAndCategoryList)
        {
            throw new NotImplementedException();
        }

        private static void Create(ProductCategory productCategoryModel, List<LanguageAndCategoryItem> languageAndCategoryList, List<PropertyAndCategoryItem> propertyAndCategoriesList)
        {
            DAL_ProductCategory.Create(productCategoryModel, languageAndCategoryList, propertyAndCategoriesList);
        }
    }
}

