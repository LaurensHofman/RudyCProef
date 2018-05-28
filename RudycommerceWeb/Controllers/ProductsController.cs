using RudycommerceLibrary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RudycommerceLibrary.BL;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Models;

namespace RudycommerceWeb.Controllers
{
    public class ProductsController : Controller
    {
        int englishID = 1;

        // GET: Products
        public ActionResult Index()
        {
            HomePageProductViewItem[] products = BL_Product.GetHomePageProducts();

            return View(products);
        }

        [HttpGet]
        public ActionResult Details(int ProductID)
        {
            ProductDetails productDetails = BL_Product.GetProductDetails(ProductID, englishID);

            ViewBag.LangID = englishID;

            return View(productDetails);
        }
    }
}