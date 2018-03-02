using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.DAL.ProductTypes;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;
using RudycommerceLibrary.Entities.Products.LocalizedProducts;

namespace RudycommerceLibrary.BL.ProductTypes
{
    public static class BL_Headset
    {
        public static void Save(Headset headsetModel, int productID)
        {
            if (headsetModel.IsNew())
            {
                headsetModel.ProductID = productID;
                Create(headsetModel);
            }
        }

        private static void Create(Headset headsetModel)
        {
            DAL_Headset.Create(headsetModel);
        }

        public static void LocalizedSave(LocalizedHeadset localizedHeadsetModel, int productID)
        {
            if (localizedHeadsetModel.IsNew())
            {
                localizedHeadsetModel.ProductID = productID;
                LocalizedCreate(localizedHeadsetModel);
            }
        }

        private static void LocalizedCreate(LocalizedHeadset localizedHeadsetModel)
        {
            DAL_Headset.LocalizedCreate(localizedHeadsetModel);
        }

        public static string[] GetWearingWays(string preferredLanguage)
        {
            string[] wearingWays;

            wearingWays = BL_Multilingual.HeadsetWearingWays(preferredLanguage);

            return wearingWays;
        }
    }
}
