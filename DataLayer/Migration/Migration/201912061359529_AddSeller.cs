namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sellers",
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
                        RespName = c.String(),
                        EconomyCode = c.String(),
                        Type = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            AlterColumn("dbo.Perssonels", "Half_Code", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Perssonels", "Half_Code", c => c.String());
            DropTable("dbo.Sellers");
        }
    }
}
