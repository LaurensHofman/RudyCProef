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
            if (model.IsDefault == true)
            {
                MakeNewLanguageDefault();
            }

            if (model.IsNew())
            {
                Create(model);
            }
            else
            {
                Update(model);
            }
        }

        private static void MakeNewLanguageDefault()
        {
            if (IsThereAlreadyADefaultLanguage())
            {
                throw new CustomExceptions.AlreadyADefaultLanguage();
            }
        }

        private static bool IsThereAlreadyADefaultLanguage()
        {
            return DAL_Language.GetDefaultLanguage() != null;
        }

        public static void ToggleOldDefaultLanguage()
        {
            SiteLanguage oldDefaultLanguage = GetDefaultLanguage();
            oldDefaultLanguage.IsDefault = false;
            Update(oldDefaultLanguage);
        }

        public static void Delete(SiteLanguage model)
        {
            model.DeletedAt = DateTime.Now;
            Update(model);
        }

        private static void Update(SiteLanguage model)
        {
            model.ModifiedAt = DateTime.Now;
            DAL_Language.Update(model);
        }

        private static void Create(SiteLanguage model)
        {
            DAL_Language.Create(model);
        }

        public static SiteLanguage GetDefaultLanguage()
        {
            return DAL_Language.GetDefaultLanguage();
        }

        public static List<SiteLanguage> GetAllLanguages()
        {
            return DAL_Language.GetAllLanguages();
        }

        public static string[] GetAllISOCodes()
        {
            return DAL_Language.GetAllISOCodes();
        }

        public static void MakeLanguageDefault(SiteLanguage language)
        {
            ToggleOldDefaultLanguage();

            language.IsActive = true;
            language.IsDefault = true;

            Update(language);
        }
    }
}
