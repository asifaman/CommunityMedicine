using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class Treatment
    {
        public int TreatmentId { set; get; }

        public string VoterId { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string age { set; get; }
        public string Center { set; get; }
        public string CenterCode { set; get; }
        public int Treatmentcount { set; get; }
        public string Observation { set; get; }
        public string Date { set; get; }
        public string DoctorName { set; get; }
        public string DiseaseName { set; get; }
        public string MedicineName { set; get; }
       
        public string Dose { set; get; }
        public string Meal { set; get; }
        public string QuantityGiver { set; get; }
        public string Note { set; get; }
        public string District { set; get; }
    }
}