using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fall2015.Models;

namespace Fall2015.Controllers
{
    public class CompetencyHeadersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompetencyHeaders
        public ActionResult Index()
        {
            return View(db.CompetencyHeaders.ToList());
        }

        // GET: CompetencyHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyHeader competencyHeader = db.CompetencyHeaders.Find(id);
            if (competencyHeader == null)
            {
                return HttpNotFound();
            }
            return View(competencyHeader);
        }

        // GET: CompetencyHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompetencyHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetencyHeaderId,Name")] CompetencyHeader competencyHeader)
        {
            if (ModelState.IsValid)
            {
                db.CompetencyHeaders.Add(competencyHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competencyHeader);
        }

        // GET: CompetencyHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyHeader competencyHeader = db.CompetencyHeaders.Find(id);
            if (competencyHeader == null)
            {
                return HttpNotFound();
            }
            return View(competencyHeader);
        }

        // POST: CompetencyHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyHeaderId,Name")] CompetencyHeader competencyHeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencyHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competencyHeader);
        }

        // GET: CompetencyHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyHeader competencyHeader = db.CompetencyHeaders.Find(id);
            if (competencyHeader == null)
            {
                return HttpNotFound();
            }
            return View(competencyHeader);
        }

        // POST: CompetencyHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetencyHeader competencyHeader = db.CompetencyHeaders.Find(id);
            db.CompetencyHeaders.Remove(competencyHeader);
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
