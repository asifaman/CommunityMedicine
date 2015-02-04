using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class District
    {
        public int DistrictId { set; get; }
        public string DistrictName { set; get; }
        public virtual ICollection<Thana> Thana { set; get; } 
       
    }
}