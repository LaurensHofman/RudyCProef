using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities.Products.GamingEquipments.NonElectronicEquipments;

namespace RudycommerceLibrary.DAL.ProductTypes
{
    public static class DAL_MouseMat
    {
        public static void Create(MouseMat mouseMat)
        {
            var ctx = AppDBContext.Instance();

            ctx.MouseMats.Add(mouseMat);
            ctx.SaveChanges();
        }
    }
}
