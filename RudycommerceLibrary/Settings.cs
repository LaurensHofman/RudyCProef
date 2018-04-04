using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary
{
    public static class Settings
    {
        public static Entities.Language UserLanguage { get; set; }

        public static Entities.DesktopUser CurrentUser { get; set; }

        public static void SetDesktopUser(int currentUserID)
        {
            CurrentUser = BL.BL_DesktopUser.GetCurrentUserByID(currentUserID);
        }
    }
}
