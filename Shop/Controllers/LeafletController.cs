using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class LeafletController : Controller
    {
        private Context _db;

        public LeafletController()
        {
            this._db = new Context();
        }

        //
        // GET: /Leaflet/

        public ActionResult Index()
        {
            ViewBag.Message = "Witaj w naszym sklepie";
            return View();
        }

        public ActionResult List()
        {
            var Leaflets = this._db.Leaflets;
            return View(Leaflets);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Leaflet model)
        {
            if (ModelState.IsValid)
            {
                this._db.Leaflets.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano ulotkę.";
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
            Leaflet Leaflet = _db.Leaflets.Find(id);
            return View(Leaflet);
        }

        [HttpPost]
        public ActionResult Edit(Leaflet model)
        {
            if (ModelState.IsValid)
            {
                int id = (int)model.Id;
                Leaflet Leaflet = this._db.Leaflets.Find(id);
                _db.Leaflets.Remove(Leaflet);
                this._db.Leaflets.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Edytowano ulotkę.";
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
            Leaflet Leaflet = _db.Leaflets.Find(id);
            _db.Leaflets.Remove(Leaflet);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Leaflet Leaflet = _db.Leaflets.Find(id);
            return View(Leaflet);
        }

    }
}
