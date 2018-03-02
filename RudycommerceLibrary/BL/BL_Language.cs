using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.DAL;
using RudycommerceLibrary.Entities;

namespace RudycommerceLibrary.BL
{
    public static class BL_Language
    {
        public static void Save(SiteLanguage model)
        {
            if (model.IsNew())
            {
                Create(model);
            }
        }

        private static void Create(SiteLanguage model)
        {
            DAL_Language.Create(model);
        }

        public static SiteLanguage GetDefaultLanguage()
        {
            return DAL_Language.GetDefaultLanguage();
        }
    }
}
