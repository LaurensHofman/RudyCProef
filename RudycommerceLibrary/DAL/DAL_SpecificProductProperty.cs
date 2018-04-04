using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
