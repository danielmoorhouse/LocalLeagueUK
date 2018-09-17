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
    public class MatchesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Matches
        public ActionResult Index()
        {
            List<MatchesViewModel> matches =
                new List<MatchesViewModel>();
           

            List<Matches> matchEntry;

            matchEntry = db.Matches.ToList();

            foreach (Matches m in matchEntry)
            {
                Matches Matches = db.Matches.Where(x => x.MatchId == m.MatchId).Single();

                Leagues leagues = db.Leagues.Where(x => x.LeagueId == m.LeagueId).Single();

                Teams HomeTeamId = db.Teams.Where(x => x.TeamId == m.HomeTeamId).FirstOrDefault();

                Teams AwayTeamId = db.Teams.Where(x => x.TeamId == m.AwayTeamId).FirstOrDefault();

                Referee referee = db.Referees.Where(x => x.RefId == m.RefId).Single();

                Venues venues = db.Venues.Where(x => x.VenueId == m.VenueId).SingleOrDefault();

                MatchesViewModel toAdd = new MatchesViewModel();

                toAdd.Matches = m;
                toAdd.Leagues = leagues;
                toAdd.Teams = HomeTeamId;
                toAdd.Teams = AwayTeamId;
                toAdd.Referee = referee;
                toAdd.Venues = venues;

                matches.Add(toAdd);
            }
            return View(matches);
        }

        // GET: Matches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matches matches = db.Matches.Find(id);
            if (matches == null)
            {
                return HttpNotFound();
            }
            return View(matches);
        }

        // GET: Matches/Create
        public ActionResult Create(int LeagueId = 0, int HomeTeamId = 0, int AwayTeamId = 0,
            int RefId = 0, int VenueId = 0)
        {
            //League--------------------------------------------
            var leagueQuery = from m in db.Leagues
                            orderby m.LeagueName
                            select m;
            if (LeagueId == 0)

                ViewBag.LeagueId = new SelectList(leagueQuery, "LeagueId",
                                        "LeagueName", null);
            else
                ViewBag.LeagueId = new SelectList(leagueQuery, "LeagueId",
                                        "LeagueName", LeagueId);

            //Teams-------------------------------------------
            var teamQuery = from m in db.Teams
                             orderby m.TeamName
                             select m;

            if (HomeTeamId == 0)

                ViewBag.HomeTeamId = new SelectList(teamQuery, "TeamId",
                                    "TeamName", null);
            else
                ViewBag.HomeTeamId = new SelectList(teamQuery, "TeamId",
                                    "TeamName", HomeTeamId);

            var teamQuery1 = from m in db.Teams
                            orderby m.TeamName
                            select m;

            if (AwayTeamId == 0)

                ViewBag.AwayTeamId = new SelectList(teamQuery1, "TeamId",
                                    "TeamName", null);
            else
                ViewBag.AwayTeamId = new SelectList(teamQuery1, "TeamId",
                                    "TeamName", AwayTeamId);



            //Referees-----------------------------------------
            var refQuery = from m in db.Referees
                            orderby m.RefName
                            select m;

            if (RefId == 0)

                ViewBag.RefId = new SelectList(refQuery, "RefId",
                                    "RefName", null);
            else
                ViewBag.RefId = new SelectList(refQuery, "RefId",
                                    "RefName", RefId);

            //Venues-------------------------------------------
            var venueQuery = from m in db.Venues
                           orderby m.VenueName
                           select m;

            if (VenueId == 0)

                ViewBag.VenueId = new SelectList(venueQuery, "VenueId",
                                    "VenueName", null);
            else
                ViewBag.RefId = new SelectList(venueQuery, "VenueId",
                                    "VenueName", VenueId);
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchId,LeagueId,VenueId,RefId,HomeTeamId,AwayTeamId,HomeGoals,AwayGoals,MatchDate")] Matches matches)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(matches);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matches);
        }

        // GET: Matches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matches matches = db.Matches.Find(id);
            if (matches == null)
            {
                return HttpNotFound();
            }
            return View(matches);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchId,LeagueId,VenueId,RefId,HomeTeamId,AwayTeamId,HomeGoals,AwayGoals,MatchDate")] Matches matches)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matches).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matches);
        }

        // GET: Matches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matches matches = db.Matches.Find(id);
            if (matches == null)
            {
                return HttpNotFound();
            }
            return View(matches);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matches matches = db.Matches.Find(id);
            db.Matches.Remove(matches);
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
