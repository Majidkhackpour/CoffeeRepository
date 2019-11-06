namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update9 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.KolHesabs", "GroupGuid");
            CreateIndex("dbo.MoeinHesabs", "KolGuid");
            AddForeignKey("dbo.KolHesabs", "GroupGuid", "dbo.HesabGroups", "Guid", cascadeDelete: true);
            AddForeignKey("dbo.MoeinHesabs", "KolGuid", "dbo.KolHesabs", "Guid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoeinHesabs", "KolGuid", "dbo.KolHesabs");
            DropForeignKey("dbo.KolHesabs", "GroupGuid", "dbo.HesabGroups");
            DropIndex("dbo.MoeinHesabs", new[] { "KolGuid" });
            DropIndex("dbo.KolHesabs", new[] { "GroupGuid" });
        }
    }
}
