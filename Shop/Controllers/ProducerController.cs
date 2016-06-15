using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ProducerController : Controller
    {
        private Context _db;

        public ProducerController()
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
            var Producer = this._db.Producer;
            return View(Producer);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Producer model)
        {
            if (ModelState.IsValid)
            {
                //model.AddDate = DateTime.Now;
                this._db.Producer.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano producenta.";
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
            Producer movie = _db.Producer.Find(id);
            _db.Producer.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Producer producer = _db.Producer.Find(id);
            return View(producer);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Producer producer = _db.Producer.Find(id);
            return View(producer);
        }

        //[HttpPost]
        //public ActionResult Edit(Producer model)
        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(int id)
        {
            //if (ModelState.IsValid)
            Producer producer = _db.Producer.Find(id);
            if (TryUpdateModel(producer, "",
                new string[] { "Nazwa", "Adres", "Nip", "Regon" }))
            {
                //int id = (int)model.Id;
                //Producer producer = this._db.Producer.Find(id);
                //_db.Producer.Remove(producer);
                //this._db.Producer.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Edytowano producenta...";
                return RedirectToAction("list");
            }
            else
            {
                return View(producer);
            }
        }

    }
}
