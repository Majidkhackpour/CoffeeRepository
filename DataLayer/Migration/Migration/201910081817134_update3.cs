namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HesabGroups", "Half_Code", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HesabGroups", "Half_Code");
        }
    }
}
