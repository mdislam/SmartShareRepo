using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartShareV2.Models;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.IO;

namespace SmartShareV2.Controllers
{
    public class HomeController : Controller
    {
        private AdvertisementsContext db = new AdvertisementsContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.Advertisements.ToList());
        }

        public FileContentResult getImg(int id)
        {
            Advertisements advertisements = db.Advertisements.Find(id);
            byte[] byteArray = advertisements.AdvertisementImage;
            if (byteArray != null)
            {
                return new FileContentResult(byteArray, "image/jpeg");
            }
            else
            {
                return null;
            }
        }

        //
        // GET: /Home/Details/5

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
        // GET: /Home/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Advertisements advertisements, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                MembershipUser user = Membership.GetUser(User.Identity.Name);
                advertisements.UserId = (Int32)user.ProviderUserKey;
                advertisements.CreatedOn = DateTime.Now;

                if (file != null)
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();

                    advertisements.AdvertisementImage = data;
                }

                
                
                db.Advertisements.Add(advertisements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertisements);
        }

        //
        // GET: /Home/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Advertisements advertisements = db.Advertisements.Find(id);
            if ((Int32)Membership.GetUser(User.Identity.Name).ProviderUserKey == advertisements.UserId)
            {
                if (advertisements == null)
                {
                    return HttpNotFound();
                }
                return View(advertisements);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [Authorize]
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
        // GET: /Home/Delete/5
        [Authorize]
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
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
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