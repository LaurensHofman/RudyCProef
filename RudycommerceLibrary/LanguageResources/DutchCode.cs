using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudycommerce.LanguageResources
{
    public static class DutchCode
    {
        public const string YES = "Ja";
        public const string NO = "Nee";
        public const string NAME = "Naam";
        public const string DESCRIPTION = "Beschrijving";

        public static string UOVerifyAdminMessageBoxContent(string lastName, string firstName)
        {
            return $"Bent u zeker dat u {lastName} {firstName} toegang wil geven tot deze applicatie?";
        }

        public static string UOVerifyAdminMessageBoxTitle(string lastName, string firstName)
        {
            return $"Verifieer {lastName} {firstName}";
        }

        public static string UODeleteUserMessageBoxContent(string lastName, string firstName)
        {
            return $"Bent u zeker dat u {lastName} {firstName} wil verwijderen als gebruiker?";
        }

        public static string UODeleteUserMessageBoxTitle(string lastName, string firstName)
        {
            return $"Verwijder {lastName} {firstName}?";
        }

        public static string UOMakeUserAdminMessageBoxContent(string lastName, string firstName)
        {
            return $"Bent u zeker dat u {lastName} {firstName} de nieuwe beheerder wil maken van deze applicatie?" +
                $"\r\nAls u JA selecteert, zult u terug moeten aanmelden om toegang te krijgen tot de applicatie.";
        }

        public static string UOMakeUserAdminMessageBoxTitle(string lastName, string firstName)
        {
            return $"Nieuwe beheerder: {lastName} {firstName}?";
        }

        public static string ExitMessageBoxContent()
        {
            return "Bent u zeker dat u de applicatie wil sluiten?";
        }

        public static string ExitMessageBoxTitle()
        {
            return "Applicatie sluiten";
        }
    }
}
