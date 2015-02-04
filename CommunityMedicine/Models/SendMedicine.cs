using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class SendMedicine
    {
        public int SendMedicineId { set; get; }
        public string SendMedicineDistricId { set; get; }
        public string SendMedicineThanaId { set; get; }
        public string SendMedicineCenterId { set; get; }
        public string SendMedicineName { set; get; }
        public string SendMedicineQty { set; get; }
    }
}