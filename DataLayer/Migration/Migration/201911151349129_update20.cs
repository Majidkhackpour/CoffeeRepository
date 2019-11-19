namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perssonels",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        DateSabt = c.String(maxLength: 15),
                        Code = c.String(maxLength: 10),
                        Name = c.String(),
                        Amount_AvalDore = c.Decimal(nullable: false, precision: 20, scale: 0),
                        Description = c.String(),
                        Pic = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        Mobile1 = c.String(),
                        Mobile2 = c.String(),
                        Address = c.String(),
                        Fax = c.String(),
                        PostalCode = c.String(maxLength: 20),
                        Email = c.String(),
                        Status = c.Boolean(nullable: false),
                        PerssonelCode = c.String(),
                        DateBirth = c.String(),
                        PlaceBirth = c.String(),
                        FatherName = c.String(),
                        NationalCode = c.String(),
                        PerssonelGroup = c.Guid(nullable: false),
                        Education = c.String(),
                        ContractCode = c.String(maxLength: 10),
                        ConStartDate = c.String(),
                        ConEndDate = c.String(),
                        ConTerm = c.Int(nullable: false),
                        ConStatus = c.Boolean(nullable: false),
                        HourInDay = c.Int(nullable: false),
                        StartHour = c.Int(nullable: false),
                        StartMin = c.Int(nullable: false),
                        EndHour = c.Int(nullable: false),
                        EndMin = c.Int(nullable: false),
                        HourPrice = c.Decimal(nullable: false, precision: 20, scale: 0),
                        HouseRight = c.Decimal(nullable: false, precision: 20, scale: 0),
                        ChildRight = c.Decimal(nullable: false, precision: 20, scale: 0),
                        BaseSallary = c.Decimal(nullable: false, precision: 20, scale: 0),
                        BenLaborer = c.Decimal(nullable: false, precision: 20, scale: 0),
                        OtherSallary = c.Decimal(nullable: false, precision: 20, scale: 0),
                        FullSallary = c.Decimal(nullable: false, precision: 20, scale: 0),
                        YearLeaving = c.Int(nullable: false),
                        KasrPrice = c.Decimal(nullable: false, precision: 20, scale: 0),
                        EzafePrice = c.Decimal(nullable: false, precision: 20, scale: 0),
                        Bime = c.Decimal(nullable: false, precision: 20, scale: 0),
                        Eydi = c.Decimal(nullable: false, precision: 20, scale: 0),
                        Gender = c.Int(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.PerssonelGroups",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        DateSabt = c.String(maxLength: 15),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.PhoneBooks",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        DateSabt = c.String(maxLength: 15),
                        Name = c.String(),
                        Description = c.String(),
                        Pic = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        Mobile1 = c.String(),
                        Mobile2 = c.String(),
                        Address = c.String(),
                        Fax = c.String(),
                        PostalCode = c.String(maxLength: 20),
                        Email = c.String(),
                        Status = c.Boolean(nullable: false),
                        ShabaCode = c.String(),
                        Type = c.Int(nullable: false),
                        HesabNumber1 = c.String(),
                        HesabNumber2 = c.String(),
                        CardNumber1 = c.String(),
                        CardNumber2 = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhoneBooks");
            DropTable("dbo.PerssonelGroups");
            DropTable("dbo.Perssonels");
        }
    }
}
