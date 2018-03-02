using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.DAL.ProductTypes;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;

namespace RudycommerceLibrary.BL.ProductTypes
{
    public static class BL_Keyboard
    {
        public static void Save(GamingKeyboard keyboardModel)
        {
            if (keyboardModel.IsNew())
            {
                Create(keyboardModel);
            }
        }

        private static void Create(GamingKeyboard keyboardModel)
        {
            DAL_Keyboard.Create(keyboardModel);
        }
    }
}
