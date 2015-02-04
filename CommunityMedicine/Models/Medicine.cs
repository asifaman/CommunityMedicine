using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommunityMedicine.Models
{
    public class Medicine
    {
        public int MedicineId { set; get; }
        [Required]
        [Remote("MedicineCheck", "HeadOffice", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string GenericName { set; get; }
        public string MeasurementUnit { set; get; }
    }
}