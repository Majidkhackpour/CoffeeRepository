namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KolHesabs", "Half_Code", c => c.String(maxLength: 10));
            DropColumn("dbo.HesabGroups", "Half_Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HesabGroups", "Half_Code", c => c.String(maxLength: 10));
            DropColumn("dbo.KolHesabs", "Half_Code");
        }
    }
}
