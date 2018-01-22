using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.Utilities
{
    public static class SecurityExtensions
    {
        private static int saltLengthLimit = 32;

        public static string GenerateSalt()
        {
            return GenerateSalt(saltLengthLimit);
        }

        public static string GenerateSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return Encoding.ASCII.GetString(salt);
        }

        public static string Encrypt(string salt, string password)
        {
            string saltpwd = password + salt;

            var sha = new SHA256CryptoServiceProvider();
            return Encoding.ASCII.GetString(sha.ComputeHash(Encoding.ASCII.GetBytes(saltpwd)));
        }
    }
}
