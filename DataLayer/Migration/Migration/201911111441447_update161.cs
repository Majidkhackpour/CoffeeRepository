namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update161 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnbarGroups", "Descrition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnbarGroups", "Descrition");
        }
    }
}
