using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudycommerce.LanguageResources
{
    public static class EnglishCode
    {
        public const string YES = "Yes";
        public const string NO = "No";

        public const string GAME = "Game";
        public const string GAMING_EQUIPMENT = "Gaming equipment";

        public const string KEYBOARD = "Keyboard";
        public const string CONTROLLER = "Controller";
        public const string MOUSEMAT = "Mousemat";
        public const string HEADSET = "Headset";
        public const string MOUSE = "Mouse";
        
        public static string[] ProductTypes { get; set; } = new string[]
            { GAMING_EQUIPMENT, GAME };

        public static string[] GamingEquipmentTypes { get; set; }
            = new string[] { CONTROLLER, HEADSET, KEYBOARD, MOUSE, MOUSEMAT };

        public static string UOVerifyAdminMessageBoxContent(string lastName, string firstName)
        {
            return $"Are you sure you want to give {lastName} {firstName} access to the application?";
        }

        public static string UOVerifyAdminMessageBoxTitle(string lastName, string firstName)
        {
            return $"Verify {lastName} {firstName}";
        }

        public static string UODeleteUserMessageBoxContent(string lastName, string firstName)
        {
            return $"Are you sure you want to remove {lastName} {firstName} as a user?";
        }

        public static string UODeleteUserMessageBoxTitle(string lastName, string firstName)
        {
            return $"Remove {lastName} {firstName}?";
        }

        public static string UOMakeUserAdminMessageBoxContent(string lastName, string firstName)
        {
            return $"Are you sure you want to make {lastName} {firstName} the new administrator of this application?" +
                $"\r\nIf you select YES, you will have to relog to gain access to the application.";
        }

        public static string UOMakeUserAdminMessageBoxTitle(string lastName, string firstName)
        {
            return $"New administrator: {lastName} {firstName}?";
        }
    }
}
