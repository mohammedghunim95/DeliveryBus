using DeliveryBus.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DeliveryBus.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {

            IdentityRole role = db.Roles.Find(id);

            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            IdentityRole role = db.Roles.Find(id);

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
