using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class NewsController: Controller
    {
        private Context _db;

        public NewsController()
        {
            this._db = new Context();
        }

        //
        // GET: /News/

        public ActionResult Index()
        {
            ViewBag.Message = "Newsy";
            return View();
        }

        public ActionResult List()
        {
            var Newsy = this._db.News;
            return View(Newsy);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(News model)
        {
            if (ModelState.IsValid)
            {
                //model.NewsedDate = DateTime.Now;
                this._db.News.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano newsa";
                return RedirectToAction("list");
            }
            else
            {
                return View(model);
            }
        }

    }
}
