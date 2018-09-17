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
    public class ClubsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Clubs
        public ActionResult Index()
        {
            return View(db.Clubs.ToList());
        }

        // GET: Clubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubs clubs = db.Clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClubId,ClubName,ClubAddress1," +
            "ClubAddress2,PostCode,ClubLogoUrl")] Clubs clubs, 
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

                        clubs.ClubLogoUrl = "~/Content/Images/" +
                            Path.GetFileName(upload.FileName);
                    }
                    else
                    {
                        ViewBag.Message = "Not Valid Image Format";
                    }
                }
                db.Clubs.Add(clubs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clubs);
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubs clubs = db.Clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
   
                public ActionResult Edit([Bind(Include = "ClubId,ClubName,ClubAddress1," +
            "ClubAddress2,PostCode,ClubLogoUrl")] Clubs clubs,
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

                                clubs.ClubLogoUrl = "~/Content/Images/" +
                                    Path.GetFileName(upload.FileName);
                            }
                            else
                            {
                                ViewBag.Message = "Not Valid Image Format";
                            }
                        }
                        db.Entry(clubs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clubs);
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clubs clubs = db.Clubs.Find(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clubs clubs = db.Clubs.Find(id);
            db.Clubs.Remove(clubs);
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
