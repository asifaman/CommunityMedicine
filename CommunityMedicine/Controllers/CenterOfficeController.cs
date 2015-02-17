using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml;
using CommunityMedicine.Models;

namespace CommunityMedicine.Controllers
{
    public class CenterOfficeController : Controller
    {
        private Gateway db = new Gateway();
        private string voterIds;
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
        public ActionResult Create([Bind(Include = "DoctorEntryId,Name,Degree,Specialization,CenterId")] DoctorEntry doctorEntry)
        {
           
                NewCenter aCenter = (NewCenter) base.Session["NewCenter"];

                var centerCode = aCenter.CenterCode;
           
            if (ModelState.IsValid)
            {
                doctorEntry.CenterId = centerCode;
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

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CenterReport(NewCenter aNewCenter)
        {
            base.Session["NewCenter"] = aNewCenter;


            var Code = aNewCenter.CenterCode;
            var Passwords = aNewCenter.Password;
            var CenterId = db.NewCenter.Where(i => i.Password == Passwords && i.CenterCode == Code).ToList();
            foreach (var Item in CenterId)
            {
                var id = Item.NewCenterId;
                ViewBag.center = db.SendMedicine.Where(x => x.NewCenterId == id).ToList();

            }
            return View();
        }

        public ActionResult PatientTreatMent()
        {
            NewCenter aCenter = (NewCenter)base.Session["NewCenter"];

            var centerCode = aCenter.CenterCode;
            ViewBag.Doctor = db.DoctorEntrie.Where(x => x.CenterId == centerCode).ToList();
         
            ViewBag.Disease = new List<Disease>(db.Disease);
            var medicine = db.NewCenter.Where(x => x.CenterCode == centerCode);
            foreach (var item in medicine)
            {
                var id = item.NewCenterId;
                var centerid = db.SendMedicine.Where(x => x.NewCenterId == id).ToList();
                foreach (var items in centerid)
                {
                    var ids = items.MedicineId;
                    ViewBag.Medicine = ids;
                }
            }
            ViewBag.Dose = new List<Dose>(db.Dose);
            return View();
        }
        [HttpPost]
        public ActionResult PatientTreatMent(List<Treatment> json)
        {
            foreach (Treatment treatment in json)
            {
                db.Treatment.Add(treatment);
                db.SaveChanges();
            }

            Treatment aTreatment = new Treatment();
            var servicetime = aTreatment.VoterId;
            ViewBag.ServiceTime = db.Treatment.Count(x => x.VoterId == servicetime);

            return View();
        }
       

        public ActionResult GetVoterFromWebService(string voterid)
        {
            voterIds = voterid;
            string uri = "http://nerdcastlebd.com/web_service/voterdb/index.php/voters/voter/" + voterid + "";

            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());
            XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes("voter");
            Treatment aVoter = new Treatment();
            DateTime Birth = new DateTime();
            foreach (XmlNode node in nodes)
            {
                aVoter.VoterId = node.SelectSingleNode("id").InnerText;
                aVoter.Name = node.SelectSingleNode("name").InnerText;
                aVoter.Address = node.SelectSingleNode("address").InnerText;
                aVoter.age = node.SelectSingleNode("date_of_birth").InnerText;
                Birth = new DateTime(1954, 7, 30);
            }
            var service = db.Treatment.Count(x => x.VoterId == voterid);
            aVoter.Treatmentcount = service;

           
            DateTime Today = DateTime.Now;
            TimeSpan Span = Today - Birth;
            DateTime Age = DateTime.MinValue + Span;
            int Years = Age.Year - 1;
            aVoter.age = Years.ToString();
            return Json(aVoter, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDistrict()
        {
            Treatment aTreatment = new Treatment();
            NewCenter aCenter = (NewCenter)base.Session["NewCenter"];

            var centerCode = aCenter.CenterCode;
            aTreatment.CenterCode = centerCode.ToString();

            var cName = db.NewCenter.Where(x => x.CenterCode == centerCode);
            foreach (var Cname in cName)
            {
                var CName = Cname.CenterName;
                aTreatment.Center = CName;
            }

            var cDistrictID = db.NewCenter.Where(x => x.CenterCode == centerCode);
            foreach (var cdistrict in cDistrictID)
            {
                var Id = cdistrict.CenterDistricId;
                var selectDistrict = db.District.Where(x => x.DistrictId == Id);
                foreach (var id in selectDistrict)
                {
                    var districtId = id.DistrictName;
                    aTreatment.District = districtId;
                }
            }

            return Json(aTreatment, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCenter(string Cvoterid)
        {
            var VoterInfo = db.Treatment.Where(x => x.VoterId == Cvoterid).ToList();

            return Json(VoterInfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DiseaseWiseReport()
        {
            //ViewBag.DisrictName = db.Treatment.ToList();
            //ViewBag.diseasecount = db.Treatment.ToList();
            ViewBag.Disease = new List<Disease>(db.Disease).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult DiseaseWiseReport(string date, string date2, string disease)
        {

            var district = db.Treatment.Where(x => x.DiseaseName == disease).Select(x => x.District).Distinct().ToList();
            ViewBag.DisrictName = district;
            double num = (double)100/1000;
            foreach (var d in district)
            {
                var count = db.Treatment.Count(x => x.DiseaseName == disease && x.District == d);
                ViewBag.diseasecount = count;
                
                ViewBag.Total = count*num;
            }

            //ViewBag.DisrictName = district.Select(x => x.District).ToList();


            ViewBag.Disease = new List<Disease>(db.Disease);
            return View();
        }

        //public ActionResult GetCenterReport(string Disease)
        //{
        //    //var district = db.Treatment.Where(x => x.DiseaseName == Disease).Select(x => x.District).Distinct().ToList();
        //    //var pateantcount = db.Treatment.Count(x => x.District == district.First());
        //    //var allinfo = district.Concat(pateantcount);
        //    //var district = districtname.Select(x => x.District.Distinct());
        //    var district = db.Treatment.Where(x => x.DiseaseName == Disease).Select(x => x.District).Distinct().ToList();
        //    var count = db.Treatment.Count(x => x.DiseaseName == Disease);
        //    var alll = district.Concat<string>(second: count.ToString());
        //    return Json(district, JsonRequestBehavior.AllowGet);
        //}
    }
}
