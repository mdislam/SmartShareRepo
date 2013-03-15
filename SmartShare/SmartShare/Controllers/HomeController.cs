using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartShare.Models;
using System.Web.Security;
//using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using System.ComponentModel;
using System.Web.Hosting;
using System.Net.Http.Headers;
using System.Net;

namespace SmartShare.Controllers
{
    public class HomeController : Controller
    {
        private AdvertisementsContext db = new AdvertisementsContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.AdvertisementsDb.ToList());
        }

        //public FileContentResult getImg(int id)
        //{
        //    Advertisements advertisements = db.AdvertisementsDb.Find(id);
        //    byte[] byteArray = advertisements.AdvertisementImage;
        //    if (byteArray != null)
        //    {
        //        return new FileContentResult(byteArray, "image/jpeg");
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public Image getImgae(int id)
        {
            Advertisements advertisements = db.AdvertisementsDb.Find(id);
            byte[] byteArray = advertisements.AdvertisementImage;

            if (byteArray != null)
            {
                MemoryStream memoryStream = new MemoryStream(byteArray);
                return Image.FromStream(memoryStream);
            }
            else
            {
                return null;
            }
        }

        //public HttpResponseMessage getImage(int id)
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();

        //    Advertisements advertisements = db.AdvertisementsDb.Find(id);
        //    TypeConverter typeConverter = TypeDescriptor.GetConverter(typeof(Bitmap));
        //    Bitmap bmp = (Bitmap)typeConverter.ConvertFrom(advertisements.AdvertisementImage);

        //    var Fs = new FileStream(HostingEnvironment.MapPath("~/Images") + @"\I" + id.ToString() + ".png", FileMode.Create);
        //    bmp.Save(Fs, ImageFormat.Png);
        //    bmp.Dispose();

        //    Image img = Image.FromStream(Fs);
        //    Fs.Close();
        //    Fs.Dispose();

        //    MemoryStream ms = new MemoryStream();
        //    img.Save(ms, ImageFormat.Png);

        //    response.Content = new ByteArrayContent(ms.ToArray());
        //    ms.Close();
        //    ms.Dispose();

        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
        //    response.StatusCode = HttpStatusCode.OK;

        //    return response;
        //}

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Advertisements advertisements = db.AdvertisementsDb.Find(id);
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



                db.AdvertisementsDb.Add(advertisements);
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
            Advertisements advertisements = db.AdvertisementsDb.Find(id);
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
            Advertisements advertisements = db.AdvertisementsDb.Find(id);
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
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisements advertisements = db.AdvertisementsDb.Find(id);
            db.AdvertisementsDb.Remove(advertisements);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}