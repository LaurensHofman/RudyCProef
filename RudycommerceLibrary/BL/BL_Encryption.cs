using RudycommerceLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL
{
    public static class BL_Encryption
    {
        public static string GenerateSalt()
        {
            string _salt = SecurityExtensions.GenerateSalt();

            return _salt;
        }

        public static string EncryptPassword(string salt, string password)
        {
            string _encryptedPassword = SecurityExtensions.Encrypt(salt, password);

            return _encryptedPassword;
        }
    }
}
