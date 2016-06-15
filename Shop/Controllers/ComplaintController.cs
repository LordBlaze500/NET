using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ComplaintController : Controller
    {
        private Context _db;

        public ComplaintController()
        {
            this._db = new Context();
        }

        //
        // GET: /Complaint/

        public ActionResult Index()
        {
            ViewBag.Message = "Witaj w naszym sklepie";
            return View();
        }

        public ActionResult List()
        {
            var Complaints = this._db.Complaints;
            return View(Complaints);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Complaint model)
        {
            if (ModelState.IsValid)
            {
                this._db.Complaints.Add(model);
                this._db.SaveChanges();
                TempData["message"] = "Dodano zmówienie.";
                return RedirectToAction("list");
            }
            else
            {
                TempData["message"] = "Nie dodano reklamacji - prawdopodobnie zamówienie o podanym ID nie istnieje";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Complaint movie = _db.Complaints.Find(id);
            _db.Complaints.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            Complaint Complaint = _db.Complaints.Find(id);
            return View(Complaint);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Complaint Complaint = _db.Complaints.Find(id);
            return View(Complaint);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(int id)
        {
            Complaint Complaint = _db.Complaints.Find(id);
            if (TryUpdateModel(Complaint, "",
                new string[] { "ProductCode", "SaleDate", "Invoice", "ProductName", "DamageDesc" }))
            {
                this._db.SaveChanges();
                TempData["message"] = "Zedytowano zmówienie.";
                return RedirectToAction("list");
            }
            else
            {
                return View(Complaint);
            }
        }

    }
}
