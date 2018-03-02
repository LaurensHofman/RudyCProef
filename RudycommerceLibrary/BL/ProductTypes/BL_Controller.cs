using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.DAL.ProductTypes;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;

namespace RudycommerceLibrary.BL.ProductTypes
{
    public static class BL_Controller
    {
        public static void Save(GamingController controllerModel, int productID)
        {
            if (controllerModel.IsNew())
            {
                controllerModel.ProductID = productID;
                Create(controllerModel);
            }
        }

        private static void Create(GamingController controllerModel)
        {
            DAL_Controller.Create(controllerModel);
        }
    }
}
