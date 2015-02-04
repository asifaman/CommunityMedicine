using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class NewCenter
    {
        public int NewCenterId { set; get; }
        public string CenterName { set; get; }
        public string CenterDistric { set; get; }
        public string Centerthana { set; get; }
        public int DistrictId { set; get; }
        public virtual District District { set; get; }
    }
}