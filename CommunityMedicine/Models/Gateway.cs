using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CommunityMedicine.Models
{
    public class Gateway:DbContext
    {
        public Gateway():base("CMDB")
        {
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Disease> Disease { set; get; }
        public DbSet<Medicine> Medicine { set; get; }
        public DbSet<NewCenter> NewCenter { set; get; }
        public DbSet<SendMedicine> SendMedicine { set; get; }
        public DbSet<District> District { set; get; }
        public DbSet<Thana> Thana { set; get; }
        public DbSet<DoctorEntry> DoctorEntrie { set; get; } 
    }
}