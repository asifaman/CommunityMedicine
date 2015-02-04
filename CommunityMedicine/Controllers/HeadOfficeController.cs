using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CommunityMedicine.Models;

namespace CommunityMedicine.Controllers
{
    public class HeadOfficeController : Controller
    {
        private Gateway db = new Gateway();

        // GET: HeadOffice
        public ActionResult Index()
        {
            return View(db.Medicine.ToList());
        }

        // GET: HeadOffice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicine.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        public ActionResult Medicine()
        {
            return View(db.Medicine.ToList());
        }
        public ActionResult InsertMedicine(string genericname, string measurementunit)
        {
            Medicine aMedicine = new Medicine() { GenericName = genericname, MeasurementUnit = measurementunit };
            var Medicine = db.Medicine.AsEnumerable();
            var nameCheck = from n in db.Medicine select new {n.GenericName};
            
           
                db.Medicine.Add(aMedicine);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
           
            
        }

        public ActionResult Disease()
        {
            return View(db.Disease.ToList());
        }
        [HttpPost]
        public ActionResult InsertDisease(string diseasename, string description, string treatment, string preferdrug)
        {
            Disease aDisease = new Disease()
            {
                DiseaseName = diseasename,
                DiseaseDescription = description,
                TreatmentProcedure = treatment,
                PreferDrug = preferdrug
            };
            db.Disease.Add(aDisease);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        //// GET: HeadOffice/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: HeadOffice/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MedicineId,GenericName,MeasurementUnit")] Medicine medicine)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Medicine.Add(medicine);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(medicine);
        //}

        // GET: HeadOffice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicine.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: HeadOffice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicineId,GenericName,MeasurementUnit")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicine);
        }

        // GET: HeadOffice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicine medicine = db.Medicine.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: HeadOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicine medicine = db.Medicine.Find(id);
            db.Medicine.Remove(medicine);
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
        [HttpPost]
        public JsonResult MedicineCheck(string genericname)
        {
            var genericName = Membership.GetUser(genericname);
            //var measurementUnit = Membership.GetUser(measurementunit);

            return Json(genericName == null );
        }


        public ActionResult NewCenter()
        {
            ViewBag.DistrictId = new SelectList(db.District, "DistrictId", "DistrictName");
            return View();
        }

        // POST: Thanas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCenter([Bind(Include = "CenterId,CenterName,Thananame, DistrictId")] NewCenter newCenter)
        {
            if (ModelState.IsValid)
            {
                db.NewCenter.Add(newCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.District, "DistrictId", "DistrictName", newCenter.DistrictId);
            return View(newCenter);
        }

        public ActionResult FindThana(string districtId)
        {
            int destrictID = Convert.ToInt32(districtId);
            var district = db.Thana.Where(x => x.ThanaId == destrictID).ToList();
            return Json(district, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SendMedicine()
        {
            return View();
        }

        public ActionResult PDF()
        {
            var newcenter = db.NewCenter;
            var lastcenter = newcenter.OrderByDescending(n => n.CenterName).Take(1);
            //return new Rotativa.UrlAsPdf("http://www.Google.com") { FileName = "UrlTest.pdf" };
            return new Rotativa.ViewAsPdf("newcenter", lastcenter) {FileName = "TestViewAsPdf.pdf"};
        }
    }
}
