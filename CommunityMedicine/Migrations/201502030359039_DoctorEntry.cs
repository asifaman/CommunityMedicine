namespace CommunityMedicine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorEntry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorEntries",
                c => new
                    {
                        DoctorEntryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Degree = c.String(),
                        Specialization = c.String(),
                    })
                .PrimaryKey(t => t.DoctorEntryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DoctorEntries");
        }
    }
}
