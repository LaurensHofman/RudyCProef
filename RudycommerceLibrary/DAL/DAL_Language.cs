using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_Language
    {
        public static void Create(SiteLanguage model)
        {
            var ctx = AppDBContext.Instance();

            ctx.Languages.Add(model);
            ctx.SaveChanges();
        }

        public static SiteLanguage GetDefaultLanguage()
        {
            var ctx = AppDBContext.Instance();

            return ctx.Languages.SingleOrDefault(l => l.IsDefault == true);
        }

        public static string GetLanguageName(int languageID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Languages.SingleOrDefault(l => l.LanguageID == languageID).LanguageName;
        }
    }
}
