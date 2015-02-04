using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class Thana
    {
        public int ThanaId { set; get; }
        public string ThanaName { set; get; }
        public int DistrictId { set; get; }
        public virtual District District { set; get; }
    }
}