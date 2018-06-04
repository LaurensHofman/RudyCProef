using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudycommerce
{
    public static class UserSettings
    {
        public static RudycommerceLibrary.Entities.Language UserLanguage { get; set; }

        public static RudycommerceLibrary.Entities.DesktopUser CurrentUser { get; set; }

        public static void SetDesktopUser(int currentUserID)
        {
            CurrentUser = RudycommerceLibrary.BL.BL_DesktopUser.GetCurrentUserByID(currentUserID);
        }
    }

}
