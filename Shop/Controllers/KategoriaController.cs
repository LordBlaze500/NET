using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class KategoriaController: Controller
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
            ViewBag.Message = "Kategoria";
            return View();
        }

        public ActionResult List()
        {
            var Kategoriay = this._db.Kategorie;
            return View(Kategoriay);
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
                //model.KategoriaedDate = DateTime.Now;
                this._db.Kategorie.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano Kategorię";
                return RedirectToAction("list");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Kategoria Kategoria = _db.Kategorie.Find(id);
            return View(Kategoria);
        }

       [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(int id)
        {
            Kategoria kategoria = _db.Kategoria.Find(id);
            if (TryUpdateModel(kategoria, "",
                new string[] { "Name", "Description"}))
            {
                this._db.SaveChanges();
                TempData["message"] = "Edytowano kategorię";
                return RedirectToAction("list");
            }
            else
            {
                return View(kategoria);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Kategoria n = _db.Kategorie.Find(id);
            _db.Kategorie.Remove(n);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

		    [HttpGet]
        public ActionResult Details(int id)
        {
            Kategoria Kategoria = _db.Kategoria.Find(id);
            return View(Kategoria);
        }
		
    }
}
