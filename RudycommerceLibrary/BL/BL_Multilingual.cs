using Rudycommerce.LanguageResources;
using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
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

        public static string NO_PARENT(Language userLanguage)
        {
            switch (userLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.NO_PARENT;

                case "English":
                    return EnglishCode.NO_PARENT;

                default:
                    return DutchCode.NO_PARENT;
            }
        }

        public static string ExitMessageBoxContent(Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.ExitMessageBoxContent();

                case "English":
                    return EnglishCode.ExitMessageBoxContent();

                default:
                    return DutchCode.ExitMessageBoxContent();
            }
        }

        public static string POTENTIAL_VALUES(Language userLanguage)
        {
            switch (userLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.POTENTIAL_VALUES;

                case "English":
                    return EnglishCode.POTENTIAL_VALUES;

                default:
                    return DutchCode.POTENTIAL_VALUES;
            }
        }

        public static string ExitMessageBoxTitle(Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.ExitMessageBoxTitle();

                case "English":
                    return EnglishCode.ExitMessageBoxTitle();

                default:
                    return DutchCode.ExitMessageBoxTitle();
            }
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

        public static string YES(Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.YES;

                case "English":
                    return EnglishCode.YES;

                default:
                    return DutchCode.YES;
            }
        }

        public static string NAME(Language userLanguage)
        {
            switch (userLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.NAME;

                case "English":
                    return EnglishCode.NAME;

                default:
                    return DutchCode.NAME;
            }
        }

        public static string DESCRIPTION(Language userLanguage)
        {
            switch (userLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.DESCRIPTION;

                case "English":
                    return EnglishCode.DESCRIPTION;

                default:
                    return DutchCode.DESCRIPTION;
            }
        }

        public static string NO(Language preferredLanguage)
        {
            switch (preferredLanguage.LocalName)
            {
                case "Nederlands":
                    return DutchCode.NO;

                case "English":
                    return EnglishCode.NO;

                default:
                    return DutchCode.NO;
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
