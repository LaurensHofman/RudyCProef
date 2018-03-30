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
        public static void Create(Language model)
        {
            var ctx = AppDBContext.Instance();

            ctx.Languages.Add(model);
            ctx.SaveChanges();
        }

        public static Language GetDefaultLanguage()
        {
            var ctx = AppDBContext.Instance();

            return ctx.Languages.SingleOrDefault(l => l.IsDefault == true);
        }

        public static string GetLanguageName(int languageID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Languages.SingleOrDefault(l => l.LanguageID == languageID).LocalName;
        }

        public static void Update(Language model)
        {
            var ctx = AppDBContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static List<Language> GetAllLanguages()
        {
            var ctx = AppDBContext.Instance();

            return ctx.Languages.Where(l => l.DeletedAt == null)
                .OrderByDescending(l => l.IsDefault)
                .ThenByDescending(l => l.IsActive)
                .ThenBy(l => l.ISO)
                .ToList();
        }

        public static List<Language> GetDesktopLanguages()
        {
            var ctx = AppDBContext.Instance();

            return ctx.Languages.Where(l => l.IsDesktopLanguage == true).ToList();
        }

        public static Language GetLanguageByID(int preferredLanguageID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.Languages.Single(l => l.DeletedAt == null && l.LanguageID == preferredLanguageID);
        }

        public static string[] GetAllISOCodes()
        {
            var ctx = AppDBContext.Instance();

            return ctx.Languages.Where(l => l.DeletedAt == null).Select(l => l.ISO).ToArray();
        }
    }
}
