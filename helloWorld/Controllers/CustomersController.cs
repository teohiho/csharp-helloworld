using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using helloWorld.Models;
namespace helloWorld.Controllers
{
    public class CustomersController : Controller
    {
        PGDbContext _context;
        public CustomersController()
        {
            _context = new PGDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            /*var customerList = new List<Customer>
            {
                new Customer() { Name = "TEO1"},
                new Customer() { Name = "TEO2"}

            };*/

            return View(_context.Customers.ToList());
            //return View();
        }

        public ActionResult GetData()
        {
            using(PGDbContext db = new PGDbContext())
            {
                List<Customer> customerList = db.Customers.ToList<Customer>();
                return Json(new { data = customerList },JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Link/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Link/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Customer link)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(link);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(link);
        }









        // GET: Link/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer link = _context.Customers.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: Link/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Customer link)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(link).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(link);
        }





        // GET: Link/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer link = _context.Customers.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: Link/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer link = _context.Customers.Find(id);
            _context.Customers.Remove(link);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}