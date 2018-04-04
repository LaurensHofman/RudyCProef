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
        public static void Save(Language model)
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
            Language oldDefaultLanguage = GetDefaultLanguage();
            oldDefaultLanguage.IsDefault = false;
            Update(oldDefaultLanguage);
        }

        public static List<Language> GetDesktopLanguages()
        {
            return DAL_Language.GetDesktopLanguages();
        }

        public static Language GetLanguageByID(int preferredLanguageID)
        {
            return DAL_Language.GetLanguageByID(preferredLanguageID);
        }        

        public static void Delete(Language model)
        {
            model.DeletedAt = DateTime.Now;
            Update(model);
        }

        private static void Update(Language model)
        {
            model.ModifiedAt = DateTime.Now;
            DAL_Language.Update(model);
        }

        private static void Create(Language model)
        {
            DAL_Language.Create(model);
        }

        public static Language GetDefaultLanguage()
        {
            return DAL_Language.GetDefaultLanguage();
        }

        public static List<Language> GetAllLanguages()
        {
            return DAL_Language.GetAllLanguages();
        }

        public static string[] GetAllISOCodes()
        {
            return DAL_Language.GetAllISOCodes();
        }

        public static void MakeLanguageDefault(Language language)
        {
            ToggleOldDefaultLanguage();

            language.IsActive = true;
            language.IsDefault = true;

            Update(language);
        }
    }
}
