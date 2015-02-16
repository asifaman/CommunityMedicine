using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class Disease
    {
        public int DiseaseId { set; get; }
        [Required]
        public string DiseaseName { set; get; }
        [Required]
        public string DiseaseDescription { set; get; }
        [Required]
        public string TreatmentProcedure { set; get; }
        [Required]
        public string PreferDrug { set; get; }
    }
}