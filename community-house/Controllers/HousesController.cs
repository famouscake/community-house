using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using community_house.Models;


namespace community_house.Controllers
{
    public class HousesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Houses
        public ActionResult MyIndex()
        {
            IQueryable<House> houses = db.Houses.
                Include(h => h.User).
                Include(h => h.Pictures).
                Where(h => h.UserId == db.Users.FirstOrDefault(s => s.Email == User.Identity.Name).Id);

            return View(houses.ToList());
        }

        // GET: Houses
        public ActionResult Index(string sortOrder)
        {
            IQueryable<House> houses = this.GetSortedHouses(sortOrder);

            this.ViewData = this.InitializeViewBagSortOrder(sortOrder);
            
            return View(houses.ToList());
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HouseID,UserId,Price,Area,City,Address")] House house, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Public/Images/") + file.FileName);                    
                }

                db.Houses.Add(house);
                db.SaveChanges();

                db.Pictures.Add(new Picture { FileName = file.FileName, HouseID = house.HouseID });
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", house.UserId);
            return View(house);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", house.UserId);
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HouseID,UserId,Price,Area,City,Address")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", house.UserId);
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private IQueryable<House> GetSortedHouses(string sortOrder = "cityasc")
        {
            IQueryable<House> houses = db.Houses.Include(h => h.User).Include(h => h.Pictures);
            
            if (sortOrder == "cityasc") {
                return houses.OrderBy(s => s.City);
            }

            if (sortOrder == "citydesc") {
                return houses.OrderByDescending(s => s.City);
            }

            if (sortOrder == "areaasc") {
                return houses.OrderBy(s => s.Area);
            }

            if (sortOrder == "areadisc") {
                return houses.OrderByDescending(s => s.Area);
            }

            if (sortOrder == "priceasc") {
                return houses.OrderBy( s => s.Price);
            }

            if (sortOrder == "pricedesc") {
                return houses.OrderByDescending(s => s.Price);
            }

            if (sortOrder == "emailasc") {
                return houses.OrderBy(s => s.User.Email);
            }
            if (sortOrder == "emaildesc") {
                return houses.OrderByDescending(s => s.User.Email);
            }

            return houses;
        }

        private ViewDataDictionary InitializeViewBagSortOrder(string sortOrder)
        {
            ViewDataDictionary d = new ViewDataDictionary();

            if (sortOrder == null || sortOrder == "")
            {
                sortOrder = "priceasc";
            }

            if (sortOrder == "cityasc")
            {
                d["city"] = "desc";
            }
            else
            {
                d["city"] = "asc";
            }


            if (sortOrder == "areaasc")
            {
                d["area"] = "desc";
            }
            else
            {
                d["area"] = "asc";
            }

            if (sortOrder == "priceasc")
            {
                d["price"] = "desc";
            }
            else
            {
                d["price"] = "asc";
            }

            if (sortOrder == "emailasc")
            {
                d["email"] = "desc";
            }
            else
            {
                d["email"] = "asc";
            }

            return d;
        }
    }
}
