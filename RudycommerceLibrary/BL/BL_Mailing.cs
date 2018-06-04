using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL
{
    public static class BL_Mailing
    {
        public static void SendMailToAdmin(string firstname, string lastname, string email, string username)
        {
            DesktopUser Admin = BL_DesktopUser.GetAdminUser();
            string subject;
            StringBuilder message;

            switch (Admin.PreferredLanguage.LocalName)
            {
                case "Nederlands":
                    subject = $"{firstname} {lastname} heeft een account aangemaakt";
                    message = new StringBuilder();
                    message.AppendLine($"Beste {Admin.FirstName} {Admin.LastName},");
                    message.AppendLine("");
                    message.AppendLine($"{firstname} {lastname} (gebruikersnaam: {username} ; e-mail: {email} ) heeft een account aangemaakt om toegang te krijgen tot de applicatie.");
                    message.AppendLine($"Als u {firstname} {lastname} toegang wil given tot de applicatie.");
                    message.AppendLine($"Dit doet u door in te loggen in de applicatie en onder Beheer Gebruikers de nieuwe gebruiker toegang te verlenen");
                    message.AppendLine("");
                    message.AppendLine("Met vriendelijke groeten,");
                    message.AppendLine("RudyCommerce");

                    break;

                case "English":
                    subject = $"{firstname} {lastname} has made an account";
                    message = new StringBuilder();
                    message.AppendLine($"Dear {Admin.FirstName} {Admin.LastName},");
                    message.AppendLine("");
                    message.AppendLine($"{firstname} {lastname} (username: {username} ; e-mail: {email} ) has made an account to gain access to the program.");
                    message.AppendLine($"If you want to give {firstname} {lastname} access to the application, log in as administrator and give him the rights in the Manage User section");
                    message.AppendLine("");
                    message.AppendLine("Kind regard,");
                    message.AppendLine("RudyCommerce");

                    break;

                default:
                    subject = $"{firstname} {lastname} heeft een account aangemaakt";
                    message = new StringBuilder();
                    message.AppendLine($"Beste {Admin.FirstName} {Admin.LastName},");
                    message.AppendLine("");
                    message.AppendLine($"{firstname} {lastname} (gebruikersnaam: {username} ; e-mail: {email} ) heeft een account aangemaakt om toegang te krijgen tot de applicatie.");
                    message.AppendLine($"Als u {firstname} {lastname} toegang wil given tot de applicatie.");
                    message.AppendLine($"Dit doet u door in te loggen in de applicatie en onder Beheer Gebruikers de nieuwe gebruiker toegang te verlenen");
                    message.AppendLine("");
                    message.AppendLine("Met vriendelijke groeten,");
                    message.AppendLine("RudyCommerce");

                    break;
            }
            
            var fromAddress = new MailAddress("infoecommrudy@gmail.com", "Rudycommerce");
            var toAddress = new MailAddress(Admin.EMail, Admin.FirstName + " " + Admin.LastName);
            const string fromPassword = "infoecomm";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };
            using (var newMail = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = message.ToString()
            })
            {
                smtp.Send(newMail);
            }
        }

        public static void UserVerified(string lastname, string firstname, string email, string username, Language language)
        {
            string subject;
            StringBuilder message;

            switch (language.LocalName)
            {
                case "Nederlands":
                    subject = $"Uw account bij Rudycommerce is geverifieerd";
                    message = new StringBuilder();
                    message.AppendLine($"Beste {firstname} {lastname},");
                    message.AppendLine("");
                    message.AppendLine($"Uw account (met gebruikersnaam {username}) is geverifieerd door uw administrator.");
                    message.AppendLine($"Vanaf nu kan u zonder problemen inloggen en aan uw werk beginnen.");
                    message.AppendLine("");
                    message.AppendLine("Met vriendelijke groeten,");
                    message.AppendLine("RudyCommerce");

                    break;

                case "English":
                    subject = $"Account with Rudycommerce has been verified";
                    message = new StringBuilder();
                    message.AppendLine($"Dear {firstname} {lastname},");
                    message.AppendLine("");
                    message.AppendLine($"Your account (with username {username}) has been verified by your administrator.");
                    message.AppendLine($"Starting now, you can log in to execute your professional tasks.");
                    message.AppendLine("");
                    message.AppendLine("Kind regard,");
                    message.AppendLine("RudyCommerce");

                    break;
                default:
                    subject = $"Uw account bij Rudycommerce is geverifieerd";
                    message = new StringBuilder();
                    message.AppendLine($"Beste {firstname} {lastname},");
                    message.AppendLine("");
                    message.AppendLine($"Uw account (met gebruikersnaam {username}) is geverifieerd door uw administrator.");
                    message.AppendLine($"Vanaf nu kan u zonder problemen inloggen en aan uw werk beginnen.");
                    message.AppendLine("");
                    message.AppendLine("Met vriendelijke groeten,");
                    message.AppendLine("RudyCommerce");

                    break;
            }

            var fromAddress = new MailAddress("infoecommrudy@gmail.com", "Rudycommerce");
            var toAddress = new MailAddress(email, firstname + " " + lastname);
            const string fromPassword = "infoecomm";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };
            using (var newMail = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = message.ToString()
            })
            {
                smtp.Send(newMail);
            }
        }

        public static void SendMailToUser(string firstname, string lastname, string email, string username, Language language)
        {
            
                string subject;
                StringBuilder message;

                switch (language.LocalName)
                {
                    case "Nederlands":
                        subject = $"Account aangemaakt bij Rudycommerce";
                        message = new StringBuilder();
                        message.AppendLine($"Beste {firstname} {lastname},");
                        message.AppendLine("");
                        message.AppendLine($"Uw account (met gebruikersnaam {username}) is aangemaakt, maar nu moet u afwachten tot de beheerder van de applicatie u de toegangsrechten zal toekennen.");
                        message.AppendLine($"Gelieve de applicatiebeheerde te contacteren indien u te lang moet wachten.");
                        message.AppendLine("");
                        message.AppendLine("Met vriendelijke groeten,");
                        message.AppendLine("RudyCommerce");

                        break;

                    case "English":
                        subject = $"Account made with Rudycommerce";
                        message = new StringBuilder();
                        message.AppendLine($"Dear {firstname} {lastname},");
                        message.AppendLine("");
                        message.AppendLine($"Your account (with username {username}) has been created, but now your administrator has to give you the rights to the application.");
                        message.AppendLine($"Please contact your administrator in case it takes too long.");
                        message.AppendLine("");
                        message.AppendLine("Kind regard,");
                        message.AppendLine("RudyCommerce");

                        break;
                    default:
                        subject = $"Account aangemaakt bij Rudycommerce";
                        message = new StringBuilder();
                        message.AppendLine($"Beste {firstname} {lastname},");
                        message.AppendLine("");
                        message.AppendLine($"Uw account (met gebruikersnaam {username}) is aangemaakt, maar nu moet u afwachten tot de beheerder van de applicatie u de toegangsrechten zal toekennen.");
                        message.AppendLine($"Gelieve de applicatiebeheerde te contacteren indien u te lang moet wachten.");
                        message.AppendLine("");
                        message.AppendLine("Met vriendelijke groeten,");
                        message.AppendLine("RudyCommerce");

                        break;
                }

                var fromAddress = new MailAddress("infoecommrudy@gmail.com", "Rudycommerce");
                var toAddress = new MailAddress(email, firstname + " " + lastname);
                const string fromPassword = "infoecomm";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };
                using (var newMail = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = message.ToString()
                })
                {
                    smtp.Send(newMail);
                }
            
            
        }

    }
}
