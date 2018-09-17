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
    public class LeaguesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Leagues
        public ActionResult Index()
        {
            List<LeagueViewModel> LeagueList =
                new List<LeagueViewModel>();

            List<Leagues> leagues;

            leagues = db.Leagues.ToList();

            foreach (Leagues l in leagues)
            {
                LeagueOps leagueOps = db.LeagueOps.Where(x => x.LeagueOpsId == l.LeagueOpsId).SingleOrDefault();

                LeagueViewModel toAdd = new LeagueViewModel();

                toAdd.Leagues = l;
                toAdd.LeagueOps = leagueOps;

                LeagueList.Add(toAdd);
            }
            return View(LeagueList);
        }

        // GET: Leagues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leagues leagues = db.Leagues.Find(id);
            if (leagues == null)
            {
                return HttpNotFound();
            }
            return View(leagues);
        }

        // GET: Leagues/Create
        public ActionResult Create(int LeagueOpsId = 0)
        {
            var leagueopsQuery = from m in db.LeagueOps
                                 orderby m.LeagueOpsName
                                 select m;
            if (LeagueOpsId == 0)
                ViewBag.LeagueOpsId = new SelectList(leagueopsQuery, "LeagueOpsId",
                                                "LeagueOpsName", null);
            else
                ViewBag.LeagueOpsId = new SelectList(leagueopsQuery, "LeagueOpsId",
                                               "LeagueOpsName", LeagueOpsId);

            return View();
        }

        // POST: Leagues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeagueId,LeagueName,LeagueOpsId")] Leagues leagues)
        {
            if (ModelState.IsValid)
            {
                db.Leagues.Add(leagues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leagues);
        }

        // GET: Leagues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leagues leagues = db.Leagues.Find(id);
            if (leagues == null)
            {
                return HttpNotFound();
            }
            var leagueopsQuery = from m in db.LeagueOps
                                 orderby m.LeagueOpsName
                                 select m;
           
             
                ViewBag.LeagueOpsId = new SelectList(leagueopsQuery, "LeagueOpsId",
                                               "LeagueOpsName", leagues.LeagueOpsId);

            return View(leagues);
        }

        // POST: Leagues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeagueId,LeagueName,LeagueOpsId")] Leagues leagues)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leagues).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leagues);
        }

        // GET: Leagues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leagues leagues = db.Leagues.Find(id);
            if (leagues == null)
            {
                return HttpNotFound();
            }
            return View(leagues);
        }

        // POST: Leagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leagues leagues = db.Leagues.Find(id);
            db.Leagues.Remove(leagues);
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
