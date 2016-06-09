using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class BirthdaysController: Controller
    {
        private Context _db;

        public BirthdaysController()
        {
            this._db = new Context();
        }

        //
        // GET: /News/

        public ActionResult Index()
        {
            ViewBag.Message = "Urodziny";
            return View();
        }

        public ActionResult List()
        {
            var Urodziny = this._db.Birthdays;
            return View(Urodziny);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Birthdays model)
        {
            if (ModelState.IsValid)
            {
                //model.NewsedDate = DateTime.Now;
                this._db.Birthdays.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano informacje o urodzinach użytkownika!";
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
            Birthdays Birthdays = _db.Birthdays.Find(id);
            return View(Birthdays);
        }

        [HttpPost]
        public ActionResult Edit(Birthdays model)
        {
            if (ModelState.IsValid)
            {
                int id = (int)model.Id;
                Birthdays Birthdays = this._db.Birthdays.Find(id);
                _db.Birthdays.Remove(Birthdays);
                this._db.Birthdays.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Urodziny edytowane!";
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
            Birthdays n = _db.Birthdays.Find(id);
            _db.Birthdays.Remove(n);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
