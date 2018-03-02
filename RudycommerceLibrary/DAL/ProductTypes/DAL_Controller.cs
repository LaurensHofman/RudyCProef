using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;

namespace RudycommerceLibrary.DAL.ProductTypes
{
    public static class DAL_Controller
    {
        public static void Create(GamingController controllerModel)
        {
            var ctx = AppDBContext.Instance();

            ctx.Controllers.Add(controllerModel);
            ctx.SaveChanges();
        }
    }
}
