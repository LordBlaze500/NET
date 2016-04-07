using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private Context _db;

        public ProductsController()
        {
            this._db = new Context();
        }

        //
        // GET: /Order/

        public ActionResult Index()
        {
            ViewBag.Message = "Witaj w naszym sklepie";
            return View();
        }

        public ActionResult List()
        {
            var products = this._db.Products;
            return View(products);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Products model)
        {
            if (ModelState.IsValid)
            {
                //model.AddDate = DateTime.Now;
                this._db.Products.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano produkt.";
                return RedirectToAction("list");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Products movie = _db.Products.Find(id);
            _db.Products.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

    }
}
