namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        DateSabt = c.String(maxLength: 15),
                        Code = c.String(maxLength: 10),
                        Half_Code = c.String(maxLength: 10),
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
                        GroupGuid = c.Guid(nullable: false),
                        HesabNumber1 = c.String(),
                        HesabNumber2 = c.String(),
                        CardNumber1 = c.String(),
                        CardNumber2 = c.String(),
                        Type = c.Short(nullable: false),
                        CompanyName = c.String(),
                        ShomareSabt = c.String(),
                        EconomyNumber = c.String(),
                        Job = c.String(),
                        HadeEtebar = c.Decimal(nullable: false, precision: 20, scale: 0),
                        DateBirth = c.String(maxLength: 15),
                        NahveAshnaei = c.String(),
                        SubCode = c.String(maxLength: 10),
                        ClubPoint = c.Int(nullable: false),
                        PayType = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
