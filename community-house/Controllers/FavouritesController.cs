using community_house.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace community_house.Controllers
{
    public class FavouritesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Houses");
        }

        public ActionResult Create(int houseID)
        {
            this.db.Favourites.Add(new Favourite { HouseID = houseID, UserId = db.Users.FirstOrDefault(s => s.Email == User.Identity.Name).Id });
            this.db.SaveChanges();
            return RedirectToAction("Index", "Houses");
        }

        public ActionResult Delete(int houseID)
        {
            //this.db.Favourites.Remove(new Favourite { HouseID = houseID, UserId = db.Users.FirstOrDefault(s => s.Email == User.Identity.Name).Id });
            var fav = this.db.Favourites.
                Where(h => h.HouseID == houseID).
                Where(z => z.UserId == db.Users.FirstOrDefault(s => s.Email == User.Identity.Name).Id).FirstOrDefault();

            this.db.Favourites.Remove(fav);
            this.db.SaveChanges();

            return RedirectToAction("MyFavourites", "Houses");
        }
    }
}