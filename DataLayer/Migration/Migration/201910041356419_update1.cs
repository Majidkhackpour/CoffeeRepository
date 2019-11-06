namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HesabGroups",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        DateSabt = c.String(maxLength: 15),
                        Name = c.String(),
                        Code = c.String(maxLength: 10),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.KolHesabs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        DateSabt = c.String(maxLength: 15),
                        Name = c.String(),
                        Code = c.String(maxLength: 10),
                        GroupGuid = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                        System = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.HesabGroups", t => t.GroupGuid, cascadeDelete: true)
                .Index(t => t.GroupGuid);
            
            AddColumn("dbo.AccountGroups", "DateSabt", c => c.String(maxLength: 15));
            AddColumn("dbo.Hazines", "DateSabt", c => c.String(maxLength: 15));
            AlterColumn("dbo.Accounts", "Amounth", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KolHesabs", "GroupGuid", "dbo.HesabGroups");
            DropIndex("dbo.KolHesabs", new[] { "GroupGuid" });
            AlterColumn("dbo.Accounts", "Amounth", c => c.Decimal(nullable: false, precision: 20, scale: 0));
            DropColumn("dbo.Hazines", "DateSabt");
            DropColumn("dbo.AccountGroups", "DateSabt");
            DropTable("dbo.KolHesabs");
            DropTable("dbo.HesabGroups");
        }
    }
}
