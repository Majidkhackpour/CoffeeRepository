using DataLayer.Mapping;
using DataLayer.Models.Account;
using DataLayer.Models.Anbar;
using DataLayer.Models.BankHesab;
using DataLayer.Models.Customer;
using DataLayer.Models.Perssonel;
using DataLayer.Models.PhoneBook;
using DataLayer.Models.Sellers;
using DataLayer.Models.Settings;

namespace DataLayer.Context
{
    using System;
    using System.Data.Entity;

    public class ModelContext : DbContext,IDisposable
    {
        public ModelContext(): base("name=ModelContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Migration.Migration.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Configurations.Add(new AccountGroupMapping());
            modelbuilder.Configurations.Add(new AccountMapping());
            modelbuilder.Configurations.Add(new AnbarGroupMapping());
            modelbuilder.Configurations.Add(new AnbarMapping());
            modelbuilder.Configurations.Add(new AppSettingMapping());
            modelbuilder.Configurations.Add(new HazineMapping());
            modelbuilder.Configurations.Add(new HesabGroupMapping());
            modelbuilder.Configurations.Add(new KolHesabMapping());
            modelbuilder.Configurations.Add(new MoeinHesabMapping());
            modelbuilder.Configurations.Add(new PerssonelGroupMapping());
            modelbuilder.Configurations.Add(new PerssonelMapping());
            modelbuilder.Configurations.Add(new PhoneBookMapping());
            modelbuilder.Configurations.Add(new SellerMapping());
            modelbuilder.Configurations.Add(new CustomerGroupMapping());
            modelbuilder.Configurations.Add(new CustomersMapping());
            modelbuilder.Configurations.Add(new BanksMapping());
            base.OnModelCreating(modelbuilder);
        }

        public virtual DbSet<Hazine> Hazine { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountGroup> AccountGroup { get; set; }
        public virtual DbSet<HesabGroup> HesabGroups { get; set; }
        public virtual DbSet<KolHesab> KolHesabs { get; set; }
        public virtual DbSet<MoeinHesab> MoeinHesabs { get; set; }
        public virtual DbSet<Anbar> Anbars { get; set; }
        public virtual DbSet<AnbarGroup> AnbarGroups { get; set; }
        public virtual DbSet<AppSetting> AppSetting { get; set; }
        public virtual DbSet<PerssonelGroup> PerssonelGroup { get; set; }
        public virtual DbSet<Perssonel> Perssonel { get; set; }
        public virtual DbSet<PhoneBook> PhoneBook { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<CustomerGroup> CusGroup { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Banks> Banks { get; set; }
    }
}