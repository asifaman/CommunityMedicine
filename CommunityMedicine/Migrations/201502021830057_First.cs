namespace CommunityMedicine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        DiseaseId = c.Int(nullable: false, identity: true),
                        DiseaseName = c.String(),
                        DiseaseDescription = c.String(),
                        TreatmentProcedure = c.String(),
                        PreferDrug = c.String(),
                    })
                .PrimaryKey(t => t.DiseaseId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.Thanas",
                c => new
                    {
                        ThanaId = c.Int(nullable: false, identity: true),
                        ThanaName = c.String(),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThanaId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        GenericName = c.String(nullable: false),
                        MeasurementUnit = c.String(),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.NewCenters",
                c => new
                    {
                        NewCenterId = c.Int(nullable: false, identity: true),
                        CenterName = c.String(),
                        CenterDistric = c.String(),
                        Centerthana = c.String(),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewCenterId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.SendMedicines",
                c => new
                    {
                        SendMedicineId = c.Int(nullable: false, identity: true),
                        SendMedicineDistricId = c.String(),
                        SendMedicineThanaId = c.String(),
                        SendMedicineCenterId = c.String(),
                        SendMedicineName = c.String(),
                        SendMedicineQty = c.String(),
                    })
                .PrimaryKey(t => t.SendMedicineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewCenters", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Thanas", "DistrictId", "dbo.Districts");
            DropIndex("dbo.NewCenters", new[] { "DistrictId" });
            DropIndex("dbo.Thanas", new[] { "DistrictId" });
            DropTable("dbo.SendMedicines");
            DropTable("dbo.NewCenters");
            DropTable("dbo.Medicines");
            DropTable("dbo.Thanas");
            DropTable("dbo.Districts");
            DropTable("dbo.Diseases");
        }
    }
}
