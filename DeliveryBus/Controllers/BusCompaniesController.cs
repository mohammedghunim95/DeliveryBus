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
    [Authorize(Roles ="Administrator")]
    public class BusCompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult List()
        {
            return View(db.busCompanies.ToList());
        }

        // GET: BusCompanies
        public ActionResult Index()
        {
            return View(db.busCompanies.ToList());
        }

        // GET: BusCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusCompany busCompany = db.busCompanies.Find(id);
            if (busCompany == null)
            {
                return HttpNotFound();
            }
            return View(busCompany);
        }

        // GET: BusCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusCompanyId,Name,Description")] BusCompany busCompany, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                busCompany.Image = upload.FileName;
                db.busCompanies.Add(busCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busCompany);
        }

        // GET: BusCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusCompany busCompany = db.busCompanies.Find(id);
            if (busCompany == null)
            {
                return HttpNotFound();
            }
            return View(busCompany);
        }

        // POST: BusCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusCompanyId,Name,Description")] BusCompany busCompany, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                busCompany.Image = upload.FileName;

                db.Entry(busCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busCompany);
        }

        // GET: BusCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusCompany busCompany = db.busCompanies.Find(id);
            if (busCompany == null)
            {
                return HttpNotFound();
            }
            return View(busCompany);
        }

        // POST: BusCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BusCompany busCompany = db.busCompanies.Find(id);
            db.busCompanies.Remove(busCompany);
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
