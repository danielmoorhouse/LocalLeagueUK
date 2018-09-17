using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocalLeague1.Models;

namespace LocalLeague1.Controllers
{
    public class VenuesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Venues
        public ActionResult Index()
        {
            return View(db.Venues.ToList());
        }

        // GET: Venues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venues venues = db.Venues.Find(id);
            if (venues == null)
            {
                return HttpNotFound();
            }
            return View(venues);
        }

        // GET: Venues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Venues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VenueId,VenueName,VenuePcode,VenueMap")] Venues venues)
        {
            if (ModelState.IsValid)
            {
                db.Venues.Add(venues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venues);
        }

        // GET: Venues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venues venues = db.Venues.Find(id);
            if (venues == null)
            {
                return HttpNotFound();
            }
            return View(venues);
        }

        // POST: Venues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VenueId,VenueName,VenuePcode,VenueMap")] Venues venues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venues);
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venues venues = db.Venues.Find(id);
            if (venues == null)
            {
                return HttpNotFound();
            }
            return View(venues);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venues venues = db.Venues.Find(id);
            db.Venues.Remove(venues);
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
