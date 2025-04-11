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
    [Authorize(Roles = "Moderator")]
    public class BusLinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult List(int id)
        {
            return View(db.busLines.Where(b=>b.BusCompanyId ==id));
        }

        // GET: BusLines
        public ActionResult Index()
        {
            var busLines = db.busLines.Include(b => b.busCompany).Include(b => b.busTime);
            return View(busLines.ToList());
        }

        // GET: BusLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusLine busLine = db.busLines.Find(id);
            if (busLine == null)
            {
                return HttpNotFound();
            }
            return View(busLine);
        }

        // GET: BusLines/Create
        public ActionResult Create()
        {
            ViewBag.BusCompanyId = new SelectList(db.busCompanies, "BusCompanyId", "Name");
            ViewBag.BusTimeId = new SelectList(db.busTimes, "BusTimeId", "Times");
            ViewBag.Gate = new SelectList(new[] { "الرئيسية", "الشمالية","الجنوبية" });

            return View();
        }

        // POST: BusLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusLinesId,Line,Gate,BusCompanyId,BusTimeId")] BusLine busLine, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                busLine.Image = upload.FileName;

                ViewBag.Gate = new SelectList(new[] { "الرئيسية", "الشمالية", "الجنوبية" });

                db.busLines.Add(busLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusCompanyId = new SelectList(db.busCompanies, "BusCompanyId", "Name", busLine.BusCompanyId);
            ViewBag.BusTimeId = new SelectList(db.busTimes, "BusTimeId", "Times", busLine.BusTimeId);
            return View(busLine);
        }

        // GET: BusLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusLine busLine = db.busLines.Find(id);
            if (busLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusCompanyId = new SelectList(db.busCompanies, "BusCompanyId", "Name", busLine.BusCompanyId);
            ViewBag.BusTimeId = new SelectList(db.busTimes, "BusTimeId", "Times", busLine.BusTimeId);
            return View(busLine);
        }

        // POST: BusLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusLinesId,Line,Gate,BusCompanyId,BusTimeId")] BusLine busLine, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                busLine.Image = upload.FileName;

                db.Entry(busLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusCompanyId = new SelectList(db.busCompanies, "BusCompanyId", "Name", busLine.BusCompanyId);
            ViewBag.BusTimeId = new SelectList(db.busTimes, "BusTimeId", "Times", busLine.BusTimeId);
            return View(busLine);
        }

        // GET: BusLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusLine busLine = db.busLines.Find(id);
            if (busLine == null)
            {
                return HttpNotFound();
            }
            return View(busLine);
        }

        // POST: BusLines/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BusLine busLine = db.busLines.Find(id);
            db.busLines.Remove(busLine);
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
