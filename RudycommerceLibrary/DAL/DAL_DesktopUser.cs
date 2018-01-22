using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_DesktopUser
    {
        public static bool AnyDesktopUser()
        {
            var ctx = AppDBContext.Instance();

            return ctx.DesktopUsers.Any(du => du.DeletedAt == null);
        }

        public static void Create(DesktopUser newDesktopUser)
        {
            var ctx = AppDBContext.Instance();

            ctx.DesktopUsers.Add(newDesktopUser);
            ctx.SaveChanges();
        }

        public static DesktopUser GetAdminUser()
        {
            var ctx = AppDBContext.Instance();

            return ctx.DesktopUsers.SingleOrDefault(du => du.IsAdmin == true);
        }

        public static DesktopUser FindUser(string username)
        {
            var ctx = AppDBContext.Instance();

            return ctx.DesktopUsers.SingleOrDefault(du => du.Username.ToLower() == username.ToLower() && du.VerifiedByAdmin == true && du.DeletedAt == null);
        }

        public static int GetUserID(string username)
        {
            var ctx = AppDBContext.Instance();

            return ctx.DesktopUsers.SingleOrDefault(du => du.Username.ToLower() == username.ToLower() && du.DeletedAt == null).UserID;
        }

        public static string GetUserPreferredLanguage(int currentUserID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.DesktopUsers.SingleOrDefault(du => du.UserID == currentUserID && du.DeletedAt == null).PreferredLanguage;
        }

        public static List<DesktopUser> GetAll()
        {
            var ctx = AppDBContext.Instance();

            return ctx.DesktopUsers.Where(du => du.DeletedAt == null)
                    .OrderByDescending(du => du.IsAdmin)
                    .ThenByDescending(du => du.VerifiedByAdmin)
                    .ThenBy(du => du.LastName)
                    .ToList();
        }

        public static void Delete(DesktopUser du)
        {
            var ctx = AppDBContext.Instance();


        }

        public static DesktopUser GetCurrentUserByID(int currentUserID)
        {
            var ctx = AppDBContext.Instance();

            return ctx.DesktopUsers.SingleOrDefault(du => du.UserID == currentUserID && du.DeletedAt == null);
        }

        public static void Update(DesktopUser currentUser)
        {
            var ctx = AppDBContext.Instance();

            ctx.Entry(currentUser).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
