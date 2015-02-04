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
    public class ThanasController : Controller
    {
        private Gateway db = new Gateway();

        // GET: Thanas
        public ActionResult Index()
        {
            var thana = db.Thana.Include(t => t.District);
            return View(thana.ToList());
        }

        // GET: Thanas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thana thana = db.Thana.Find(id);
            if (thana == null)
            {
                return HttpNotFound();
            }
            return View(thana);
        }

        // GET: Thanas/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.District, "DistrictId", "DistrictName");
            return View();
        }

        // POST: Thanas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThanaId,ThanaName,DistrictId")] Thana thana)
        {
            if (ModelState.IsValid)
            {
                db.Thana.Add(thana);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.District, "DistrictId", "DistrictName", thana.DistrictId);
            return View(thana);
        }

        // GET: Thanas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thana thana = db.Thana.Find(id);
            if (thana == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.District, "DistrictId", "DistrictName", thana.DistrictId);
            return View(thana);
        }

        // POST: Thanas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThanaId,ThanaName,DistrictId")] Thana thana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thana).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.District, "DistrictId", "DistrictName", thana.DistrictId);
            return View(thana);
        }

        // GET: Thanas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thana thana = db.Thana.Find(id);
            if (thana == null)
            {
                return HttpNotFound();
            }
            return View(thana);
        }

        // POST: Thanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thana thana = db.Thana.Find(id);
            db.Thana.Remove(thana);
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
