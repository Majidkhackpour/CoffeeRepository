﻿namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHalfCodeToPerssonel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perssonels", "Half_Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perssonels", "Half_Code");
        }
    }
}
