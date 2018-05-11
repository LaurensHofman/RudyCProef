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
        //    parentList.Insert(0, new CategoryItem() { CategoryID = null, Name = BL_Multilingual.NO_PARENT(Settings.UserLanguage) });

        //    return parentList;
        //}

        //public static List<CategoryItem> GetCategoryListWithParent(Language selectedLanguage)
        //{
        //    var categoryList = new List<CategoryItem>();

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

        //        categoryList.Add(new CategoryItem()
        //        {
        //            CategoryID = categoryID,
        //            Name = name
        //        });
        //    }

        //    categoryList.OrderBy(ppc => ppc.Name).ToList();
            
        //    return categoryList;
        //}

        public static ProductCategory GetProductCategory(int categoryID)
        {
            return DAL_ProductCategory.GetProductCategory(categoryID);
        }

        public static List<ProductCategory> GetLocalizedCategories(Language userLanguage)
        {
            List<ProductCategory> categoryList = DAL_ProductCategory.GetAll();

            foreach (ProductCategory cat in categoryList)
            {
                cat.LocalizedName = cat.LocalizedProductCategories.SingleOrDefault(c => c.LanguageID == userLanguage.LanguageID).Name;
            }
                       
            return categoryList;
        }

        //private static ProductCategory GetParentCategory(int? parentID)
        //{
        //    return DAL_ProductCategory.GetParentCategory(parentID);
        //}
        
        public static LocalizedCategory GetLocalizedProductCategory(int categoryID, Language language)
        {
            return DAL_ProductCategory.GetLocalizedProductCategory(categoryID, language);
        }

        public static void Create(ProductCategory productCategoryModel)
        {
            DAL_ProductCategory.Create(productCategoryModel);
        }


    }
}

