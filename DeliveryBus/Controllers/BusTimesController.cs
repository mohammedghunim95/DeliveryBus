using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryBus.Models;

namespace DeliveryBus.Controllers
{
    [Authorize]
    public class BusTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.busTimes.ToList());
        }

        // GET: BusTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusTime busTime = db.busTimes.Find(id);
            if (busTime == null)
            {
                return HttpNotFound();
            }
            return View(busTime);
        }

        // GET: BusTimes/Create
        public ActionResult Create()
        {
            ViewBag.Dayes = new SelectList(new[] { "احد / ثلاثاء / خميس", "إثنين / أربعاء"});
            ViewBag.Time = new SelectList(new[] { "06:00 am", "06:30 am" , "07:00 am","07:30 am","08:00 am","08:30 am","09:00 am","09:30 am","10:00 am","10:30 am","11:00 am","11:30 am","12:00 pm","12:30 pm","01:00 pm","01:30 pm","02:00 pm","02:30 pm","03:00 pm","03:30 pm","04:00 pm","04:30 pm","" });


            return View();
        }

        // POST: BusTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusTimeId,Times,Days,RegionIds")] BusTime busTime, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Dayes = new SelectList(new[] { "احد / ثلاثاء / خميس", "إثنين / أربعاء" });
                ViewBag.Time = new SelectList(new[] { "06:00 am", "06:30 am", "07:00 am", "07:30 am", "08:00 am", "08:30 am", "09:00 am", "09:30 am", "10:00 am", "10:30 am", "11:00 am", "11:30 am", "12:00 pm", "12:30 pm", "01:00 pm", "01:30 pm", "02:00 pm", "02:30 pm", "03:00 pm", "03:30 pm", "04:00 pm", "04:30 pm", "" });

                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                busTime.Image = upload.FileName;

                db.busTimes.Add(busTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busTime);
        }

        // GET: BusTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusTime busTime = db.busTimes.Find(id);
            if (busTime == null)
            {
                return HttpNotFound();
            }
            return View(busTime);
        }

        // POST: BusTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusTimeId,Times,Days,RegionIds")] BusTime busTime, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                busTime.Image = upload.FileName;

                db.Entry(busTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busTime);
        }

        // GET: BusTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusTime busTime = db.busTimes.Find(id);
            if (busTime == null)
            {
                return HttpNotFound();
            }
            return View(busTime);
        }

        // POST: BusTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BusTime busTime = db.busTimes.Find(id);
            db.busTimes.Remove(busTime);
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
    }
}
