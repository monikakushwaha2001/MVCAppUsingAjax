using MVCAppUsingAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppUsingAjax.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities dc = new NorthwindEntities();
        public ViewResult DisplayProducts()
        {
            return View(dc.Products);
        }
        [HttpPost]
        public ViewResult SearchProduct(string SearchTerm)
        {
            List<Product> Products = new List<Product>();
            if (SearchTerm.Trim().Length > 0)
            {
                Products = dc.Products.ToList();
            }
            else
            {
                //You can implement the Query in any of the below 2 years.
                Products = (from P in dc.Products where P.ProductName.Contains(SearchTerm) select P).ToList();

                Products=dc.Products.Where(P => P.ProductName.Contains(SearchTerm)).ToList();

            }
            return View("DisplayProducts", Products);
        }
        public JsonResult GetProducts(string term)
        {
            List<string> Products = dc.Products.Where(P => P.ProductName.StartsWith(term)).Select(P => P.ProductName).ToList();
            return Json(Products, JsonRequestBehavior.AllowGet);
        } 
    }
}