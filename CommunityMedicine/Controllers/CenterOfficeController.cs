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
    public class CenterOfficeController : Controller
    {
        private Gateway db = new Gateway();

        public ActionResult Index()
        {
            return View(db.DoctorEntrie.ToList());
        }
        // GET: DoctorEntries
        public ActionResult DoctorView()
        {
            return View(db.DoctorEntrie.ToList());
        }

        // GET: DoctorEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorEntry doctorEntry = db.DoctorEntrie.Find(id);
            if (doctorEntry == null)
            {
                return HttpNotFound();
            }
            return View(doctorEntry);
        }

        // GET: DoctorEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorEntryId,Name,Degree,Specialization")] DoctorEntry doctorEntry)
        {
            if (ModelState.IsValid)
            {
                db.DoctorEntrie.Add(doctorEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorEntry);
        }

        // GET: DoctorEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorEntry doctorEntry = db.DoctorEntrie.Find(id);
            if (doctorEntry == null)
            {
                return HttpNotFound();
            }
            return View(doctorEntry);
        }

        // POST: DoctorEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorEntryId,Name,Degree,Specialization")] DoctorEntry doctorEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorEntry);
        }

        // GET: DoctorEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorEntry doctorEntry = db.DoctorEntrie.Find(id);
            if (doctorEntry == null)
            {
                return HttpNotFound();
            }
            return View(doctorEntry);
        }

        // POST: DoctorEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorEntry doctorEntry = db.DoctorEntrie.Find(id);
            db.DoctorEntrie.Remove(doctorEntry);
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
