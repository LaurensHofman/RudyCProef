﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.Products;

namespace RudycommerceLibrary.DAL
{
    public static class DAL_Product
    {
        public static void Create(Product product)
        {
            var ctx = AppDBContext.Instance();

            ctx.Products.Add(product);
            ctx.SaveChanges();
        }
    }
}
