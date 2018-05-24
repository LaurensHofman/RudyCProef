using Rudycommerce.LanguageResources;
using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL
{

    //switch (preferredLanguage)
    //        {
    //            case "Nederlands":
    //                return DutchCode.;

    //            case "English":
    //                return EnglishCode.;

    //            default:
    //                return DutchCode.;
    //        }

public static class BL_Multilingual
    {
        public static string ChooseLanguageDictionary(Language selectedLanguage)
        {
            switch (selectedLanguage.LocalName)
            {
                case "Nederlands":
                    return "..\\LanguageResources\\Dutch.xaml";
                    
                case "English":
                    return "..\\LanguageResources\\English.xaml";

                default:
                    return "..\\LanguageResources\\Dutch.xaml";
            }
        }
        
        public static List<Models.LocalizedLanguageItem> GetLocalizedListOfLanguages(Language selectedLanguage)
        {
            List<Language> languages = BL_Language.GetAllLanguages();

            List<Models.LocalizedLanguageItem> returnListLanguages = new List<Models.LocalizedLanguageItem>();

            switch (selectedLanguage.LocalName)
            {
                case "Nederlands":

                    languages = languages.OrderByDescending(l => l.IsDefault)
                        .ThenByDescending(l => l.IsDesktopLanguage)
                        .ThenBy(l => l.DutchName)
                        .ToList();

                    foreach (Language language in languages)
                    {
                        returnListLanguages.Add(new Models.LocalizedLanguageItem { ID = language.LanguageID, Name = language.DutchName });
                    }
                    break;

                case "English":

                    languages = languages.OrderByDescending(l => l.IsDefault)
                        .ThenByDescending(l => l.IsDesktopLanguage)
                        .ThenBy(l => l.EnglishName)
                        .ToList();

                    foreach (Language language in languages)
                    {
                        returnListLanguages.Add(new Models.LocalizedLanguageItem { ID = language.LanguageID, Name = language.EnglishName });
                    }
                    break;

                default:

                    languages = languages.OrderByDescending(l => l.IsDefault)
                        .ThenByDescending(l => l.IsDesktopLanguage)
                        .ThenBy(l => l.DutchName)
                        .ToList();

                    foreach (Language language in languages)
                    {
                        returnListLanguages.Add(new Models.LocalizedLanguageItem { ID = language.LanguageID, Name = language.DutchName });
                    }
                    break;
            }

            return returnListLanguages;
        }

        public static CultureInfo GetCulture(Language selectedLanguage)
        {
            switch (selectedLanguage.LocalName)
            {
                case "Nederlands":
                    return CultureInfo.CreateSpecificCulture("nl");

                case "English":
                    return CultureInfo.CreateSpecificCulture("en");

                default:
                    return CultureInfo.CreateSpecificCulture("nl");                    
            };
        }

        public static string UOVerifyAdminMessageBoxContent(string lastName, string firstName, Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.UOVerifyAdminMessageBoxContent(lastName, firstName);

                case "English":
                    return EnglishCode.UOVerifyAdminMessageBoxContent(lastName, firstName);

                default:
                    return DutchCode.UOVerifyAdminMessageBoxContent(lastName, firstName);
            }
        }
        
        public static string UOVerifyAdminMessageBoxTitle(string lastName, string firstName, Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.UOVerifyAdminMessageBoxTitle(lastName, firstName);

                case "English":
                    return EnglishCode.UOVerifyAdminMessageBoxTitle(lastName, firstName);

                default:
                    return DutchCode.UOVerifyAdminMessageBoxTitle(lastName, firstName);
            }
        }

        public static string GetTranslatedDefaultLanguage(Language preferredLanguage)
        {
            Language defaultLanguage = BL_Language.GetDefaultLanguage();

            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return defaultLanguage.DutchName;

                case "English":
                    return defaultLanguage.EnglishName;

                default:
                    return defaultLanguage.DutchName;
            }
        }
        public static string UODeleteUserMessageBoxContent(string lastName, string firstName, Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.UODeleteUserMessageBoxContent(lastName, firstName);

                case "English":
                    return EnglishCode.UODeleteUserMessageBoxContent(lastName, firstName);

                default:
                    return DutchCode.UODeleteUserMessageBoxContent(lastName, firstName);
            }
        }

        public static string UODeleteUserMessageBoxTitle(string lastName, string firstName, Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.UODeleteUserMessageBoxTitle(lastName, firstName);

                case "English":
                    return EnglishCode.UODeleteUserMessageBoxTitle(lastName, firstName);

                default:
                    return DutchCode.UODeleteUserMessageBoxTitle(lastName, firstName);
            }
        }

        public static string UOMakeUserAdminMessageBoxContent(string lastName, string firstName, Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.UOMakeUserAdminMessageBoxContent(lastName, firstName);

                case "English":
                    return EnglishCode.UOMakeUserAdminMessageBoxContent(lastName, firstName);

                default:
                    return DutchCode.UOMakeUserAdminMessageBoxContent(lastName, firstName);
            }
        }

        public static string UOMakeUserAdminMessageBoxTitle(string lastName, string firstName, Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.UOMakeUserAdminMessageBoxTitle(lastName, firstName);

                case "English":
                    return EnglishCode.UOMakeUserAdminMessageBoxTitle(lastName, firstName);

                default:
                    return DutchCode.UOMakeUserAdminMessageBoxTitle(lastName, firstName);
            }
        }
    }
}
