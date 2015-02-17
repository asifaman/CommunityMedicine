using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommunityMedicine.Models;

namespace CommunityMedicine.Controllers
{
    public class DiseasesController : Controller
    {
        private Gateway db = new Gateway();

        // GET: Diseases
        public ActionResult Index()
        {
            return View(db.Disease.ToList());
        }

        // GET: Diseases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disease disease = db.Disease.Find(id);
            if (disease == null)
            {
                return HttpNotFound();
            }
            return View(disease);
        }

        // GET: Diseases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diseases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiseaseId,DiseaseName,DiseaseDescription,TreatmentProcedure,PreferDrug")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                db.Disease.Add(disease);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(disease);
        }

        // GET: Diseases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disease disease = db.Disease.Find(id);
            if (disease == null)
            {
                return HttpNotFound();
            }
            return View(disease);
        }

        // POST: Diseases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiseaseId,DiseaseName,DiseaseDescription,TreatmentProcedure,PreferDrug")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disease);
        }

        // GET: Diseases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disease disease = db.Disease.Find(id);
            if (disease == null)
            {
                return HttpNotFound();
            }
            return View(disease);
        }

        // POST: Diseases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disease disease = db.Disease.Find(id);
            db.Disease.Remove(disease);
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
