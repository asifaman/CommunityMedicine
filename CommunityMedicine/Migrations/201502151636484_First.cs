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
                        DiseaseName = c.String(nullable: false),
                        DiseaseDescription = c.String(nullable: false),
                        TreatmentProcedure = c.String(nullable: false),
                        PreferDrug = c.String(nullable: false),
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
                "dbo.DoctorEntries",
                c => new
                    {
                        DoctorEntryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Degree = c.String(nullable: false),
                        Specialization = c.String(nullable: false),
                        CenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorEntryId);
            
            CreateTable(
                "dbo.Doses",
                c => new
                    {
                        DoseId = c.Int(nullable: false, identity: true),
                        DoseName = c.String(),
                    })
                .PrimaryKey(t => t.DoseId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginId = c.String(nullable: false, maxLength: 128),
                        CenterCode = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            CreateTable(
                "dbo.MeasurementUnits",
                c => new
                    {
                        MeasurementUnitId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MeasurementUnitId);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        GenericName = c.String(nullable: false),
                        MeasurementUnit = c.String(nullable: false, maxLength: 3),
                        Power = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineId);
            
            CreateTable(
                "dbo.NewCenters",
                c => new
                    {
                        NewCenterId = c.Int(nullable: false, identity: true),
                        CenterName = c.String(nullable: false),
                        CenterDistricId = c.Int(nullable: false),
                        CenterthanaId = c.Int(nullable: false),
                        CenterCode = c.Int(nullable: false),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewCenterId);
            
            CreateTable(
                "dbo.SendMedicines",
                c => new
                    {
                        SendMedicineId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        NewCenterId = c.Int(nullable: false),
                        MedicineId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SendMedicineId);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatmentId = c.Int(nullable: false, identity: true),
                        VoterId = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        age = c.String(),
                        Center = c.String(),
                        CenterCode = c.String(),
                        Treatmentcount = c.Int(nullable: false),
                        Observation = c.String(),
                        Date = c.String(),
                        DoctorName = c.String(),
                        DiseaseName = c.String(),
                        MedicineName = c.String(),
                        Dose = c.String(),
                        Meal = c.String(),
                        QuantityGiver = c.String(),
                        Note = c.String(),
                        District = c.String(),
                    })
                .PrimaryKey(t => t.TreatmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thanas", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Thanas", new[] { "DistrictId" });
            DropTable("dbo.Treatments");
            DropTable("dbo.SendMedicines");
            DropTable("dbo.NewCenters");
            DropTable("dbo.Medicines");
            DropTable("dbo.MeasurementUnits");
            DropTable("dbo.Logins");
            DropTable("dbo.Doses");
            DropTable("dbo.DoctorEntries");
            DropTable("dbo.Thanas");
            DropTable("dbo.Districts");
            DropTable("dbo.Diseases");
        }
    }
}
