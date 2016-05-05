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
                this._db.Promotions.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano promocję.";
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
            Promotion Promotion = _db.Promotions.Find(id);
            return View(Promotion);
        }

        [HttpPost]
        public ActionResult Edit(Promotion model)
        {
            if (ModelState.IsValid)
            {
                int id = (int)model.Id;
                Promotion Promotion = this._db.Promotions.Find(id);
                _db.Promotions.Remove(Promotion);
                this._db.Promotions.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Edytowano promocję.";
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
            Promotion Promotion = _db.Promotions.Find(id);
            _db.Promotions.Remove(Promotion);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Promotion Promotion = _db.Promotions.Find(id);
            return View(Promotion);
        }

    }
}
