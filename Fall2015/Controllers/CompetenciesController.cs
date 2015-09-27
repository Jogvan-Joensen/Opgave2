using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fall2015.Models;
using Fall2015.Repositories;


namespace Fall2015.Controllers
{
    public class CompetenciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        CompedencyReposatory comp = new CompedencyReposatory();

        // GET: Competencies
        public ActionResult Index()
        {
            List<Competency> c = comp.All.ToList();
            /*var compedency = db.Competency.Include(c => c.CompetencyHeader);*/
            return View(c);
        }

        // GET: Competencies/Details/5
        public ActionResult Details(int? id) //int? betyder at det også kan være null
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = db.Competency.Find(id);
            if (competency == null)
            {
                return HttpNotFound();
            }
            return View(competency);
        }

        // GET: Competencies/Create
        public ActionResult Create()
        {
            ViewBag.CompetencyHeaderId = new SelectList(db.CompetencyHeaders, "CompetencyHeaderId", "Name");
            return View();
        }

        // POST: Competencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetencyId,Name,CompetencyHeaderId")] Competency competency)
        {
            if (ModelState.IsValid)
            {
                db.Competency.Add(competency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetencyHeaderId = new SelectList(db.CompetencyHeaders, "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);//drop down schite
            return View(competency);
        }

        // GET: Competencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = db.Competency.Find(id);
            if (competency == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetencyHeaderId = new SelectList(db.CompetencyHeaders, "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);
            return View(competency);
        }

        // POST: Competencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyId,Name,CompetencyHeaderId")] Competency competency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetencyHeaderId = new SelectList(db.CompetencyHeaders, "CompetencyHeaderId", "Name", competency.CompetencyHeaderId);
            return View(competency);
        }

        // GET: Competencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competency competency = db.Competency.Find(id);
            if (competency == null)
            {
                return HttpNotFound();
            }
            return View(competency);
        }

        // POST: Competencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competency competency = db.Competency.Find(id);
            db.Competency.Remove(competency);
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
