using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocalLeague1.Models;
using LocalLeague1.Models.ViewModels;

namespace LocalLeague1.Controllers
{
    public class RefereesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Referees
        public ActionResult Index()
        {
            List<RefViewModel> RefInfo =
                new List<RefViewModel>();

            List<Referee> RefEntry;

            RefEntry = db.Referees.ToList();

            foreach (Referee r in RefEntry)
            {
                Matches matches = db.Matches.Where(x => x.RefId == r.RefId).FirstOrDefault();
                Venues venues = db.Venues.Where(x => x.VenueId == r.RefId).FirstOrDefault();

                RefViewModel toAdd = new RefViewModel();

                toAdd.referee = r;
                toAdd.matches = matches;
                toAdd.venues = venues;

                RefInfo.Add(toAdd);

            }
            return View(RefInfo);
        }

        // GET: Referees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referee referee = db.Referees.Find(id);
            if (referee == null)
            {
                return HttpNotFound();
            }
            return View(referee);
        }

        // GET: Referees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Referees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RefId,RefName")] Referee referee)
        {
            if (ModelState.IsValid)
            {
                db.Referees.Add(referee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(referee);
        }

        // GET: Referees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referee referee = db.Referees.Find(id);
            if (referee == null)
            {
                return HttpNotFound();
            }
            return View(referee);
        }

        // POST: Referees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RefId,RefName")] Referee referee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referee);
        }

        // GET: Referees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referee referee = db.Referees.Find(id);
            if (referee == null)
            {
                return HttpNotFound();
            }
            return View(referee);
        }

        // POST: Referees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Referee referee = db.Referees.Find(id);
            db.Referees.Remove(referee);
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
