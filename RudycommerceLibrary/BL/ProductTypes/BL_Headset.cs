using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.DAL.ProductTypes;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;

namespace RudycommerceLibrary.BL.ProductTypes
{
    public static class BL_Headset
    {
        public static void Save(Headset headsetModel)
        {
            if (headsetModel.IsNew())
            {
                Create(headsetModel);
            }
        }

        private static void Create(Headset headsetModel)
        {
            DAL_Headset.Create(headsetModel);
        }
    }
}
