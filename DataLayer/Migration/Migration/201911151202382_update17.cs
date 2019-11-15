namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Amounth", c => c.Decimal(nullable: false, precision: 20, scale: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "Amounth", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
