using DeliveryBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliveryBus.Controllers
{
    public class BillController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Bill
        public ActionResult Confirm()
        {
            //Save to Bill
            //db.Bills.Add(new Bill { Email = User.Identity.Name, Date = DateTime.Now });
            //db.SaveChanges();

            ////Get the last bill id
            //var billid = (from b in db.Bills
            //              where b.Email == User.Identity.Name
            //              select b.Id).Max();

            ////get cart data




            //db.SaveChanges();
            return View();
        }
    }
}