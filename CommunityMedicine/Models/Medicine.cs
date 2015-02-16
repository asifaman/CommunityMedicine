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
        [Remote("MedicineCheck", "HeadOffice", HttpMethod = "POST", ErrorMessage = "The Medicine already exists. Please enter a different Medicine name.")]
        public string GenericName { set; get; }
        [Required]
        [StringLength(3, ErrorMessage = "Max 3 digits")]
        //[Remote("MedicineCheck", "HeadOffice", HttpMethod = "POST", ErrorMessage = "The Medicine Unit already exists.")]
        public string MeasurementUnit { set; get; }
        [Required]
        public string Power { set; get; }
    }
}