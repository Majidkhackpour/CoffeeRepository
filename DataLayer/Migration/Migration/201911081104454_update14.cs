namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update14 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AccountGroups", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountGroups", "Type", c => c.Short(nullable: false));
        }
    }
}
