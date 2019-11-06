namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Half_Code", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Half_Code");
        }
    }
}
