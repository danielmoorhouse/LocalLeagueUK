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
    public class TeamsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Teams
        public List<Teams> GetTeams()
        {
            return db.Teams.ToList();

        }
        public List<Players> GetPlayers()
        {
            return db.Players.ToList();
        }
        
            public ActionResult Index()
        {
            List<TeamViewModel> TeamList =
                new List<TeamViewModel>();

            List<Teams> teams;

            teams = db.Teams.ToList();
            foreach (Teams t in teams)
            {
                Clubs clubs = db.Clubs.Where(x => x.ClubId == t.ClubId).Single();

                Leagues leagues = db.Leagues.Where(x => x.LeagueId == t.LeagueId).Single();

                TeamViewModel toAdd = new TeamViewModel();

                toAdd.Teams = t;
                toAdd.Clubs = clubs;
                toAdd.Leagues = leagues;

                TeamList.Add(toAdd);

            }


            return View(TeamList);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teams teams = db.Teams.Find(id);
            if(teams == null)
            {
                return HttpNotFound();
            }

            TeamProfViewModel TeamProf =
              new TeamProfViewModel();

            TeamProf.Teams = db.Teams.Where(x => x.TeamId == teams.TeamId).Single();
            TeamProf.Leagues = db.Leagues.Where(x => x.LeagueId == teams.LeagueId).Single();
          
            TeamProf.Clubs = db.Clubs.Where(x => x.ClubId == teams.ClubId).Single();

            TeamProf.Matches = db.Matches.Where(x => x.HomeTeamId == teams.TeamId).FirstOrDefault();

           
            
            
            
            

         
            return View(TeamProf);
        }

        // GET: Teams/Create
        public ActionResult Create(int ClubId = 0, int LeagueId = 0)
        {
            //Clubs
            var clubQuery = from m in db.Clubs
                            orderby m.ClubName
                            select m;
            if (ClubId == 0)
                ViewBag.ClubId = new SelectList(clubQuery, "ClubId",
                                            "ClubName", null);
            else
                ViewBag.ClubId = new SelectList(clubQuery, "ClubId",
                                                "ClubName", ClubId);
            //League
            var leagueQuery = from m in db.Leagues
                            orderby m.LeagueName
                            select m;
            if (LeagueId == 0)
                ViewBag.LeagueId = new SelectList(leagueQuery, "LeagueId",
                                            "LeagueName", null);
            else
                ViewBag.LeagueId = new SelectList(leagueQuery, "LeagueId",
                                                "LeagueName", LeagueId);
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,LeagueId,ClubId,TeamName,Coach1,Coach2,Coach3,Player1,Player2,Player3,Player4,Player5,Player6,Player7,Player8,Player9,Player10,Player11,Player12,Player13,Player14,Player15")] Teams teams)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(teams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teams);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }
            return View(teams);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,LeagueId,ClubId,TeamName,Coach1,Coach2,Coach3,Player1,Player2,Player3,Player4,Player5,Player6,Player7,Player8,Player9,Player10,Player11,Player12,Player13,Player14,Player15")] Teams teams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teams);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }
            return View(teams);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teams teams = db.Teams.Find(id);
            db.Teams.Remove(teams);
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
