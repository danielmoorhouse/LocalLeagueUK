using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocalLeague1.Models;

namespace LocalLeague1.Controllers
{
    public class LeagueOpsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: LeagueOps
        public ActionResult Index()
        {
            return View(db.LeagueOps.ToList());
        }

        // GET: LeagueOps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeagueOps leagueOps = db.LeagueOps.Find(id);
            if (leagueOps == null)
            {
                return HttpNotFound();
            }
            return View(leagueOps);
        }

        // GET: LeagueOps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeagueOps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeagueOpsId,LeagueOpsName,LeagueOpsLogoUrl")] LeagueOps leagueOps,
                                 HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (upload.ContentType == "image/jpeg" ||
                        upload.ContentType == "image/jpg" ||
                        upload.ContentType == "image/gif" ||
                        upload.ContentType == "image/png")
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/Images"),
                                      Path.GetFileName(upload.FileName));

                        upload.SaveAs(path);

                        leagueOps.LeagueOpsLogoUrl = "~/Content/Images/" +
                            Path.GetFileName(upload.FileName);
                    }
                    else
                    {
                        ViewBag.Message = "Not Valid Image Format";
                    }
                }
                db.LeagueOps.Add(leagueOps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leagueOps);
        }

        // GET: LeagueOps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeagueOps leagueOps = db.LeagueOps.Find(id);
            if (leagueOps == null)
            {
                return HttpNotFound();
            }
            return View(leagueOps);
        }

        // POST: LeagueOps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeagueOpsId,LeagueOpsName,LeagueOpsLogoUrl")] LeagueOps leagueOps,
                                 HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (upload.ContentType == "image/jpeg" ||
                        upload.ContentType == "image/jpg" ||
                        upload.ContentType == "image/gif" ||
                        upload.ContentType == "image/png")
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/Images"),
                                      Path.GetFileName(upload.FileName));

                        upload.SaveAs(path);

                        leagueOps.LeagueOpsLogoUrl = "~/Content/Images/" +
                            Path.GetFileName(upload.FileName);
                    }
                    else
                    {
                        ViewBag.Message = "Not Valid Image Format";
                    }
                }
                db.Entry(leagueOps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leagueOps);
        }

        // GET: LeagueOps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeagueOps leagueOps = db.LeagueOps.Find(id);
            if (leagueOps == null)
            {
                return HttpNotFound();
            }
            return View(leagueOps);
        }

        // POST: LeagueOps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeagueOps leagueOps = db.LeagueOps.Find(id);
            db.LeagueOps.Remove(leagueOps);
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
