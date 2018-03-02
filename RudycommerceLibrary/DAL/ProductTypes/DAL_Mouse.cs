using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;

namespace RudycommerceLibrary.DAL.ProductTypes
{
    public static class DAL_Mouse
    {
        public static void Create(GamingMouse mouse)
        {
            var ctx = AppDBContext.Instance();

            ctx.Mice.Add(mouse);
            ctx.SaveChanges();
        }
    }
}
