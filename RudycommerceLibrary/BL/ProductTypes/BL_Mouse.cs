using RudycommerceLibrary.DAL.ProductTypes;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL.ProductTypes
{
    public static class BL_Mouse
    {
        public static void Save(GamingMouse mouse, int productID)
        {
            if (mouse.IsNew())
            {
                mouse.ProductID = productID;
                Create(mouse);
            }
        }

        private static void Create(GamingMouse mouse)
        {
            DAL_Mouse.Create(mouse);
        }
    }
}
