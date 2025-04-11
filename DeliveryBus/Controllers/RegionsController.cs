using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DeliveryBus.Models;
using DeliveryBus.ViewModels;
using Microsoft.AspNet.Identity;

namespace DeliveryBus.Controllers
{

    public class RegionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        [HttpPost]
        public ActionResult Confirm()
        {
        


            return View();
        }

        [AllowAnonymous]
        public ActionResult List(int id)
        {
            return View(db.regions.Where(r=>r.BusLinesId ==id));
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult Index()
        {
            var regions = db.regions.Include(r => r.BusLine);
            return View(regions.ToList());
        }

        public ActionResult Location()
        {
            return View();
        }

        [AllowAnonymous]
        // GET: Regions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var region = db.regions.Include(r => r.BusLine).Include(r=>r.BusLine.busCompany).FirstOrDefault(i => i.RegionId ==id);


            if (region == null)
            {
                return HttpNotFound();
            }
            Session["RegionId"] = id;
            return View(region);
        }


        [Authorize]
        public ActionResult Apply(LoginViewModel model)
        {
            var usr = User.Identity.GetUserId();


            var CurrentUser = db.Users.Where(a => a.Id == usr).SingleOrDefault();
            var balance = 2;
            Session["s"] = balance;

            if(balance < 0)
            {
                Session["s"] = 0;
            }
            //var CurrentUser = db.Users.Where(a => a.UserName == model.Email).SingleOrDefault();

            //Session["usr"] = CurrentUser.Balance;

            return View();

        }

        [Authorize]
        [HttpPost]
        public ActionResult Apply(string Message, double sub, double subPrice)
        {
            var usr = User.Identity.GetUserId();


            var CurrentUser = db.Users.Where(a => a.Id == usr).SingleOrDefault();

            Message = "I Want Book this Trip! Thanks.";

            var UserId = User.Identity.GetUserId();
            var regionid = (int)Session["RegionId"];

            double balance = CurrentUser.Balance;

            var region = new ApplyTrip();
        

            double x = balance - sub;

            Session["s"] = x;

            region.UserId = UserId;
            region.RegionId = regionid;
            region.Message = Message;
            region.DateTime = DateTime.Now;
            region.Subscribe = sub;
            region.Price = subPrice;
            CurrentUser.Balance = x;


            db.ApplyTrips.Add(region);
            db.SaveChanges();


            if (x < 0)
            {
                Session["s"] = 0;

            }

            if (x < 0.5)
            {
                return RedirectToAction("Confirm", "Bill");

            }
            //else
            //{
            //    return RedirectToAction("List", "BusCompanies");
            //}



            return RedirectToAction("List", "BusCompanies");


        }


        [Authorize]
        public ActionResult GetApplyTripByUser()
        {
            Session["user"] = User.Identity.GetUserName();

            var oldtime = new ApplyTrip();

            

            var userId = User.Identity.GetUserId();
            var region = db.ApplyTrips.Where(r => r.UserId == userId).Include(r=>r.Region);

            

            DateTime oldTime = oldtime.DateTime;
            DateTime x30MinsLater = oldTime.AddMinutes(5);
            string a = (string.Format("{0}", oldTime));
            string b = (string.Format("{0}", x30MinsLater));

            Session["old"] = a;
            Session["Addminutes"] = b;

            return View(region.ToList());
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            ViewBag.BusLinesId = new SelectList(db.busLines, "BusLinesId", "Line");
            ViewBag.Time = new SelectList(new[] { "06:00 am", "06:05 am", "06:10 am", "06:15 am", "06:20 am", "06:25 am", "06:30 am", "06:35 am" });

            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Region region, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Time = new SelectList(new[] { "06:00 am", "06:05 am", "06:10 am", "06:15 am", "06:20 am", "06:25 am", "06:30 am", "06:35 am" });

                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                region.Image = upload.FileName;

                db.regions.Add(region);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusLinesId = new SelectList(db.busLines, "BusLinesId", "Line", region.BusLinesId);
            return View(region);
        }

        [Authorize(Roles = "Moderator")]
        // GET: Regions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusLinesId = new SelectList(db.busLines, "BusLinesId", "Line", region.BusLinesId);
            return View(region);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegionId,Name,Time,BusLinesId")] Region region, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                region.Image = upload.FileName;

                db.Entry(region).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusLinesId = new SelectList(db.busLines, "BusLinesId", "Line", region.BusLinesId);
            return View(region);
        }

        // GET: Regions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Region region = db.regions.Find(id);
            db.regions.Remove(region);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTrip(int id)
        {
            
            ApplyTrip trip = db.ApplyTrips.Find(id);
            //db.ApplyTrips.Remove(trip);
            //db.SaveChanges();
            return View(trip);
        }

        [HttpPost]
        [ActionName("DeleteTrip")]
        public ActionResult DeleteTrip_post(int id)
        {
            var usr = User.Identity.GetUserId();

            var CurrentUser = db.Users.Where(a => a.Id == usr).SingleOrDefault();

            ApplyTrip trip = db.ApplyTrips.Find(id);

            if(CurrentUser.Balance< 0)
            {
                CurrentUser.Balance = 0;
            }
            double balance = CurrentUser.Balance + trip.Price;
            

            var collect = CurrentUser.Balance + trip.Price;

            CurrentUser.Balance = collect;

            db.ApplyTrips.Remove(trip);
            db.SaveChanges();
            return RedirectToAction("List", "BusCompanies");
        }


        //public ActionResult BillDetails(int id)
        //{
        //   var trip= db.ApplyTrips.FirstOrDefault(x=>x.Id==id).;

        //    return View(trip);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
