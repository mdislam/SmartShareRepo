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
    public class NotificationController : Controller
    {
        private NotificationContext db = new NotificationContext();
        

        //
        // GET: /Notification/

        public ActionResult Index()
        {
            return View(db.Notification.ToList());
        }

        //
        // GET: /Notification/Details/5

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Notification notification = db.Notification.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        //
        // GET: /Notification/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Notification/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Notification notification)
        {


            if (ModelState.IsValid)
            {
                db.Notification.Add(notification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notification);
        }

        //
        // GET: /Notification/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Notification notification = db.Notification.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        //
        // POST: /Notification/Edit/5

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notification);
        }

        //
        // GET: /Notification/Delete/5

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Notification notification = db.Notification.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        //
        // POST: /Notification/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notification notification = db.Notification.Find(id);
            db.Notification.Remove(notification);
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