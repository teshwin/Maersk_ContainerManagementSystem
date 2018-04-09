using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMSMaersk.DAL;
using CMSMaersk.Models;

namespace CMSMaersk.Controllers
{
    public class BookingsController : Controller
    {
        private ContainerContext db = new ContainerContext();
        //VesselRepository vesselRepository = new VesselRepository();

        // GET: Bookings
        public ActionResult Index()
        {
            var agent = (Agent)Session["user"];
            var bookings = db.Bookings.Include(b => b.Item).Include(b => b.Vessel).Where(booking => (booking.Item.Customer.AgentID == agent.AgentID));
            return View(bookings.ToList());
        }

        public ActionResult AllIndex()
        {
            var bookings = db.Bookings;
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            var agent = (Agent)Session["user"];

            List<Vessel> vessels = new List<Vessel>();
            foreach (var vessel in db.Vessels)
            {
                if (vessel.HasSpace())
                    vessels.Add(vessel);
            }

            ViewBag.ItemID = new SelectList(db.Items.Where(item=>(item.Customer.AgentID == agent.AgentID) && item.Status== Status.Unassigned).ToList<Item>(), "ItemID", "ItemName");
            ViewBag.VesselID = new SelectList(vessels, "VesselID", "Name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,ItemID,VesselID")] Booking booking)
        {
            var agent = (Agent)Session["user"];
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                var item = db.Items.Find(booking.ItemID);
                item.Status = Status.Pending;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Vessel> vessels = new List<Vessel>();
            foreach (var vessel in db.Vessels)
            {
                if (vessel.HasSpace())
                    vessels.Add(vessel);
            }

            ViewBag.ItemID = new SelectList(db.Items.Where(item => (item.Customer.AgentID == agent.AgentID) && item.Status == Status.Unassigned).ToList<Item>(), "ItemID", "ItemName");
            ViewBag.VesselID = new SelectList(vessels, "VesselID", "Name", booking.VesselID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            var agent = (Agent)Session["user"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking.Item.Status == Status.Complete)
                RedirectToAction("Details");
            if (booking == null)
            {
                return HttpNotFound();
            }

            List<Vessel> vessels = new List<Vessel>();
            foreach (var vessel in db.Vessels)
            {
                if (vessel.HasSpace())
                    vessels.Add(vessel);
            }
            ViewBag.ItemID = new SelectList(db.Items.Where(item => (item.Customer.AgentID == agent.AgentID) && item.Status == Status.Unassigned).ToList<Item>(), "ItemID", "ItemName");
            ViewBag.VesselID = new SelectList(vessels, "VesselID", "Name", booking.VesselID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,ItemID,VesselID")] Booking booking)
        {
            var agent = (Agent)Session["user"];
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                var item = db.Items.Find(booking.ItemID);
                item.Status = Status.Pending;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Vessel> vessels = new List<Vessel>();
            foreach (var vessel in db.Vessels)
            {
                if (vessel.HasSpace())
                    vessels.Add(vessel);
            }
            ViewBag.ItemID = new SelectList(db.Items.Where(item => (item.Customer.AgentID == agent.AgentID) && item.Status == Status.Unassigned).ToList<Item>(), "ItemID", "ItemName");
            ViewBag.VesselID = new SelectList(vessels, "VesselID", "Name", booking.VesselID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
