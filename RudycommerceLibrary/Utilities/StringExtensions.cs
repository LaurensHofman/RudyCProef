using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Utilities
{
    public static class StringExtensions
    {
        public static bool IsEmailAddress(string eMail)
        {
            try
            {
                MailAddress m = new MailAddress(eMail);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
