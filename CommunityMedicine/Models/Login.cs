using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class Login
    {
        public string LoginId { set; get; }
        public string CenterCode { set; get; }
        public string Password { set; get; }
    }
}