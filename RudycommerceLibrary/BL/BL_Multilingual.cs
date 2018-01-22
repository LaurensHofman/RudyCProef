using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL
{
    public static class BL_Multilingual
    {
        public static string ChooseLanguageDictionary(string selectedLanguage)
        {
            switch (selectedLanguage)
            {
                case "Nederlands":
                    return "..\\LanguageResources\\Dutch.xaml";
                    
                case "English":
                    return "..\\LanguageResources\\English.xaml";

                default:
                    return "..\\LanguageResources\\Dutch.xaml";
            }
        }
    }
}
