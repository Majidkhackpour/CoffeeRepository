using System.Collections.Generic;
using DataLayer.Context;
using DataLayer.Models.Account;

namespace DataLayer.Migration.Migration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.Context.ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migration\Migration";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataLayer.Context.ModelContext context)
        {
            
            //Add Deafault Value For HesabGroup

            //List<HesabGroup> groups = new List<HesabGroup>()
            //{
            //    new HesabGroup()
            //    {
            //        Guid = Guid.Parse("ee00bb9e-4a1a-4e3f-a5b3-c8255cb44618"),
            //        Code = "1",
            //        DateSabt = "1398/07/16",
            //        Name = "دارایی های جاری",
            //        Status = true
            //    },
            //    new HesabGroup()
            //    {
            //        Guid = Guid.Parse("9dc2c92f-1821-4e89-94e5-e42a9cf21b0e"),
            //        Code = "2",
            //        DateSabt = "1398/07/16",
            //        Name = "دارایی های غیرجاری",
            //        Status = true
            //    },
            //    new HesabGroup()
            //    {
            //        Guid = Guid.Parse("87561814-f4d8-41f4-b8f9-b80efa358e9e"),
            //        Code = "3",
            //        DateSabt = "1398/07/16",
            //        Name = "بدهی های جاری",
            //        Status = true
            //    },
            //    new HesabGroup()
            //    {
            //        Guid = Guid.Parse("fa93abf3-d25a-4b65-956d-af9f7a98acfa"),
            //        Code = "4",
            //        DateSabt = "1398/07/16",
            //        Name = "بدهی های بلندمدت",
            //        Status = true
            //    },
            //    new HesabGroup()
            //    {
            //        Guid = Guid.Parse("944ba1e4-8085-4adf-9244-007d23d6ff81"),
            //        Code = "5",
            //        DateSabt = "1398/07/16",
            //        Name = "حقوق صاحبان سهام",
            //        Status = true
            //    },
            //    new HesabGroup()
            //    {
            //        Guid = Guid.Parse("0f5a398a-e3fc-434d-bc1a-24a4c2792bd0"),
            //        Code = "6",
            //        DateSabt = "1398/07/16",
            //        Name = "درآمدها",
            //        Status = true
            //    },
            //    new HesabGroup()
            //    {
            //        Guid = Guid.Parse("8b7ace76-fab2-46e2-bf12-74e7eb84cc3b"),
            //        Code = "7",
            //        DateSabt = "1398/07/16",
            //        Name = "بهای تمام شده کالای فروش رفته",
            //        Status = true
            //    },
            //    new HesabGroup()
            //    {
            //        Guid = Guid.Parse("2a113ffd-29a7-4d3f-9cfc-51b26458cde9"),
            //        Code = "8",
            //        DateSabt = "1398/07/16",
            //        Name = "هزینه ها",
            //        Status = true
            //    },
            //    new HesabGroup()
            //    {
            //        Guid = Guid.Parse("8eb2d81a-1e69-4b2f-b561-454dda519177"),
            //        Code = "9",
            //        DateSabt = "1398/07/16",
            //        Name = "سایر هزینه ها",
            //        Status = true
            //    },
            //};
            //foreach (var aGroup in groups)
            //{
            //    context.HesabGroups.Add(aGroup);
            //}

            //context.SaveChanges();
        }
    }
}
