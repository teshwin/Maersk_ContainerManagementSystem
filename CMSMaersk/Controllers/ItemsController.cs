using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSMaersk.DAL;
using CMSMaersk.Models;

namespace CMSMaersk.Controllers
{
    public class ItemsController : Controller
    {
        private ContainerContext db = new ContainerContext();

        // GET: Items
        public ActionResult Index()
        {
            var agent = (Agent)Session["user"];
            var items = db.Items.Include(i => i.Customer).Where(item=>item.Customer.AgentID==agent.AgentID && item.Status!=Status.Complete);
            return View(items.ToList());
        }

        public ActionResult AllIndex()
        {
            var items = db.Items.Include(i => i.Customer).Where(item => item.Status != Status.Complete);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            var agent = (Agent)Session["user"];
            ViewBag.CustomerID = new SelectList(db.Customers.Where(cust => cust.AgentID == agent.AgentID).ToList<Customer>(), "CustomerID", "FirstName");

            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,TotalBays,DueDay,Status,CustomerID")] Item item)
        {
            var agent = (Agent)Session["user"];
            item.Status = Status.Unassigned;
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers.Where(cust => cust.AgentID == agent.AgentID).ToList<Customer>(), "CustomerID", "FirstName");
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            var agent = (Agent)Session["user"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers.Where(cust => cust.AgentID == agent.AgentID).ToList<Customer>(), "CustomerID", "FirstName");
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,TotalBays,DueDay,Status,CustomerID")] Item item)
        {
            var agent = (Agent)Session["user"];
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers.Where(cust => cust.AgentID == agent.AgentID).ToList<Customer>(), "CustomerID", "FirstName");
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
