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

        public static string[] ProductTypes(string preferredLanguage)
        {
            switch (preferredLanguage)
            {
                case "Nederlands":
                    return DutchCode.ProductTypes;

                case "English":
                    return EnglishCode.ProductTypes;

                default:
                    return DutchCode.ProductTypes;
            }
        }

        public static string[] HeadsetWearingWays(string preferredLanguage)
        {
            switch (preferredLanguage)
            {
                case "Nederlands":
                    return DutchCode.HeadsetWearingWays;

                case "English":
                    return EnglishCode.HeadsetWearingWays;

                default:
                    return DutchCode.HeadsetWearingWays;
            }
        }

        public static string UOVerifyAdminMessageBoxContent(string lastName, string firstName, string preferredLanguage)
        {
            switch (preferredLanguage)
            {
                case "Nederlands":
                    return DutchCode.UOVerifyAdminMessageBoxContent(lastName, firstName);

                case "English":
                    return EnglishCode.UOVerifyAdminMessageBoxContent(lastName, firstName);

                default:
                    return DutchCode.UOVerifyAdminMessageBoxContent(lastName, firstName);
            }
        }

        public static string[] SpecificTypesGamingEquipment(string preferredLanguage)
        {
            switch (preferredLanguage)
            {
                case "Nederlands":
                    return DutchCode.GamingEquipmentTypes;

                case "English":
                    return EnglishCode.GamingEquipmentTypes;

                default:
                    return DutchCode.GamingEquipmentTypes;
            }
        }
        
        public static string UOVerifyAdminMessageBoxTitle(string lastName, string firstName, string preferredLanguage)
        {
            switch (preferredLanguage)
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

        public static string Yes(string preferredLanguage)
        {
            switch (preferredLanguage)
            {
                case "Nederlands":
                    return DutchCode.YES;

                case "English":
                    return EnglishCode.YES;

                default:
                    return DutchCode.YES;
            }
        }

        public static string No(string preferredLanguage)
        {
            switch (preferredLanguage)
            {
                case "Nederlands":
                    return DutchCode.NO;

                case "English":
                    return EnglishCode.NO;

                default:
                    return DutchCode.NO;
            }
        }

        public static string UODeleteUserMessageBoxContent(string lastName, string firstName, string preferredLanguage)
        {
            switch (preferredLanguage)
            {
                case "Nederlands":
                    return DutchCode.UODeleteUserMessageBoxContent(lastName, firstName);

                case "English":
                    return EnglishCode.UODeleteUserMessageBoxContent(lastName, firstName);

                default:
                    return DutchCode.UODeleteUserMessageBoxContent(lastName, firstName);
            }
        }

        public static string UODeleteUserMessageBoxTitle(string lastName, string firstName, string preferredLanguage)
        {
            switch (preferredLanguage)
            {
                case "Nederlands":
                    return DutchCode.UODeleteUserMessageBoxTitle(lastName, firstName);

                case "English":
                    return EnglishCode.UODeleteUserMessageBoxTitle(lastName, firstName);

                default:
                    return DutchCode.UODeleteUserMessageBoxTitle(lastName, firstName);
            }
        }

        public static string UOMakeUserAdminMessageBoxContent(string lastName, string firstName, string preferredLanguage)
        {
            switch (preferredLanguage)
            {
                case "Nederlands":
                    return DutchCode.UOMakeUserAdminMessageBoxContent(lastName, firstName);

                case "English":
                    return EnglishCode.UOMakeUserAdminMessageBoxContent(lastName, firstName);

                default:
                    return DutchCode.UOMakeUserAdminMessageBoxContent(lastName, firstName);
            }
        }

        public static string UOMakeUserAdminMessageBoxTitle(string lastName, string firstName, string preferredLanguage)
        {
            switch (preferredLanguage)
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
