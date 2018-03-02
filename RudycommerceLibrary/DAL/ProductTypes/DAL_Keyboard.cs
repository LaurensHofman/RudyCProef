using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;

namespace RudycommerceLibrary.DAL.ProductTypes
{
    public static class DAL_Keyboard
    {
        public static void Create(GamingKeyboard keyboardModel)
        {
            var ctx = AppDBContext.Instance();

            ctx.Keyboards.Add(keyboardModel);
            ctx.SaveChanges();
        }
    }
}
