using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppFirst.Models;
using PagedList.Mvc;
using PagedList;

namespace WebAppFirst.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                NorthwindOriginalEntities db = new NorthwindOriginalEntities();
                List<Products>products = db.Products.ToList();
                return View(products);
            }
        }
    }
}