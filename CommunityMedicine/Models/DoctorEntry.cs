using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class DoctorEntry
    {
        public int DoctorEntryId { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Degree { set; get; }
        [Required]
        public string Specialization { set; get; }
        public int CenterId { set; get; }
    }
}