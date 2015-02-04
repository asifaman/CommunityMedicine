using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class DoctorEntry
    {
        public int DoctorEntryId { set; get; }
        public string Name { set; get; }
        public string Degree { set; get; }
        public string Specialization { set; get; }
    }
}