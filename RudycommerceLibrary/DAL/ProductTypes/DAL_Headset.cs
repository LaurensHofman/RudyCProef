using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;

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
    }
}
