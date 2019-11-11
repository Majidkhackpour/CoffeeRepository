using DataLayer.Models;
using DataLayer.Models.Account;
using DataLayer.Models.Anbar;

namespace DataLayer.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext,IDisposable
    {
        public ModelContext(): base("name=ModelContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Migration.Migration.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
        }

        public virtual DbSet<Hazine> Hazine { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountGroup> AccountGroup { get; set; }
        public virtual DbSet<HesabGroup> HesabGroups { get; set; }
        public virtual DbSet<KolHesab> KolHesabs { get; set; }
        public virtual DbSet<MoeinHesab> MoeinHesabs { get; set; }
        public virtual DbSet<Anbar> Anbars { get; set; }
        public virtual DbSet<AnbarGroup> AnbarGroups { get; set; }
    }
}