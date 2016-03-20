using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class PromotionController : Controller
    {
        private Context _db;

        public PromotionController()
        {
            this._db = new Context();
        }

        //
        // GET: /Promotion/

        public ActionResult Index()
        {
            ViewBag.Message = "Witaj w naszym sklepie";
            return View();
        }

        public ActionResult List()
        {
            var Promotions = this._db.Promotions;
            return View(Promotions);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Promotion model)
        {
            if (ModelState.IsValid)
            {
                //model.PromotionedDate = DateTime.Now;
                this._db.Promotions.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano zmówienie.";
                return RedirectToAction("list");
            }
            else
            {
                return View(model);
            }
        }

    }
}
