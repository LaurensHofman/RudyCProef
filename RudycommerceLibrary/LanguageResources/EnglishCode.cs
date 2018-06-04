using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudycommerce.LanguageResources
{
    public static class EnglishCode
    {
        public const string YES = "Yes";
        public const string NO = "No";
        public const string NAME = "Name";
        public const string DESCRIPTION = "Description";
        public const string NO_PARENT = "No parent";
        public const string POTENTIAL_VALUES = "Potential values";

        public static string SAVE_FAILED_CONTENT = "Saving into the database has failed, please verify that all data was inserted correctly.";
        public static string SAVE_FAILED_TITLE = "Save failed";

        public static string UOVerifyAdminMessageBoxContent(string lastName, string firstName)
        {
            return $"Are you sure you want to give {lastName} {firstName} access to the application?";
        }

        public static string UOVerifyAdminMessageBoxTitle(string lastName, string firstName)
        {
            return $"Verify {lastName} {firstName}";
        }

        public static string UODeleteUserMessageBoxContent(string lastName, string firstName)
        {
            return $"Are you sure you want to remove {lastName} {firstName} as a user?";
        }

        public static string UODeleteUserMessageBoxTitle(string lastName, string firstName)
        {
            return $"Remove {lastName} {firstName}?";
        }

        public static string UOMakeUserAdminMessageBoxContent(string lastName, string firstName)
        {
            return $"Are you sure you want to make {lastName} {firstName} the new administrator of this application?" +
                $"\r\nIf you select YES, you will have to relog to gain access to the application.";
        }

        public static string UOMakeUserAdminMessageBoxTitle(string lastName, string firstName)
        {
            return $"New administrator: {lastName} {firstName}?";
        }

        public static string ExitMessageBoxContent()
        {
            return "Are you sure you want to close the application?";
        }

        public static string ExitMessageBoxTitle()
        {
            return "Close application";
        }
        
    }
}
