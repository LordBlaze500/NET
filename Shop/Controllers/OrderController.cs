using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private Context _db;

        public OrderController()
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
            var orders = this._db.Orders;
            return View(orders);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Order model)
        {
            if (ModelState.IsValid)
            {
                model.OrderedDate = DateTime.Now;
                this._db.Orders.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano zmówienie.";
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
            Order movie = _db.Orders.Find(id);
            _db.Orders.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

    }
}
