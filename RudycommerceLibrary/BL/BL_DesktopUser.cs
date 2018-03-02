using RudycommerceLibrary.DAL;
using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL
{
    public static class BL_DesktopUser
    {
        public static bool AnyDesktopUser()
        {
            try
            {
                return DAL_DesktopUser.AnyDesktopUser();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DesktopUser GetAdminUser()
        {
            return DAL_DesktopUser.GetAdminUser();
        }

        public static void Create(DesktopUser newDesktopUser)
        {
            try
            {
                DAL_DesktopUser.Create(newDesktopUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Authenticate(string username, string password)
        {
            DesktopUser user = FindUser(username);

            if (user == null)
            {
                return false;
            }

            var encryptedPassword = BL_Encryption.EncryptPassword(user.Salt, password);

            if (user.EncryptedPassword == encryptedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUserAdmin(int currentUserID)
        {
            return DAL_DesktopUser.IsUserAdmin(currentUserID);
        }

        public static List<DesktopUser> GetAll()
        {
            return DAL_DesktopUser.GetAll();
        }

        public static DesktopUser GetCurrentUserByID(int currentUserID)
        {
            return DAL_DesktopUser.GetCurrentUserByID(currentUserID);
        }

        public static string UserPreferredLanguage(int currentUserID)
        {
            return DAL_DesktopUser.GetUserPreferredLanguage(currentUserID);
        }

        public static void Delete(DesktopUser du)
        {
            du.DeletedAt = DateTime.Now;
            Update(du);
        }

        // finds the user id to remember which user is currently logged in
        public static int GetUserID(string username)
        {
            return DAL_DesktopUser.GetUserID(username);
        }

        // finds the user for the authenticarion
        private static DesktopUser FindUser(string username)
        {
            return DAL_DesktopUser.FindUser(username);
        }

        public static void Update(DesktopUser currentUser)
        {
            currentUser.ModifiedAt = DateTime.Now;
            DAL_DesktopUser.Update(currentUser);
        }

        public static void AdminLoseHisRights()
        {
            DesktopUser oldAdmin = DAL_DesktopUser.GetAdminUser();
            oldAdmin.IsAdmin = false;
            Update(oldAdmin);            
        }

        public static void VerifyByAdmin(DesktopUser user)
        {
            user.VerifiedByAdmin = true;
            Update(user);
        }
    }
}
