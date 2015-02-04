using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class Disease
    {
        public int DiseaseId { set; get; }
        public string DiseaseName { set; get; }
        public string DiseaseDescription { set; get; }
        public string TreatmentProcedure { set; get; }
        public string PreferDrug { set; get; }
    }
}