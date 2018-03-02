using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;
using RudycommerceLibrary.Entities.Products.LocalizedProducts;

namespace RudycommerceLibrary.DAL.ProductTypes
{
    public static class DAL_Headset
    {
        public static void Create(Headset headsetModel)
        {
            var ctx = AppDBContext.Instance();

            ctx.Headsets.Add(headsetModel);
            ctx.SaveChanges();
        }

        public static void LocalizedCreate(LocalizedHeadset localizedHeadsetModel)
        {
            var ctx = AppDBContext.Instance();

            ctx.LocalizedHeadsets.Add(localizedHeadsetModel);
            ctx.SaveChanges();
        }
    }
}
