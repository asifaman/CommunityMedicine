using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class SendMedicine
    {
        public int SendMedicineId { set; get; }
        [Required]
        public int Quantity { set; get; }
        [Required]
        public int NewCenterId { set; get; }
        [Required]
        public string MedicineId { set; get; }
        
    }
}