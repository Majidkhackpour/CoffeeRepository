namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KolHesabs", "GroupGuid", "dbo.HesabGroups");
            DropForeignKey("dbo.MoeinHesabs", "KolGuid", "dbo.KolHesabs");
            DropIndex("dbo.KolHesabs", new[] { "GroupGuid" });
            DropIndex("dbo.MoeinHesabs", new[] { "KolGuid" });
            AddColumn("dbo.KolHesabs", "HesabGroup_Guid", c => c.Guid());
            AddColumn("dbo.MoeinHesabs", "KolHesab_Guid", c => c.Guid());
            CreateIndex("dbo.KolHesabs", "HesabGroup_Guid");
            CreateIndex("dbo.MoeinHesabs", "KolHesab_Guid");
            AddForeignKey("dbo.KolHesabs", "HesabGroup_Guid", "dbo.HesabGroups", "Guid");
            AddForeignKey("dbo.MoeinHesabs", "KolHesab_Guid", "dbo.KolHesabs", "Guid");
            DropColumn("dbo.Accounts", "Amounth_Mahiat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Amounth_Mahiat", c => c.Short(nullable: false));
            DropForeignKey("dbo.MoeinHesabs", "KolHesab_Guid", "dbo.KolHesabs");
            DropForeignKey("dbo.KolHesabs", "HesabGroup_Guid", "dbo.HesabGroups");
            DropIndex("dbo.MoeinHesabs", new[] { "KolHesab_Guid" });
            DropIndex("dbo.KolHesabs", new[] { "HesabGroup_Guid" });
            DropColumn("dbo.MoeinHesabs", "KolHesab_Guid");
            DropColumn("dbo.KolHesabs", "HesabGroup_Guid");
            CreateIndex("dbo.MoeinHesabs", "KolGuid");
            CreateIndex("dbo.KolHesabs", "GroupGuid");
            AddForeignKey("dbo.MoeinHesabs", "KolGuid", "dbo.KolHesabs", "Guid", cascadeDelete: true);
            AddForeignKey("dbo.KolHesabs", "GroupGuid", "dbo.HesabGroups", "Guid", cascadeDelete: true);
        }
    }
}
