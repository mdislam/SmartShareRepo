using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartShareV2.Models;

namespace SmartShareV2.Controllers
{
    public class TestController : Controller
    {
        private AdvertisementsContext db = new AdvertisementsContext();

        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View(db.Advertisements.ToList());
        }

        //
        // GET: /Test/Details/5

        public ActionResult Details(int id = 0)
        {
            Advertisements advertisements = db.Advertisements.Find(id);
            if (advertisements == null)
            {
                return HttpNotFound();
            }
            return View(advertisements);
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Test/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Advertisements advertisements)
        {
            if (ModelState.IsValid)
            {
                db.Advertisements.Add(advertisements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertisements);
        }

        //
        // GET: /Test/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Advertisements advertisements = db.Advertisements.Find(id);
            if (advertisements == null)
            {
                return HttpNotFound();
            }
            return View(advertisements);
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Advertisements advertisements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertisements);
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Advertisements advertisements = db.Advertisements.Find(id);
            if (advertisements == null)
            {
                return HttpNotFound();
            }
            return View(advertisements);
        }

        //
        // POST: /Test/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisements advertisements = db.Advertisements.Find(id);
            db.Advertisements.Remove(advertisements);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}