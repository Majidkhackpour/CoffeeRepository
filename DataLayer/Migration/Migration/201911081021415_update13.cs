namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountGroups", "Type", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountGroups", "Type");
        }
    }
}
