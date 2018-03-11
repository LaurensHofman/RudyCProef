using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            return ctx.Languages.SingleOrDefault(l => l.LanguageID == languageID).LocalName;
        }

        public static void Update(SiteLanguage model)
        {
            var ctx = AppDBContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static List<SiteLanguage> GetAllLanguages()
        {
            var ctx = AppDBContext.Instance();

            return ctx.Languages.Where(l => l.DeletedAt == null)
                .OrderBy(l => l.IsDefault)
                .ThenByDescending(l => l.IsActive)
                .ThenBy(l => l.ISO)
                .ToList();
        }
    }
}
