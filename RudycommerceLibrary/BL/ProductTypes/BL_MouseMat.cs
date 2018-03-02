using RudycommerceLibrary.DAL.ProductTypes;
using RudycommerceLibrary.Entities.Products.GamingEquipments.NonElectronicEquipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary.BL.ProductTypes
{
    public static class BL_MouseMat
    {
        public static void Save(MouseMat mouseMat, int productID)
        {
            if (mouseMat.IsNew())
            {
                mouseMat.ProductID = productID;
                Create(mouseMat);
            }
        }

        private static void Create(MouseMat mouseMat)
        {
            DAL_MouseMat.Create(mouseMat);
        }
    }
}
