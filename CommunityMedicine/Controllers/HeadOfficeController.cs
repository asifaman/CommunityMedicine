using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Xml;
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
        public ActionResult Medicine()
        {
            ViewBag.MeasurementUnit = new List<MeasurementUnit>(db.MeasurementUnit);
            return View();
        }

        // POST: HeadOffice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Medicine([Bind(Include = "MedicineId, GenericName, MeasurementUnit, Power")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Medicine.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicine);
        }
        public ActionResult InsertMedicine(string genericname, string measurementunit)
        {
            Medicine aMedicine = new Medicine() { GenericName = genericname, MeasurementUnit = measurementunit };
            var Medicine = db.Medicine.AsEnumerable();
            var nameCheck = from n in db.Medicine select new { n.GenericName };


            db.Medicine.Add(aMedicine);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Disease()
        {
            return View(db.Disease.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disease([Bind(Include = "DiseaseId, DiseaseName, DiseaseDescription, TreatmentProcedure,PreferDrug")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                db.Disease.Add(disease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disease);
        }
       
        public ActionResult MedicineCheck(string genericname, string unit)
        {
            var genericName = db.Medicine.FirstOrDefault(x => x.GenericName == genericname );
            //var Unit = db.Medicine.FirstOrDefault(x => x.MeasurementUnit == unit);

            if (genericName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult NewCenter()
        {
            ViewBag.CenterDistricId = new SelectList(db.District, "DistrictId", "DistrictName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCenter([Bind(Include = "CenterthanaId, CenterName, CenterDistricId, CenterCode, Password")] NewCenter aCenter)
        {
            if (ModelState.IsValid)
            {
                db.NewCenter.Add(aCenter);
                db.SaveChanges();
                return RedirectToAction("PDF");
            }

            //   ViewBag.DistrictId = new SelectList(db.District, "DistrictId", "DistrictName", thana.ThanaId);
            //     return View(thana);
            return RedirectToAction("NewCenter");
        }

        public ActionResult FindThana(string DistrictId)
        {
            int destrictID = Convert.ToInt32(DistrictId);
            var district = db.Thana.Where(t => t.DistrictId == destrictID).ToList();
            return Json(district, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SendMedicine()
        {

            ViewBag.DistrictID = new List<District>(db.District);
            ViewBag.MedicineID = new List<Medicine>(db.Medicine);
            ViewBag.DistrictId = new SelectList(db.District, "DistrictId", "DistrictName");
            ViewBag.Selectmedicine = db.Medicine.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult SendMedicine(ICollection<SendMedicine> json)
        {

            foreach (SendMedicine medicineClinic in json)
            {
                db.SendMedicine.Add(medicineClinic);
                db.SaveChanges();
            }

            ViewBag.DistrictID = new List<District>(db.District);
            ViewBag.MedicineID = new List<Medicine>(db.Medicine);

            return View();



        }

        public ActionResult FindCenter(string ThanaId)
        {
            int thanaId = Convert.ToInt32(ThanaId);
            var district = db.NewCenter.Where(t => t.CenterthanaId == thanaId).ToList();
            return Json(district, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindMedicine()
        {
            var district = db.Medicine.Select(t => t.GenericName).ToList();
            return Json(district, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PDF()
        {
            ViewBag.name = (from t in db.NewCenter
                            orderby t.NewCenterId descending
                            select t.CenterName).First();

            ViewBag.center= (from t in db.NewCenter
                        orderby t.NewCenterId descending
                        select t.CenterCode).First();
            ViewBag.password = (from t in db.NewCenter
                                orderby t.NewCenterId descending
                                select t.Password).First();
            return View();
        }
       

        public ActionResult Map()
        {
            ViewBag.Disease = new List<Disease>(db.Disease);

         
            return View();
        }

        [HttpPost]

        public ActionResult Map(string date, string date2, string disease)
        {
            ViewBag.fromdate = date;
            ViewBag.todate = date2;
            ViewBag.dname = disease;
            //var datecount = from d in db.Treatment where (Convert.ToInt16(d.Date = date) < Convert.ToInt16(d.Date = date2)) select d;
            //var datecount = from r in db.Treatment
            //                where r.Date >= new DateTime(date) && r.Date <= new DateTime(date2)
            //                select r;
            ViewBag.dhaka = db.Treatment.Count(x => x.DiseaseName == disease && x.District == "Dhaka");
            ViewBag.khulna = db.Treatment.Count(x => x.DiseaseName == disease && x.District == "Patuakhali");
            //ViewBag.chittagong = db.Treatment.Count(x => x.DiseaseName == disease && x.District == 3);
            //ViewBag.barisal = db.Treatment.Count(x => x.DiseaseName == disease && x.District == 4);
            //ViewBag.rajshahi = db.Treatment.Count(x => x.DiseaseName == disease && x.District == 5);
            //ViewBag.rangpur = db.Treatment.Count(x => x.DiseaseName == disease && x.District == 6);
            //ViewBag.sylhet = db.Treatment.Count(x => x.DiseaseName == disease && x.District == 7);


            ViewBag.Disease = new List<Disease>(db.Disease);

          
            return View();
        }

        public ActionResult BarChart()
        {
            ViewBag.District = new List<District>(db.District);
            return View();
        }

        [HttpPost]

        public ActionResult BarChart(string date, string date2, int district)
        {
            ViewBag.fromdate = date;
            ViewBag.todate = date2;
            string districtid = Convert.ToString(district);
            ViewBag.districtname = db.District.Select(x => x.DistrictName == districtid);

            //var datecount = from d in db.Treatment where (Convert.ToInt16(d.Date = date) < Convert.ToInt16(d.Date = date2)) select d;
            //var datecount = from r in db.Treatment
            //                where r.Date >= new DateTime(date) && r.Date <= new DateTime(date2)
            //                select r;
            //ViewBag.malaria = db.Treatment.Count(x => x.District== district && x.DiseaseName=="Malaria");
            //ViewBag.fever = db.Treatment.Count(x => x.District == district && x.DiseaseName == "Fever");



            ViewBag.District = new List<District>(db.District);


            return View();
        }

    }
}
