namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnbarGroups",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        DateSabt = c.String(maxLength: 15),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Anbars",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        DateSabt = c.String(maxLength: 15),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        AnbarGroup = c.Guid(nullable: false),
                        Manfi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Anbars");
            DropTable("dbo.AnbarGroups");
        }
    }
}
