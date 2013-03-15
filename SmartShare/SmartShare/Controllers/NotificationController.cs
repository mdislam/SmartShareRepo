using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartShare.Models;

namespace SmartShare.Controllers
{
    public class NotificationController : Controller
    {
        private NotificationContext db = new NotificationContext();

        //
        // GET: /Notification/

        public ActionResult Index()
        {
            return View(db.NotificationDb.ToList());
        }

        //
        // GET: /Notification/

        public ActionResult Inbox()
        {
            return View(db.NotificationDb.ToList());
        }

        public ActionResult Outbox()
        {
            return View(db.NotificationDb.ToList());
        }

        //
        // GET: /Notification/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Notifications notifications = db.NotificationDb.Find(id);
            if (notifications == null)
            {
                return HttpNotFound();
            }
            return View(notifications);
        }

        //
        // GET: /Notification/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            ViewBag.AdId = "" + id;
            return View();
        }

        //
        // POST: /Notification/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Notifications notifications)
        {
            if (ModelState.IsValid)
            {
                db.NotificationDb.Add(notifications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notifications);
        }

        //
        // GET: /Notification/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Notifications notifications = db.NotificationDb.Find(id);
            if (notifications == null)
            {
                return HttpNotFound();
            }
            return View(notifications);
        }

        //
        // POST: /Notification/Edit/5

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Notifications notifications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notifications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notifications);
        }

        //
        // GET: /Notification/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Notifications notifications = db.NotificationDb.Find(id);
            if (notifications == null)
            {
                return HttpNotFound();
            }
            return View(notifications);
        }

        //
        // POST: /Notification/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notifications notifications = db.NotificationDb.Find(id);
            db.NotificationDb.Remove(notifications);
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