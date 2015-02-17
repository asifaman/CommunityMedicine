using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class NewCenter
    {
            [Key, Column(Order = 0)]

            public int NewCenterId { set; get; }
            [Required]
            public string CenterName { set; get; }
            [Required]
            public int CenterDistricId { set; get; }
            [Required]
            public int CenterthanaId { set; get; }
            public int CenterCode { set; get; }
            public int Password { set; get; }
        
    }
}