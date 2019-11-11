namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "HesabType", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "HesabType");
        }
    }
}
