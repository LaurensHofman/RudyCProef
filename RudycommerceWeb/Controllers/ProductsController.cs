using RudycommerceLibrary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RudycommerceLibrary.BL;

namespace RudycommerceWeb.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            HomePageProductViewItem[] products = BL_Product.GetHomePageProducts();

            return View(products);
        }
    }
}