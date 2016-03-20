using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class KategoriaController : Controller
    {
        private Context _db;

        public KategoriaController()
        {
            this._db = new Context();
        }
        //
        // GET: /Kategoria/

        public ActionResult Index()
        {
            ViewBag.Message = "Witaj w serwisie MobielPost";
            return View();
        }

        public ActionResult List()
        {
            var kategoria = this._db.Kategorie;
            return View(kategoria);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Kategoria model)
        {
            if (ModelState.IsValid)
            {
                this._db.Kategorie.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Zgłoszenie zostało przyjęte.";
                return RedirectToAction("list");
            }
            else
            {
                return View(model);
            }
        }

    }
}
