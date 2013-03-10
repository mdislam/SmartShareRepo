using SmartShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SmartShare.Controllers
{
    public class ProfileController : Controller
    {
        private AdvertisementsContext db = new AdvertisementsContext();
        //
        // GET: /Profile/

        [Authorize]
        public ActionResult Index()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            int userId = (Int32)user.ProviderUserKey;

            return View(db.AdvertisementsDb.Where(uid => uid.UserId == userId).ToList());
        }

    }
}
